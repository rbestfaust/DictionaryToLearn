using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace dictionaryForms
{


    public partial class Form1 : Form
    {


        string pathEng = @"C:\Users\Roman\Desktop\engWords\EngWords.txt";
        string pathRus = @"C:\Users\Roman\Desktop\engWords\RusWords.txt";

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {


            List<string> listEngwords = new List<string>();

            foreach (var item in File.ReadLines(pathEng))
            {
                listEngwords.Add(item);
            }

            List<string> listRuswords = new List<string>();

            foreach (var item in File.ReadLines(pathRus))
            {
                listRuswords.Add(item);
            }

            label3.Text = listEngwords.Count.ToString();
            label4.Text = listRuswords.Count.ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {



            using (StreamWriter addToEngList = new StreamWriter(pathEng, true))
            {
                addToEngList.WriteLine(textBox1.Text.ToUpper());

                textBox1.Text = "";
            }

            using (StreamWriter addToRusList = new StreamWriter(pathRus, true))
            {
                addToRusList.WriteLine(textBox2.Text.ToUpper());

                textBox2.Text = "";
            }



        }

       
    }
}
