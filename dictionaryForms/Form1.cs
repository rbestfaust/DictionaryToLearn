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
        //My local path for new words
       public static  string mainPath = @"C:\Program Files\Dictionary\";
       public static string pathEng = @"C:\Program Files\Dictionary\EngWords.txt";
       public static string pathRus = @"C:\Program Files\Dictionary\RusWords.txt";
        

        
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)

        {
            if (EnglishWords.Count() == 0 || RussianWords.Count() == 0)
                button2.Enabled = false;
            
            //how many words base have
            label3.Text = EnglishWords.Count().ToString();
            label4.Text = RussianWords.Count().ToString();
            button1.Enabled = false;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //for add new english word to base

            EnglishWords.Add(textBox1.Text);


            //for add new rissian word to base    

            RussianWords.Add(textBox2.Text);

            label3.Text = EnglishWords.Count().ToString();
            label4.Text = RussianWords.Count().ToString();
            textBox1.Text = "";
                textBox2.Text = "";
            if (button2.Enabled == false)
                button2.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for practice

            Practice f2 = new Practice();
            f2.Show();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //check textbox on empty

            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            //check on same words

            Checker(EnglishWords.BaseOfEnglishWords());  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
            {
                button1.Enabled = true;
                
            }
                
            
        }

        void Checker(List<string> collection)
        {
            
            //checker in person))
            
            foreach (var item in collection)
            {
                if (item == textBox1.Text.ToUpper())
                    MessageBox.Show("This word already added!");

            }

            
        }
    }
}
