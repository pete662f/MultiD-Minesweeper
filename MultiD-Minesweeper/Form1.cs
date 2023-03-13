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
        Core test = new Core();

        
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
            test.Game();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = false; //Hide the start button

            //generate the game board
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
                }
            }
        }
    }
}
