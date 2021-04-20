using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dictionaryForms
{
    public partial class Practice : Form
    {
        bool lang = true;  //need to select dictionary base
        int indexForCChecker;
        public Practice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(lang == true)
            //{
            //    label1.Text = Trainer(lang);
            //    button1.Enabled = CheckTranslate(false, indexForCChecker, textBox1.Text.ToUpper());
            //    lang = false;
            //    button1.Enabled = false;
            //    textBox1.Text.Trim();

            //}
            //else
            //{
            //    label1.Text = Trainer(lang);
            //    button1.Enabled = CheckTranslate(true, indexForCChecker, textBox1.Text.ToUpper());
            //    lang = true;
            //    button1.Enabled = false;
            //    textBox1.Text.Trim();
            //}
            Next();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;

            if (lang)
            {
                button1.Enabled = CheckTranslate(false, indexForCChecker, textBox1.Text.ToUpper());
            }

            else
            {
                button1.Enabled = CheckTranslate(true, indexForCChecker, textBox1.Text.ToUpper());
            }
                
            label2.Text = "";

            if(button1.Enabled)
                label2.Text = "Right answer!";
            else
                label2.Text = "Wrong answer!!!";

        }

        private void Practice_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;

            label1.Text = Trainer(true);
            label2.Text = "";
        }

        string Trainer(bool lang)
        {

            List<string> trainer = new List<string>();
            trainer = Form1.BaseOfWords(lang);//to get word base
            int index = Randomizer();
            indexForCChecker = index;
            string words = trainer[index]; //select random word from base 
            return words;
        }

        int Randomizer()
        {
            Random random = new Random();
           return random.Next(0, Form1.Counter());
        }

        bool CheckTranslate(bool lang , int index , string input)
        {
            bool isCheck;
            string translate = "";
            List<string> base_ = new List<string>();
            base_ = Form1.BaseOfWords(lang);
            translate = base_[index];
            if (translate == input)
            {
                isCheck = true;
                
            }

            else
            {
                isCheck = false;
                
            }
                
            return isCheck;

        }
        void Next()
        {
            

            button1.Enabled = false;
            textBox1.Text = "";
            label1.Text = Trainer(lang);
            label2.Text = "";
            

        }
    }
}
