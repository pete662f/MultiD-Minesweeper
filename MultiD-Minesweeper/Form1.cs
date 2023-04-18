using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiD_Minesweeper
{
    public partial class Form1 : Form
    {
        int dimensions;
        int length;
        int mines;
        Core core = new Core(); //Initiate core.cs

        int count = 1; //what number the button is

        public Form1()
        {
            InitializeComponent();

            //hide the tab pages and open the menu page
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPageMenu);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Save the numbers from the input, cause errors if it isn't numbers
            bool errorNum = int.TryParse(textBoxDimensions.Text, out dimensions);
            if (errorNum == true)
                errorNum = int.TryParse(textBoxLength.Text, out length);
            if (errorNum == true)
                errorNum = int.TryParse(textBoxMines.Text, out mines);

            //check if the amount of mines is more than the amount of tiles
            bool errorMines = true;
            bool errorMinesMin = true;
            bool errorSize = true;
            if (mines >= Math.Pow(length, dimensions))
                errorMines = false;
            if (mines < 1)
                errorMinesMin = false;
            if (Math.Pow(length, dimensions) > 9900)
                errorSize = false;

            if (errorNum == false)
            {
                //Show error if it couldn't parse the numbers
                MessageBox.Show("Error, try again with real numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (errorMines == false)
            {
                //Show error if the number of mines exceeds the number of tiles
                MessageBox.Show("Error, too many mines", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (errorMinesMin == false)
            {
                //Show error if the number of mines exceeds the number of tiles
                MessageBox.Show("Error, too few mines. Mines must be at least 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (errorSize == false)
            {
                //Show error if the number of mines exceeds the number of tiles
                MessageBox.Show("Error, too big game board. Number of tiles must not exceed 9900. You had " + Math.Pow(length, dimensions) + " tiles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Change the active page
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Insert(0, tabPageGame);

                //Change the size of the window to maximized
                this.MaximumSize = new Size(0, 0);
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
                tabControl1.Size = this.MaximumSize - new Size(15, 85);

                //Generate the game board
                Dictionary<int[], int> gameGrid = Core.GetGrid(dimensions, length, mines);

                //Initiates variables with starting position of the button
                int xCoord;
                int yCoord;

                //Initiates variables with the size of the button
                int xCoordMult;
                int yCoordMult;

                foreach (int[] key in gameGrid.Keys)
                {
                    //reset values
                    xCoordMult = 35;
                    yCoordMult = 35;
                    xCoord = 0;
                    yCoord = 0;

                    Button b = new Button();

                    //Calculates the x position of the button
                    for (int xC = 0; xC < dimensions; xC += 2)
                    {
                        xCoord += key[xC] * xCoordMult;
                        xCoordMult += xCoordMult * length + 5 * (xC + 1);
                    }

                    //Calculates the y position of the button
                    for (int yC = 1; yC < dimensions; yC += 2)
                    {
                        yCoord += key[yC] * yCoordMult;
                        yCoordMult += yCoordMult * length + 5 * (yC + 1);
                    }

                    //Makes a point variable with the location of the button
                    b.Location = new Point(xCoord, yCoord);
                    b.Size = new Size(35, 35); //Give the button a size
                    int value = gameGrid[key];
                    b.Text = value.ToString();
                    tabPageGame.Controls.Add(b); //Add the previous information to the button to place it

                }
                
                
            }

        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //change the active tab to play
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPagePlay);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            //change the active tab to settings
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPageSettings);
        }
    }
}
