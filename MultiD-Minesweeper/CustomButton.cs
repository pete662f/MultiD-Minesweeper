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
        public delegate void TriggerMouseDownDelegate(MouseEventArgs e);

        public void TriggerMouseDownSafely(MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                //Use delegate if triggered from a different thread
                Invoke(new TriggerMouseDownDelegate(OnMouseDown), e);
            }
            else
            {
                OnMouseDown(e);
            }
        }

    }
}
