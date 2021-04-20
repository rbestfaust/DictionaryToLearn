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
using System.Media;

namespace dictionaryForms
{


    public partial class Form1 : Form
    {

       static public  int Counter()
        {
            int count = 0;
            count = File.ReadAllLines(pathEng).Length;


            return count;
            

        }

       static string pathEng = @"C:\Users\Roman\Desktop\engWords\EngWords.txt";
        string pathRus = @"C:\Users\Roman\Desktop\engWords\RusWords.txt";
        
        int commonCount = Counter();

        //string countBase = 
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)

        {
            label3.Text = commonCount.ToString();
            label4.Text = commonCount.ToString();
            button1.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            


            using (StreamWriter addToEngList = new StreamWriter(pathEng, true))
                {
                    addToEngList.WriteLine(textBox1.Text.ToUpper());

                    
                }

                using (StreamWriter addToRusList = new StreamWriter(pathRus, true))
                {
                    addToRusList.WriteLine(textBox2.Text.ToUpper());

                    
                }

                label3.Text = Counter().ToString();
                label4.Text = Counter().ToString();
                textBox1.Text = "";
                textBox2.Text = "";




        }

        private void button2_Click(object sender, EventArgs e)
        {
             
           
            
        }

         

        List<string> BaseOfWords()
        {
            

            List<string> listEngwords = new List<string>();

            foreach (var item in File.ReadLines(pathEng))

                listEngwords.Add(item);

            

            List<string> listRuswords = new List<string>();

            foreach (var item in File.ReadLines(pathRus))

                listRuswords.Add(item);

            return listEngwords;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            Cheker(BaseOfWords());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            
        }

        void Cheker(List<string> collection)
        {
            

            
            foreach (var item in collection)
            {
                if (item == textBox1.Text.ToUpper())
                    MessageBox.Show("This word already added!");

            }

            
        }
    }
}
