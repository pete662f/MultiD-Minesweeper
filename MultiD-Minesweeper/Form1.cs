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
        int[] order = { 0, 1, 2, 3 };
        Random random = new Random();
        string[] buttonPair = { "yes",  "no" ,  "no" ,  "no"  };

        int count = 1;
        int X = 4;
        int Y = 1;
        int YMax = 4;

        public Form1()
        {
            InitializeComponent();
            order = order.OrderBy(x => random.Next()).ToArray();

            for (int i = 1; i <= X; i++)
            {
                Button b = new Button();
                b.Text = buttonPair[order[i - 1]];
                b.Name = count.ToString();
                b.Size = new Size(35, 35);
                b.Location = new Point(40 * (i + 1), 40 * Y);
                Controls.Add(b);
                if (i == X && Y < YMax)
                {
                    i = 0;
                    Y++;
                }
            }

        }
    }
}
