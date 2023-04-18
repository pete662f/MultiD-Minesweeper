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
        Image empty;
        Image thumbNailImage;

        //Make variables for later use
        int nonBombsFound = 0;
        int progressBarOverdrawn = 0;

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
                
                //Hide the text
                labelLoss.Visible = false;
                labelWin.Visible = false;

                //Change the active page
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Insert(0, tabPageGame);

                //Change the size of the window to maximized and place everything correctly
                this.MaximumSize = new Size(0, 0);
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
                tabControl1.Size = this.MaximumSize - new Size(15, 85);
                progressBar1.Location = new Point((this.MaximumSize.Width - 30)/2 - progressBar1.Width/2, 10);
                progressBar1.Maximum = mines;
                labelLoss.Location = new Point((this.MaximumSize.Width - 30) / 2 - labelLoss.Width / 2, (this.MaximumSize.Height - 40) / 2 - labelLoss.Height / 2);
                labelWin.Location = new Point((this.MaximumSize.Width - 30) / 2 - labelWin.Width / 2, (this.MaximumSize.Height - 40) / 2 - labelWin.Height / 2);


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

                        /*
                        for (int i = 0; i < length; i++)
                        {
                            CustomButton b = new CustomButton(); //Makes a button
                            int tempVal = gameBoard[i, j, k]; //Assigns the value of the button to a temporary variable to later print it when the button is pressed
                            b.Name = $"{i},{j},{k}"; //Name the button so you can find it's coordinates again later
                            //MessageBox.Show(b.Name);
                            b.Size = new Size(35, 35); //Give the button a size
                            b.Location = new Point(10 + 35 * i + 35 * length * k + 15 * k, 35 + 35 * j); //Give the button a location based on it's coordinates
                            b.FlatAppearance.BorderSize = 1; //Gives the button a border
                            b.BackColor = Color.DarkGray; //Changes the background color of the button
                            //Adds a function to the button that triggers when a mouse button is pressed
                            b.MouseDown += (sender2, e2) =>
                            {
                                buttonTrigger_Click(sender2, e2, b, tempVal);
                            };
                            

                            tabPageGame.Controls.Add(b); //Add the previous information to the button to place it
                        }*/

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

        private void buttonBackSettings_Click(object sender, EventArgs e)
        {
            //change the active tab to settings
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPageMenu);
        }

        private void buttonTrigger_Click(object sender, MouseEventArgs e, Button b, int tempVal)
        {
            if (b.Text == "" && b.Image == empty) //Checks if the button has been pressed before
            {
                if (e.Button == MouseButtons.Left) //Checks if the mouse button pressed was left click
                {
                    string value; //Makes an empty string to store the value of the button
                    if (tempVal < 0) //Checks if the button has a negative value and is therefore a bomb
                    {
                        //Place an image of a bomb in the button
                        Image ogImage = Properties.Resources.Bomb;
                        Image bombThumbNailImage = new Bitmap(ogImage, new Size(b.Width - 8, b.Height - 8));
                        b.Image = bombThumbNailImage;
                        b.ImageAlign = ContentAlignment.MiddleLeft;

                        //Show the label loss
                        labelLoss.Visible = true;
                    }
                    else
                    {
                        b.Text = tempVal.ToString(); //Shows the value of the button as text on the button.
                        nonBombsFound += 1;
                        if (nonBombsFound == Math.Pow(length, dimensions) - mines)
                        {
                            labelWin.Visible = true;
                        }
                        if (tempVal == 0)
                        {
                            // Assuming the parent control is the form
                            Form parentForm = this;


                            // Assuming the name of the button you want to trigger is "button2"
                            string button2Name = "0,0,0";

                            // Find the button2 control using its name
                            CustomButton button2 = parentForm.Controls.Find(button2Name, true).FirstOrDefault() as CustomButton;

                            if (button2 != null)
                            {
                                //Makes args for left-clicking button2
                                MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 1, button2.Location.X, button2.Location.Y, 0);

                                // Call the MouseDown event handler of button2
                                button2.TriggerMouseDown(args);
                            }


                        }
                    }
                    //MessageBox.Show(value.ToString());
                    b.BackColor = Color.LightGray; //Changes the background color of the button

                }
                else if (e.Button == MouseButtons.Right) //Checks if the mouse button pressed was right click
                {
                    //Place an image of a flag in the button
                    Image ogImage = Properties.Resources.Flag;
                    thumbNailImage = new Bitmap(ogImage, new Size(b.Width - 8, b.Height - 8));
                    b.Image = thumbNailImage;
                    b.ImageAlign = ContentAlignment.MiddleLeft;

                    if (progressBar1.Value < progressBar1.Maximum)
                    {
                        progressBar1.Value += 1;
                    }
                    else
                    {
                        progressBarOverdrawn += 1;
                    }
                }
            }
            else if (b.Image == thumbNailImage) //Checks if the button is flagged
            {
                if (e.Button == MouseButtons.Right) //Checks if the mouse button pressed was right click
                {
                    b.Image = empty; //Removes the flag from the button
                    if (progressBarOverdrawn == 0)
                    {
                        progressBar1.Value -= 1;
                    }
                    else
                    {
                        progressBarOverdrawn -= 1;
                    }
                }
            }
        }
    }
}
