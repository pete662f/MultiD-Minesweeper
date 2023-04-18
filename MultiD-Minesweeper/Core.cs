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

        // Store the grid as a dictionary with string keys representing n-dimensional coordinates
        static Dictionary<int[], int> grid = new Dictionary<int[], int>();
         
        // Generate a key for the dictionary based on the coordinates
        static int[] Key(params int[] coordinates)
        {
            return coordinates;
        }

        // Increment the adjacent cells recursively for each dimension
        static void IncrementAdjacent(int[] coordinates, int dimensions, int size)
        {
            if (dimensions == 0) // Base case: when dimensions reach 0, we're at the target cell
            {
                // If the cell does not exist in the grid, initialize it to 0
                if (!grid.ContainsKey(Key(coordinates)))
                {
                    grid[Key(coordinates)] = 0;
                }

                // If the cell is not a mine, increment its value
                if (grid[Key(coordinates)] >= 0)
                {
                    grid[Key(coordinates)]++;
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
            GenerateGrid(dimensions, size, number_of_mines);
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
                } while (grid.ContainsKey(Key(mineCoordinates)) && grid[Key(mineCoordinates)] < 0);

                // Set the mine at the generated coordinates
                grid[Key(mineCoordinates)] = -number_of_mines;

                // Increment the adjacent cells' values
                IncrementAdjacent(mineCoordinates, dimensions, size);
            }

            // Initialize the remaining cells to 0
            // Iterate through all possible coordinate combinations in the n-dimensional grid
            foreach (var coordinateCombination in AllCoordinateCombinations(new int[dimensions], dimensions, size))
            {
                // If a cell has not been initialized (i.e., it's not in the dictionary), set its value to 0
                if (!grid.ContainsKey(Key(coordinateCombination)))
                {
                    grid[Key(coordinateCombination)] = 0;
                }
            }
        }
    }
}