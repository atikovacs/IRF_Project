using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JV6INX_IRF_PROJECT
{
    public class Valuta : Button
    {
        public Valuta()
        {
            BackColor = Color.DarkBlue;
            Height = 50;
            Width = 125;
            ForeColor = Color.White;
            Font = new Font("Times New Roman", 12);
            Text = "EUR";
            MouseHover += Valuta_MouseHover;
            MouseLeave += Valuta_MouseLeave;
        }

        private void Valuta_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.DarkBlue;
            Font = new Font("Times New Roman", 12);
        }

        private void Valuta_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
            Font = new Font("Times New Roman", 15, FontStyle.Bold);
        }
    }
}
