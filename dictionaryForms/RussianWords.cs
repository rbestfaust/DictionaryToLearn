using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dictionaryForms
{
    class RussianWords:Form1
    {
     static   public int Count()
        {
            int count = 0;

            if (File.Exists(Form1.pathRus))
                count = File.ReadAllLines(Form1.pathRus).Length;
            else
            {
                DirectoryInfo createDir = new DirectoryInfo(Form1.mainPath);
                createDir.Create();

                File.Create(Form1.pathRus);

            }
            count = File.ReadAllLines(Form1.pathRus).Length;
            return count;
        }

        static public void Add(string newWord)
        {
            using (StreamWriter addToRusList = new StreamWriter(pathRus, true))

                addToRusList.WriteLine(newWord.ToUpper());
        }

        static public List<string> BaseOfRussianWords()
        {
            List<string> listRuswords = new List<string>();

            foreach (var item in File.ReadLines(pathRus))

                listRuswords.Add(item);
            return listRuswords;
        }

    }
}


