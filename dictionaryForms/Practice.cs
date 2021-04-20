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

        public Practice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lang == true)
            {
                label1.Text = Trainer(lang);
                lang = false;
            }
            else
            {
                label1.Text = Trainer(lang);
                lang = true;
            }
            
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text == "" )
            //    button1.Enabled = false;
            //else
            //    button1.Enabled = true;
        }

        private void Practice_Load(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            
            label1.Text = Trainer(true);
        }

        string Trainer(bool lang)
        {

            List<string> trainer = new List<string>();
            trainer = Form1.BaseOfWords(lang);//to get word base
            int index = Randomizer();
            string words = trainer[index]; //select random word from base 
            return words;
        }

        int Randomizer()
        {
            Random random = new Random();
           return random.Next(0, Form1.Counter());
        }

        void CheckTranslate(bool lang)
        {
            foreach (var item in Form1.BaseOfWords(lang))
            {
               
            }
        }
    }
}
