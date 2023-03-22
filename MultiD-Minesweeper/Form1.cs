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
            if (mines >= Math.Pow(length, dimensions))
                errorMines = false;
                

            if(errorNum == true && errorMines == true)
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

                //Create a game board to use
                int[,,] gameBoard = core.Game(dimensions, length, mines);

                //generate the game board in the game tab
                for (int k = 0; k < gameBoard.GetLength(2); k++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            Button b = new Button();
                            if (gameBoard[i, j, k] < 0)
                            {
                                b.Text = "Bomb";
                            } else
                            {
                                b.Text = gameBoard[i, j, k].ToString();
                            }
                            b.Name = count.ToString(); //Name the button so you can find it's coordinates again later
                            b.Size = new Size(35, 35); //Give the button a size
                            b.Location = new Point(10 + 40 * i + 40 * length * k + 20 * k, 10 + 40 * j); //Give the button a location based on it's coordinates
                            tabPageGame.Controls.Add(b); //Add the previous information to the button to place it
                        }
                    }
                }
            }
            else if(errorNum == false)
            {
                //Show error if it couldn't parse the numbers
                MessageBox.Show("Error, try again with real numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (errorMines == false)
            {
                //Show error if the number of mines exceeds the number of tiles
                MessageBox.Show("Error, too many mines", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
