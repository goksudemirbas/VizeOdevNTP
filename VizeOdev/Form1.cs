using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

using System.Text.RegularExpressions;

namespace VizeOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

         string xmlbaglanti = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument belge = new XmlDocument();
            belge.Load(xmlbaglanti);
            XmlElement root = belge.DocumentElement;
            XmlNodeList n1 = root.SelectNodes("sehirler");

            foreach (XmlNode item in n1)
            {
                string bolge = item["Bolge"].InnerText;
                string il = item["ili"].InnerText;
                string durum = item["Durum"].InnerText;
                string sicaklik = item["Mak"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = bolge;
                row.Cells[1].Value = il;
                row.Cells[2].Value = durum;
                row.Cells[3].Value = sicaklik;
                dataGridView1.Rows.Add(row);
            }

            TextWriter yaz = new StreamWriter(@"C:\Users\hp\source\repos\VizeOdev\VizeOdev\bin\Debug\Hava.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    yaz.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "-");
                }
                yaz.WriteLine("");

            }
            yaz.Close();

            Regex veri = new Regex("https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml");

            if (veri.IsMatch(@"C:\Users\hp\source\repos\VizeOdev\VizeOdev\bin\Debug\Hava.txt"))
                MessageBox.Show("Geçerli");
            else
                MessageBox.Show("Hatalı");
        }
        
       
    }
    }

