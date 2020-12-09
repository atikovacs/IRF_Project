using JV6INX_IRF_PROJECT.Entities;
using JV6INX_IRF_PROJECT.MnbServiceReference;
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
        BindingList<Valuta> Currencies;
        public Form1()
        {
            InitializeComponent();

            Createcimlbl();

            Createmagyarazatlbl();

            Createforraslbl();

            BackColor = Color.White;
            /*System.DateTime date1 = new System.DateTime(2020, 11, 09, 11, 03);
            //System.DateTime date2 = new System.DateTime(2020, 12, 09, 11, 03);
            System.TimeSpan diff1 = date2.Subtract(date1);
            MessageBox.Show(diff1.ToString("yyyy-MM-dd"))*/
            int szamlalo = 29;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Datebtn datebtn = new Datebtn();
                    datebtn.Top = 80 + i * 55;
                    datebtn.Left = (this.ClientSize.Width / 2) - 375 + j * 125;
                    DateTime datum = DateTime.Today;
                    datum = datum.AddDays(-szamlalo);
                    datebtn.Text = datum.ToString("yyyy-MM-dd");
                    szamlalo = szamlalo - 1;

                    this.Controls.Add(datebtn);
                }
            }

            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                startDate = DateTime.Today.AddDays(-29).ToString("yyyy-MM-dd"),
                endDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            var response = mnbService.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;
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
            forraslbl.Font = new Font("Times New Roman", 8 , FontStyle.Italic);
            this.Controls.Add(forraslbl);
        }

        private void Createmagyarazatlbl()
        {
            Label magyarazatlbl = new Label();
            magyarazatlbl.Text = "Kattintson rá egy dátumra, hogy lementse csv formájában az akkori árfolyamokat:";
            magyarazatlbl.AutoSize = true;
            magyarazatlbl.Top = 55;
            magyarazatlbl.Left = 40;
            magyarazatlbl.Font = new Font("Times New Roman", 12);
            magyarazatlbl.ForeColor = Color.DarkBlue;
            this.Controls.Add(magyarazatlbl);
        }

        private void Createcimlbl()
        {
            Label cimlbl = new Label();
            cimlbl.Text = "Az előző 30 nap árfolyamja";
            cimlbl.Height = 35;
            cimlbl.Width = 500;
            cimlbl.Left = (this.ClientSize.Width / 2) - 160;
            cimlbl.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            cimlbl.ForeColor = Color.DarkBlue;
            cimlbl.Anchor = (AnchorStyles.Top);
            this.Controls.Add(cimlbl);
        }
    }
}
