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

        const string xmlbaglanti = "https://www.mfa.gov.tr/tr.rss.mfa?8a5e254e-533a-4b3d-84db-9f95be1207ff";
        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument belge = new XmlDocument();
            belge.Load(xmlbaglanti);
            XmlElement root = belge.DocumentElement;
            XmlNodeList n1 = root.SelectNodes("channel/item");
           
           

            
            foreach (XmlNode item in n1)
            {
                
                string title = item["title"].InnerText;
                string desc = item["description"].InnerText;
             



                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = title;
                row.Cells[1].Value = desc;
            
                dataGridView1.Rows.Add(row);
            }

            TextWriter yaz = new StreamWriter(@"C:\Users\hp\source\repos\VizeOdev\VizeOdev\bin\Debug\duyuru.txt");
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    yaz.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "-");
                }
                yaz.WriteLine("");

            }
            yaz.Close();

          

        }

        
    }
    }

