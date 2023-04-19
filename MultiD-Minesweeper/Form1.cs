using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MultiD_Minesweeper.CustomButton;

namespace MultiD_Minesweeper
{
    public partial class Form1 : Form
    {
        int dimensions;
        int length;
        int mines;
        Size windowSize;
        Image empty;
        Image thumbNailImage;
        Image bombThumbNailImage;
        Dictionary<int[], int> gameGrid;

        //Make variables for later use
        int nonBombsFound = 0;

        public Form1()
        {
            InitializeComponent();

            //hide the tab pages and open the menu page
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPageMenu);


            //Change the size and placement of the window
            this.WindowState = FormWindowState.Normal;
            windowSize = new Size(this.Size.Width, this.Size.Height + 15);
            this.MinimumSize = windowSize;
            this.MaximumSize = windowSize;
            this.Size = windowSize;
            tabControl1.Size = this.MaximumSize;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Make the flag image
            Image ogImageFlag = Properties.Resources.Flag;
            thumbNailImage = new Bitmap(ogImageFlag, new Size(35 - 8, 35 - 8));

            //Make the bomb image
            Image ogImageBomb = Properties.Resources.Bomb;
            bombThumbNailImage = new Bitmap(ogImageBomb, new Size(35 - 8, 35 - 8));

        }

        public delegate void addControlsDelegate(CustomButton b);

        public void addControlsSafely(CustomButton b)
        {
            if (InvokeRequired)
            {
                //Use delegate if triggered from a different thread
                Invoke(new addControlsDelegate(tabPageGame.Controls.Add), b);
            }
            else
            {
                tabPageGame.Controls.Add(b);
            }
        }

