using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiD_Minesweeper
{
    public class CustomButton : Button
    {
        public void TriggerMouseDown(MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }
}
