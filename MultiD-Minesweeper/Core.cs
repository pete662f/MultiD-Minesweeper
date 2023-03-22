using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiD_Minesweeper
{
    internal class Core
    {
        public Core() { }
        public int[,,] Game(int dim = 3, int size = 10, int number_of_mines = 150)
        {
            var random = new Random();

            int xSize = 1, ySize = 1, zSize = 1;

            if (dim == 2)
            {
                xSize = size; ySize = size;
            }
            else if (dim == 3)
            {
                xSize = size; ySize = size; zSize = size;
            }
            
            int[,,] grid = new int[xSize, ySize, zSize];
            
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int o = grid.GetLength(2);


            // Initialize all cells to 0
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int l = 0; l < 0; l++)
                    {
                        grid[i, j, l] = 0;
                    }
                }
            }

            for (int k = 1; k <= number_of_mines; k++)
            {
                // Get random mine_x and mine_y where grid(mine_x, mine_y) is not a mine
                int mine_x, mine_y, mine_z;
                do
                {
                    mine_x = random.Next(0, n);
                    mine_y = random.Next(0, m);
                    mine_z = random.Next(0, o);
                } while (grid[mine_x, mine_y, mine_z] < 0); // negative value = mine

                // Place mine and update neighboring cells
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        for (int z = -1; z <= 1; z++)
                        {
                            if (x == 0 && y == 0 && z == 0)
                            {
                                grid[mine_x, mine_y, mine_z] = -number_of_mines; // negative value = mine
                            }
                            else
                            {

                                // check the bounds of the array
                                int new_x = mine_x + x;
                                int new_y = mine_y + y;
                                int new_z = mine_z + z;
                                if (new_x >= 0 && new_x < n && new_y >= 0 && new_y < m && new_z >= 0 && new_z < o)
                                {
                                    // increment the cell value by 1
                                    grid[new_x, new_y, new_z]++;
                                }
                            }
                        }
                    }
                }

            }
            return grid;
        }
    }
}
