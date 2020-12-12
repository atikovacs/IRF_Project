using JV6INX_IRF_PROJECT.Entities;
using JV6INX_IRF_PROJECT.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JV6INX_IRF_PROJECT
{
    public partial class Form1 : Form
    {
        BindingList<Valuta> Arfolyamok = new BindingList<Valuta>();

        List<string> cv = new List<string>
        { "EUR", "AUD", "BGN", "BRL", "CAD", "CHF", "CNY", "CZK", "DKK",
          "GBP", "HKD", "HRK", "IDR", "ILS", "INR", "ISK", "JPY", "KRW",
          "MXN",  "MYR", "NOK", "NZD", "PHP", "PLN", "RON", "RSD", "RUB",
          "SEK", "SGD", "THB", "TRY", "UAH", "USD", "ZAR"};
        public Form1()
        {
            InitializeComponent();

            GER();

            Createcimlbl();

            Createmagyarazatlbl();

            Createforraslbl();

            BackColor = Color.White;
            
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

                    datebtn.Click += Datebtn_Click;

                    szamlalo = szamlalo - 1;

                    this.Controls.Add(datebtn);
                }
            }
            
        }

        void Datebtn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var date = Convert.ToDateTime(button.Text);
            
            var eredmeny = from x in Arfolyamok where x.Date.Year == date.Year && x.Date.Month == date.Month && x.Date.Day == date.Day select new { x.Currency, x.Value };

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return;
            {
                StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8);
                {
                    foreach (var x in eredmeny)
                    {
                        sw.Write(x.Currency);
                        sw.Write(";");
                        sw.Write(x.Value.ToString());
                        sw.Write(";");
                        sw.WriteLine();
                    }

                    sw.Close();
                }
            }
        }

        private void GER()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();

            foreach (var item in cv)
            {
                var request = new GetExchangeRatesRequestBody()
                {
                    currencyNames = item,
                    startDate = DateTime.Today.AddDays(-29).ToString("yyyy-MM-dd"),
                    endDate = DateTime.Today.ToString("yyyy-MM-dd")
                };



                var response = mnbService.GetExchangeRates(request);

                var result = response.GetExchangeRatesResult;

                var xml = new XmlDocument();
                xml.LoadXml(result);

                foreach (XmlElement element in xml.DocumentElement)
                {
                    var valuta = new Valuta();
                    Arfolyamok.Add(valuta);

                    valuta.Date = DateTime.Parse(element.GetAttribute("date"));

                    var childElement = (XmlElement)element.ChildNodes[0];
                    if (childElement == null)
                        continue;
                    valuta.Currency = childElement.GetAttribute("curr");

                    var unit = decimal.Parse(childElement.GetAttribute("unit"));
                    var value = decimal.Parse(childElement.InnerText);
                    if (unit != 0)
                        valuta.Value = value / unit;
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
