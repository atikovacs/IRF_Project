using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JV6INX_IRF_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            BackColor = Color.White;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Valuta valutabtn = new Valuta();
                    valutabtn.Top = 70+i * 55;
                    valutabtn.Left = (this.ClientSize.Width / 2) - 313 + j * 125;
                    this.Controls.Add(valutabtn);
                }
            }
        }
    }
}
