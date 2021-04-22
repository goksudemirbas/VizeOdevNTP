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
                string il = item["ili"].InnerText;
                string sicaklik= item["Mak"].InnerText;
            }
           
        }
    }
}
