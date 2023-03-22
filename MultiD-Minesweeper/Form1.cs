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

        int[] orderX = { 0, 1, 2, 3 };
        int[] orderY = { 0, 1, 2, 3 };
        Random randomX = new Random(Guid.NewGuid().GetHashCode());
        Random randomY = new Random(Guid.NewGuid().GetHashCode());
        string[,] buttonPair = { { "yes", "no", "no", "no" }, { "no", "no", "no", "no" }, { "no", "no", "no", "no" }, { "no", "no", "no", "no" } };

        int count = 1;
        int XMax = 4;
        int YMax = 4;

        public Form1()
        {
            InitializeComponent();
            orderX = orderX.OrderBy(x => randomX.Next()).ToArray();
            orderY = orderY.OrderBy(x => randomY.Next()).ToArray();
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

                //generate the game board in the game tab
                for (int j = 0; j < YMax; j++)
                {
                    for (int i = 0; i < XMax; i++)
                    {
                        Button b = new Button();
                        b.Text = buttonPair[orderX[i], orderY[j]];
                        b.Name = count.ToString();
                        b.Size = new Size(35, 35);
                        b.Location = new Point(40 * (i + 2), 40 * j);
                        Controls.Add(b);
                        tabPageGame.Controls.Add(b);
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
