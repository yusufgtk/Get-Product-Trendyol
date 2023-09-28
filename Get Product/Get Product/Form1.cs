using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Get_Product
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            if (textBox1.Text!="")
            {
                using(WebClient client = new WebClient()) 
                {
                    client.Encoding = Encoding.UTF8; // UTF-8 kodlaması kullan
                    string html = client.DownloadString(textBox1.Text);
                    HtmlDocument doc = new HtmlDocument();
                    doc.OptionDefaultStreamEncoding = Encoding.UTF8;
                    doc.LoadHtml(html);
                    var divImage = doc.DocumentNode.SelectSingleNode("//div[@class='base-product-image']");
                    var h1 = doc.DocumentNode.SelectSingleNode("//h1[@class='pr-new-br']");
                    var a = doc.DocumentNode.SelectSingleNode("//a[@class='product-brand-name-with-link']");
                    var span = doc.DocumentNode.SelectSingleNode("//span[@class='prc-dsc']");
                    var div = doc.DocumentNode.SelectSingleNode("//div[@class='info-wrapper']");
                    var ul = div.SelectSingleNode("//ul");
                    var liList = ul.SelectNodes("//li");

                    richTextBox1.Text = h1.InnerText;
                    textBox2.Text = a.InnerText;
                    textBox3.Text = span.InnerText;

                    foreach ( var li in liList )
                    {
                        richTextBox2.Text += li.InnerText + "\n";
                        richTextBox2.Text += "-----------------------------------------------------\n";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }
    }
}
