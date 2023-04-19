using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiD_Minesweeper
{


    

    internal class Core
    {
        public Core() { }

        // This class implements the IEqualityComparer interface and is used to compare two arrays of integers
        public class IntArrayComparer : IEqualityComparer<int[]>
        {
            // This method compares two arrays of integers for equality
            public bool Equals(int[] x, int[] y)
            {
                // If either array is null, they are not equal
                if (x == null || y == null)
                {
                    return false;
                }

                // If the arrays have different lengths, they are not equal
                if (x.Length != y.Length)
                {
                    return false;
                }

                // Compare each element of the arrays to see if they are equal
                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] != y[i])
                    {
                        return false;
                    }

                }

                // If we made it here, the arrays are equal
                return true;
            }

            // This method generates a hash code for an array of integers
            public int GetHashCode(int[] obj)
            {
                // If the array is null, return 0 as the hash code
                if (obj == null)
                {
                    return 0;
                }

                // Start with the length of the array as the hash code
                int hashCode = obj.Length;

                // Multiply the hash code by a prime number (31) and add each element of the array to it
                for (int i = 0; i < obj.Length; i++)
                {
                    hashCode = unchecked(hashCode * 31 + obj[i]);
                }

                // Return the final hash code
                return hashCode;
            }
        }

        // This dictionary stores the grid
        static Dictionary<int[], int> grid;


        // Increment the adjacent cells recursively for each dimension
        static void IncrementAdjacent(int[] coordinates, int dimensions, int size)
        {
            if (dimensions == 0) // Base case: when dimensions reach 0, we're at the target cell
            {
                // If the cell does not exist in the grid, initialize it to 0
                if (!grid.ContainsKey(coordinates))
                {
                    grid[coordinates] = 0;
                }

                // If the cell is not a mine, increment its value
                if (grid[coordinates] >= 0)
                {
                    grid[coordinates]++;
                }
                return;
            }

            // Iterate through each dimension recursively
            for (int i = -1; i <= 1; i++)
            {
                // Create a new set of coordinates based on the input coordinates
                int[] newCoordinates = new int[coordinates.Length];
                // Copy the input coordinates into the new set of coordinates
                Array.Copy(coordinates, newCoordinates, coordinates.Length);
                // Modify the current dimension's coordinate by adding the loop variable 'i'
                newCoordinates[dimensions - 1] += i;
                // Skip if newCoordinates is out of the grid
                if (newCoordinates[dimensions - 1] == -1 || newCoordinates[dimensions - 1] == size)
                {
                    continue;
                }
                // Call the IncrementAdjacent method recursively with the new set of coordinates and decremented dimensions
                IncrementAdjacent(newCoordinates, dimensions - 1, size);
            }
        }

        // Generates all possible coordinate combinations in the n-dimensional grid
        static IEnumerable<int[]> AllCoordinateCombinations(int[] coordinates, int dimensions, int size)
        {
            if (dimensions == 0) // Base case: when dimensions reach 0, we're at a valid coordinate combination
            {
                // Return the generated coordinate combination
                yield return coordinates;
            }
            else
            {
                // Iterate through each dimension recursively
                for (int i = 0; i < size; i++)
                {
                    int[] newCoordinates = new int[coordinates.Length];
                    // Copy the input coordinates into the new set of coordinates
                    Array.Copy(coordinates, newCoordinates, coordinates.Length);
                    // Modify the current dimension's coordinate by setting it to the loop variable 'i'
                    newCoordinates[dimensions - 1] = i;
                    // Call the AllCoordinateCombinations method recursively with the new set of coordinates and decremented dimensions
                    foreach (var coordinateCombination in AllCoordinateCombinations(newCoordinates, dimensions - 1, size))
                    {
                        yield return coordinateCombination;
                    }
                }
            }
        }


        // The function that get called and returns the grid
        public static Dictionary<int[], int> GetGrid(int dimensions, int size, int number_of_mines)
        {
            // Store the grid as a dictionary with string keys representing n-dimensional coordinates
            grid = new Dictionary<int[], int>(new IntArrayComparer());

            // Generate the grid
            GenerateGrid(dimensions, size, number_of_mines);

            // Return the grid
            return grid;
        }

        static void GenerateGrid(int dimensions, int size, int number_of_mines)
        {
            Random random = new Random();

            // Place mines and increment adjacent cells
            for (int k = 0; k < number_of_mines; k++)
            {
                int[] mineCoordinates;
                do
                {
                    // Generate random coordinates for each dimension
                    mineCoordinates = new int[dimensions];
                    for (int i = 0; i < dimensions; i++)
                    {
                        mineCoordinates[i] = random.Next(size);
                    }
                } while (grid.ContainsKey(mineCoordinates) && grid[mineCoordinates] < 0);

                // Set the mine at the generated coordinates
                grid[mineCoordinates] = -number_of_mines;

                // Increment the adjacent cells' values
                IncrementAdjacent(mineCoordinates, dimensions, size);
            }

            // Initialize the remaining cells to 0
            // Iterate through all possible coordinate combinations in the n-dimensional grid
            foreach (var coordinateCombination in AllCoordinateCombinations(new int[dimensions], dimensions, size))
            {
                // If a cell has not been initialized (i.e., it's not in the dictionary), set its value to 0
                if (!grid.ContainsKey(coordinateCombination))
                {
                    grid[coordinateCombination] = 0;
                }
            }
        }
    }
}