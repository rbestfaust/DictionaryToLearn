using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dictionaryForms
{
    class EnglishWords : Form1
    {

       static public int Count()
        {
            int count = 0;

            if (File.Exists(Form1.pathEng))
                count = File.ReadAllLines(Form1.pathEng).Length;
            else
            {
                DirectoryInfo createDir = new DirectoryInfo(Form1.mainPath);
                createDir.Create();

                File.Create(Form1.pathEng);

            }
            count = File.ReadAllLines(Form1.pathEng).Length;
            return count;
        }

        static public void Add(string newWord)
        {
            using (StreamWriter addToEngList = new StreamWriter(pathEng, true))

                addToEngList.WriteLine(newWord.ToUpper());
        }

        static public List<string> BaseOfEnglishWords()
        {
            List<string> listEngwords = new List<string>();

            foreach (var item in File.ReadLines(pathEng))

                listEngwords.Add(item);
            return listEngwords;
        }

    }
}