        private void loadGrid(Dictionary<int[], int> gameGrid)
        {
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

                CustomButton b = new CustomButton(); //Makes a button

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
                b.Name = string.Join(",", key); //Gives the button a name corresponding to its coordinates joined by a comma
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 1; //Gives the button a border
                b.FlatAppearance.BorderColor = Color.Black;
                b.BackColor = Color.DarkGray; //Changes the background color of the button
                b.MouseDown += (sender2, e2) =>
                {
                    buttonTrigger_Click(sender2, e2, b, gameGrid[key]);
                };
                b.MouseHover += (sender2, e2) =>
                {
                    int[] coordinates = b.Name.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                    // Makes a variable to store in which form the buttons are located
                    Form parentForm = this;

                    Task task1 = new Task(() => neighborHighlight(coordinates, dimensions, length, parentForm, Color.Blue, Color.LightBlue, Color.LightBlue));

                    task1.Start();
                };
                b.MouseLeave += (sender2, e2) =>
                {
                    int[] coordinates = b.Name.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                    // Makes a variable to store in which form the buttons are located
                    Form parentForm = this;

                    Task task1 = new Task(() => neighborHighlight(coordinates, dimensions, length, parentForm, Color.Black, Color.DarkGray, Color.LightGray));

                    task1.Start();
                };
                addControlsSafely(b); //Add the previous information to the button to place it

            }
        }

        private void neighborHighlight(int[] coordinates, int dimensions, int size, Form parentForm, Color color, Color backColor, Color backColor2)
        {
            if (dimensions == 0)
            {

                string button2Name = string.Join(",", coordinates);

                // Find the button2 control using its name
                CustomButton button2 = parentForm.Controls.Find(button2Name, true).FirstOrDefault() as CustomButton;

                if (button2 != null)
                {
                    button2.FlatAppearance.BorderColor = color;
                    if (button2.Text == "")
                    {
                        button2.BackColor = backColor;
                    }
                    else
                    {
                        button2.BackColor = backColor2;
                    }
                }

                return;
            }

            for (int i = -1; i <= 1; i++)
            {
                int[] newCoordinates = new int[coordinates.Length];
                Array.Copy(coordinates, newCoordinates, coordinates.Length);
                newCoordinates[dimensions - 1] += i;
                if (newCoordinates[dimensions - 1] == -1 || newCoordinates[dimensions - 1] > size)
                {
                    continue;
                }
                neighborHighlight(newCoordinates, dimensions - 1, size, parentForm, color, backColor, backColor2);
            }
        }

        private void getNeighbor(int[] coordinates, int dimensions, int size, Form parentForm)
        {
            if (dimensions == 0)
            {

                string button2Name = string.Join(",", coordinates);

                // Find the button2 control using its name
                CustomButton button2 = parentForm.Controls.Find(button2Name, true).FirstOrDefault() as CustomButton;

                if (button2 != null && button2.Text == "")
                {
                    //Makes args for left-clicking button2
                    MouseEventArgs args = new MouseEventArgs(MouseButtons.Left, 1, button2.Location.X, button2.Location.Y, 0);

                    //Thread.Sleep(1);

                    // Call the MouseDown event handler of button2
                    button2.TriggerMouseDownSafely(args);
                }

                return;
            }

            for (int i = -1; i <= 1; i++)
            {
                int[] newCoordinates = new int[coordinates.Length];
                Array.Copy(coordinates, newCoordinates, coordinates.Length);
                newCoordinates[dimensions - 1] += i;
                if (newCoordinates[dimensions - 1] == -1 || newCoordinates[dimensions - 1] > size)
                {
                    continue;
                }
                getNeighbor(newCoordinates, dimensions - 1, size, parentForm);
            }
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
                buttonReturn.Visible = false;

                //Change the active page
                tabControl1.TabPages.Clear();
                tabControl1.TabPages.Insert(0, tabPageGame);

                //Change the size of the window to maximized and place everything correctly
                this.MaximumSize = new Size(0, 0);
                this.WindowState = FormWindowState.Maximized;
                this.MinimumSize = this.Size;
                this.MaximumSize = this.Size;
                tabControl1.Size = this.MaximumSize - new Size(15, 85);
                labelLoss.Location = new Point((this.MaximumSize.Width - 30) / 2 - labelLoss.Width / 2, (this.MaximumSize.Height - 40) / 2 - labelLoss.Height / 2);
                labelWin.Location = new Point((this.MaximumSize.Width - 30) / 2 - labelWin.Width / 2, (this.MaximumSize.Height - 40) / 2 - labelWin.Height / 2);

                Cursor = Cursors.WaitCursor;

                //Generate the game board
                gameGrid = Core.GetGrid(dimensions, length, mines);

                loadGrid(gameGrid);

                Cursor = Cursors.Default;

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

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            //change the active tab to settings
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Insert(0, tabPageMenu);

            //Change the size and placement of the window
            this.WindowState = FormWindowState.Normal;
            this.MinimumSize = windowSize;
            this.MaximumSize = windowSize;
            this.Size = windowSize;
            tabControl1.Size = this.MaximumSize;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonTrigger_Click(object sender, MouseEventArgs e, Button b, int tempVal)
        {
            if (b.Text == "" && b.Image == empty) //Checks if the button has been pressed before
            {
                if (e.Button == MouseButtons.Left) //Checks if the mouse button pressed was left click
                {
                    if (tempVal < 0) //Checks if the button has a negative value and is therefore a bomb
                    {
                        //Place an image of a bomb in the button
                        b.Image = bombThumbNailImage;
                        b.ImageAlign = ContentAlignment.MiddleLeft;


                        TabPage tabPage = tabControl1.TabPages[0];

                        // Get the size of the visible client area
                        Size clientSize = tabControl1.ClientSize;

                        // Calculate the center point of the visible client area after scrolling
                        int centerX = clientSize.Width / 2;
                        int centerY = clientSize.Height / 2;

                        // Calculate the position of the point to center
                        int pointX = centerX - (labelLoss.Width / 2) - tabPage.Left;
                        int pointY = centerY - (labelLoss.Height / 2) - tabPage.Top;

                        // Set the position of the point
                        labelLoss.Location = new Point(pointX, pointY);
                        buttonReturn.Location = new Point(pointX, pointY + labelLoss.Height - 1);

                        //Style button
                        buttonReturn.FlatStyle = FlatStyle.Flat;

                        //Show the label loss
                        labelLoss.Visible = true;
                        buttonReturn.Visible = true;
                    }
                    else
                    {
                        b.Text = tempVal.ToString(); //Shows the value of the button as text on the button.
                        nonBombsFound += 1;
                        if (nonBombsFound == Math.Pow(length, dimensions) - mines)
                        {
                            TabPage tabPage = tabControl1.TabPages[0];

                            // Get the size of the visible client area
                            Size clientSize = tabControl1.ClientSize;

                            // Calculate the center point of the visible client area after scrolling
                            int centerX = clientSize.Width / 2;
                            int centerY = clientSize.Height / 2;

                            // Calculate the position of the point to center
                            int pointX = centerX - (labelWin.Width / 2) - tabPage.Left;
                            int pointY = centerY - (labelWin.Height / 2) - tabPage.Top;

                            // Set the position of the point
                            labelWin.Location = new Point(pointX, pointY);
                            buttonReturn.Location = new Point(pointX, pointY + labelWin.Height - 1);

                            //Style button
                            buttonReturn.FlatStyle = FlatStyle.Flat;

                            //Show the label loss
                            labelWin.Visible = true;
                            buttonReturn.Visible = true;
                        }
                        if (tempVal == 0)
                        {

                            int[] coordinates = b.Name.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

                            // Makes a variable to store in which form the buttons are located
                            Form parentForm = this;

                            Task task1 = new Task(() => getNeighbor(coordinates, dimensions, length, parentForm));

                            task1.Start();

                        }
                    }
                    b.BackColor = Color.LightGray; //Changes the background color of the button

                }
                else if (e.Button == MouseButtons.Right) //Checks if the mouse button pressed was right click
                {
                    //Place an image of a flag in the button
                    b.Image = thumbNailImage;
                    b.ImageAlign = ContentAlignment.MiddleLeft;
                }
            }
            else if (b.Image == thumbNailImage) //Checks if the button is flagged
            {
                if (e.Button == MouseButtons.Right) //Checks if the mouse button pressed was right click
                {
                    b.Image = empty; //Removes the flag from the button
                }
            }
        }
    }
}
