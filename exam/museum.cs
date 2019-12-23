using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class museum
    {
        public List<artWorck> listOfWorcks { get; set; }
        public museum()
        {
            listOfWorcks = new List<artWorck>();
        }
        public museum(artWorck[] arr) : this()
        {
            foreach (artWorck aw in arr)
                listOfWorcks.Add(aw);
        }

        public void Add(artWorck obj)
        {
            listOfWorcks.Add(obj);
        }
        public void Show()
        {
            foreach (var aw in listOfWorcks)
                Console.WriteLine(aw.Name + ":" + aw.Creator + ":" + aw.Date);
        }

        public void saveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (artWorck aw in listOfWorcks)
                {
                    sw.WriteLine(aw.Creator + ":" + aw.Name + ":" + aw.Date);
                }
            }
            Console.WriteLine("файл записан");
        }

        public void readFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string str = sr.ReadLine();
                while (str != null)
                {
                    string[] astr = str.Split(':');
                    int yyy = Convert.ToInt32(astr[2].Substring(6, 4));
                    int mmm = Convert.ToInt32(astr[2].Substring(3, 2));
                    int dd = Convert.ToInt32(astr[2].Substring(0, 2));
                    DateTime newDate = new DateTime(yyy, mmm, dd);
                    listOfWorcks.Add(new artWorck { Creator = astr[0], Name = astr[1], Date = newDate });
                    str = sr.ReadLine();
                }
            }
        }
        public void Sort(int mode)
        {
            switch (mode)
            {
                case 1:
                    listOfWorcks.Sort((x, y) => x.Creator.CompareTo(y.Creator));
                    break;
                case 2:
                    listOfWorcks.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
                case 3:
                    listOfWorcks.Sort((x, y) => x.Date.CompareTo(y.Date));
                    break;
                default:
                    Console.WriteLine("invalid arg");
                    break;
            }

        }
        public void countWorksByCreators()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (artWorck aw in listOfWorcks)
            {
                if (!dic.ContainsKey(aw.Creator)) dic.Add(aw.Creator, 1);
                else dic[aw.Creator]++;
            }
            foreach (var x in dic)
                Console.WriteLine(x.Key + " = " + x.Value);
        }
    }
}
