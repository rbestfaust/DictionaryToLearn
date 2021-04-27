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
        bool lang = true;  //need to select dictionary base True = English  False  = Russsian 
        string toHelp = "";
       
        int indexForCChecker;
        public Practice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            label3.Text = "";
        }

        string Trainer(bool lang)
        {
            string words = "";
            int index = Randomizer();

            if (lang)
            {
                string[] words_ = EnglishWords.BaseOfEnglishWords().ToArray();
                words = words_[index]; //select random word from base 
            }
            else
            {
                string[] words_ = RussianWords.BaseOfRussianWords().ToArray();
                words = words_[index]; //select random word from base 
            }

            
            indexForCChecker = index;
             
            return words;
        }

        int Randomizer()
        {
            Random random = new Random();
           return random.Next(0, EnglishWords.Count());
        }

        bool CheckTranslate(bool lang , int index , string input)
        {
            bool isCheck;
            string translate = "";


            if (lang)
            {
                string[] words = EnglishWords.BaseOfEnglishWords().ToArray();
                translate = words[index];
            }
            else
            {
                string[] words = RussianWords.BaseOfRussianWords().ToArray();
                translate = words[index];
            }

            
            
            if (translate == input)
            {
                isCheck = true;
                button1.Focus();
                
            }

            else
            {
                isCheck = false;
                
            }

            toHelp = translate;
            return isCheck;

        }
        void Next()
        {
            if (lang)
                lang = false;
            else
                lang = true;

            button1.Enabled = false;
            textBox1.Text = "";
            label1.Text = Trainer(lang);
            label2.Text = "";

            
        }

       async private void button2_Click(object sender, EventArgs e)
        {

            label3.Text = toHelp;
          await  Task.Delay(1000);
            label3.Text = "";

        }

        private void Practice_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
