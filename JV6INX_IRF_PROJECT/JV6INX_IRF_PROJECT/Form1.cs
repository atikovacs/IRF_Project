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

            Createcimlbl();

            Createmagyarazatlbl();

            Createforraslbl();

            BackColor = Color.White;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Valuta valutabtn = new Valuta();
                    valutabtn.Top = 80 + i * 55;
                    valutabtn.Left = (this.ClientSize.Width / 2) - 313 + j * 125;
                    this.Controls.Add(valutabtn);
                }
            }
        }

        private void Createforraslbl()
        {
            Label forraslbl = new Label();
            forraslbl.Text = "Minden adat a Magyar Nemzeti Bank SOAP webszolgáltatásán keresztül lett elérve";
            forraslbl.Height = 20;
            forraslbl.Width = 400;
            forraslbl.Top = 380;
            forraslbl.Left = (this.ClientSize.Width / 2) - 200;
            forraslbl.Anchor = (AnchorStyles.Bottom);
            forraslbl.ForeColor = Color.DarkBlue;
            forraslbl.Font = new Font("Times New Roman", 8);
            this.Controls.Add(forraslbl);
        }

        private void Createmagyarazatlbl()
        {
            Label magyarazatlbl = new Label();
            magyarazatlbl.Text = "Kattintson rá egy valutára, hogy lementse a jelenlegi árfolyamjait:";
            magyarazatlbl.AutoSize = true;
            magyarazatlbl.Top = 55;
            magyarazatlbl.Left = 25;
            magyarazatlbl.Font = new Font("Times New Roman", 12);
            magyarazatlbl.ForeColor = Color.DarkBlue;
            this.Controls.Add(magyarazatlbl);
        }

        private void Createcimlbl()
        {
            Label cimlbl = new Label();
            cimlbl.Text = "Aktuális árfolyamok";
            cimlbl.Height = 35;
            cimlbl.Width = 300;
            cimlbl.Left = (this.ClientSize.Width / 2) - 135;
            cimlbl.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            cimlbl.ForeColor = Color.DarkBlue;
            cimlbl.Anchor = (AnchorStyles.Top);
            this.Controls.Add(cimlbl);
        }
    }
}
