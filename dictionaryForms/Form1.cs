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
       static  string mainPath = @"C:\Program Files\Dictionary\";
        static string pathEng = @"C:\Program Files\Dictionary\EngWords.txt";
        static string pathRus = @"C:\Program Files\Dictionary\RusWords.txt";


        static public  int Counter()
        {
            int count = 0;

            if (File.Exists(pathEng))
                count = File.ReadAllLines(pathEng).Length;
            else
            {
                DirectoryInfo createDir = new DirectoryInfo(mainPath);
                createDir.Create();

                File.Create(pathRus);
                File.Create(pathEng);


            }

            count = File.ReadAllLines(pathEng).Length;


            return count;
            

        }
        
        
        int commonCount = Counter();

        //string countBase = 
        public Form1()
        {
            InitializeComponent();

        }

        public void Form1_Load(object sender, EventArgs e)

        {
            if (commonCount == 0)
                button2.Enabled = false;
            
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
            if (button2.Enabled == false)
                button2.Enabled = true;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for practice... in processing

            Practice f2 = new Practice();
            f2.Show();
        }

         

       static public List<string> BaseOfWords(bool lang)
        {
            bool lang_ = lang;

            //word base

            List<string> listEngwords = new List<string>();

            foreach (var item in File.ReadLines(pathEng))

                listEngwords.Add(item);

            

            List<string> listRuswords = new List<string>();

            foreach (var item in File.ReadLines(pathRus))

                listRuswords.Add(item);

            return  lang_ ? listEngwords : listRuswords;      //collection for Checker and other reason

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //check textbox on empty

            if (textBox1.Text == "" || textBox2.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
            //check on same words

            Checker(BaseOfWords(true));  
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
