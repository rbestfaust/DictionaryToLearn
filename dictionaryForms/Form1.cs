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
        //My local path for new words
       static string pathEng = @"C:\Users\Roman\Desktop\engWords\EngWords.txt";
       static string pathRus = @"C:\Users\Roman\Desktop\engWords\RusWords.txt";
        
        int commonCount = Counter();

        //string countBase = 
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)

        {
            //how many words base have
            label3.Text = commonCount.ToString();
            label4.Text = commonCount.ToString();
            button1.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            

            //for add new english word to base
            using (StreamWriter addToEngList = new StreamWriter(pathEng, true))
               
                    addToEngList.WriteLine(textBox1.Text.ToUpper());

            //for add new rissian word to base    
            using (StreamWriter addToRusList = new StreamWriter(pathRus, true))
                
                    addToRusList.WriteLine(textBox2.Text.ToUpper());


                label3.Text = Counter().ToString();
                label4.Text = Counter().ToString();
                textBox1.Text = "";
                textBox2.Text = "";




        }

        private void button2_Click(object sender, EventArgs e)
        {
             //for practice... in processing
           
            
        }

         

        List<string> BaseOfWords()
        {
            //word base

            List<string> listEngwords = new List<string>();

            foreach (var item in File.ReadLines(pathEng))

                listEngwords.Add(item);

            

            List<string> listRuswords = new List<string>();

            foreach (var item in File.ReadLines(pathRus))

                listRuswords.Add(item);

            return listEngwords;      //collection for Checker and other reason
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //check textbox on empty

            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            //check on same words

            Checker(BaseOfWords());  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            
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
