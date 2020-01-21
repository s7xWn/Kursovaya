using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationOfPC
{
    
    class CompanyManufacture
    {
        public const string cpath = "cm_*.txt";
        private string name;
        private string address;
        private string number;

        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Number { get { return number; } set { number = value; } }

        public CompanyManufacture(string name, string address, string number)
        {
            this.name = name;
            this.address = address;
            this.number = number;
        }

        public void GetCompany()
        {
            Console.WriteLine("Название фирмы: " + name);
            Console.WriteLine("Адрес: " + address);
            Console.WriteLine("Номер телефона: +" + number);
            Console.WriteLine();
        }
        public void SetCompany(string name, string address, string number)
        {
            this.name = name;
            this.address = address;
            this.number = number;
        }
        public void ChooseCompany(int toChoose, DirectoryInfo dirInfo)
        {
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                if (i == toChoose)
                {
                    Console.WriteLine("[Фирма номер " + i + "] - выбрана!");
                    using (StreamReader fstream = new StreamReader(file.FullName))
                    {
                        SetCompany(fstream.ReadLine(), fstream.ReadLine(), fstream.ReadLine());
                    }
                }
                i++;
            }
        }
        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path + "//cm_" + name + ".txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(address);
                sw.WriteLine(number);
                sw.Close();
            }   
        }
        public static void OutTitle(DirectoryInfo dirInfo)
        {
            Console.WriteLine("=== [Фирма - изготовитель] ===");
            Console.WriteLine("Кол-во фирм: " + NumberOfFirms(dirInfo));
        }
        public static int NumberOfFirms(DirectoryInfo dirInfo)
        {

            int i = 0;
            if (dirInfo.Exists)
            {
                i += dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly).Length;
            }
            return i;
        }

        public void OutAllCompanies(DirectoryInfo dirInfo)
        {
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                Console.WriteLine("=== [Фирма номер " + i + "] ===");

                using (StreamReader fstream = new StreamReader(file.FullName))
                {
                    Console.WriteLine("Название фирмы: " + fstream.ReadLine());
                    Console.WriteLine("Адрес: " + fstream.ReadLine());
                    Console.WriteLine("Номер телефона: +" + fstream.ReadLine());
                    Console.WriteLine();
                }
                i++;
            }
        }

        public void Find(string toFind, DirectoryInfo dirInfo)
        {
            string text;
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                using (StreamReader fstream = new StreamReader(file.FullName))
                {
                    text = fstream.ReadToEnd();
                    if (text.Contains(toFind))
                    {
                        using (StreamReader ffstream = new StreamReader(file.FullName))
                        {
                            Console.WriteLine("=== [Фирма номер " + i + "] ===");
                            Console.WriteLine("Название фирмы: " + ffstream.ReadLine());
                            Console.WriteLine("Адрес: " + ffstream.ReadLine());
                            Console.WriteLine("Номер телефона: +" + ffstream.ReadLine());
                            Console.WriteLine();
                        }
                        
                    }
                }
                i++;
            }
        }
        public static void Delete(int toDelete, DirectoryInfo dirInfo)
        {
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                if(i == toDelete)
                {
                    Console.WriteLine("[Фирма номер " + i + "] - удалена!");
                    file.Delete();
                }
                i++;
            }
        }
    }
}
