using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationOfPC
{
    class Assebly
    {
        public const string cpath = "a_*.txt";
        private CompanyManufacture firmManafacturer;
        private Realization itemRealization;
        private string typeCPU;
        private float frequencyCPU;
        private float ram;
        private float hdd;
        private DateTime releaseDate;

        public CompanyManufacture FirmManafacturer { get { return firmManafacturer; } set { firmManafacturer = value; } }
        public Realization ItemRealization { get { return itemRealization; } set { itemRealization = value; } }
        public string TypeCPU { get { return typeCPU; } set { typeCPU = value; } }
        public float FrequencyCPU { get { return frequencyCPU; } set { frequencyCPU = value; } }
        public float Ram { get { return ram; } set { ram = value; } }
        public float Hdd { get { return hdd; } set { hdd = value; } }
        public DateTime ReleaseDate { get { return releaseDate; } set { releaseDate = value; } }




        public Assebly(CompanyManufacture cm, Realization r, string typeCPU, float frequencyCPU, float RAM, float HDD, DateTime release)
        {
            this.firmManafacturer = cm;
            this.itemRealization = r;
            this.typeCPU = typeCPU;
            this.frequencyCPU = frequencyCPU;
            this.ram = RAM;
            this.hdd = HDD;
            this.releaseDate = release;
        }
        public void setAssebly(string cmname, string cmadress, string cmnumber, string csname, string csadress, string csnumber, DateTime rdate, uint batchpsize, uint batchprice, string typeCPU, float frequencyCPU, float RAM, float HDD, DateTime release)
        {
            this.firmManafacturer.Name = cmname;
            this.firmManafacturer.Address = cmadress;
            this.firmManafacturer.Number = cmnumber;
            this.itemRealization.Firm.Name = csname;
            this.itemRealization.Firm.Address = csadress;
            this.itemRealization.Firm.Number = csnumber;
            this.itemRealization.Date = rdate;
            this.itemRealization.BatchSize = batchpsize;
            this.itemRealization.BatchPrice = batchprice;
            this.typeCPU = typeCPU;
            this.frequencyCPU = frequencyCPU;
            this.ram = RAM;
            this.hdd = HDD;
            this.releaseDate = release;
        }

        public static void OutTitle(DirectoryInfo dirInfo)
        {
            Console.WriteLine("=== [Сборка] ===");
            Console.WriteLine("Кол-во сборок: " + NumberOfAsseblies(dirInfo));
        }
        public static int NumberOfAsseblies(DirectoryInfo dirInfo)
        {

            int i = 0;
            if (dirInfo.Exists)
            {
                i += dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly).Length;
            }
            return i;
        }

        public void GetAssebly()
        {
            Console.WriteLine("Фирмы-изготовитель: ");
            Console.WriteLine("---Название фирмы: " + firmManafacturer.Name);
            Console.WriteLine("---Адрес: " + firmManafacturer.Address);
            Console.WriteLine("---Номер телефона: +" + firmManafacturer.Number);
            Console.WriteLine();
            Console.WriteLine("Реализация: ");
            Console.WriteLine("---Название фирмы: " + itemRealization.Firm.Name);
            Console.WriteLine("---Адрес: " + itemRealization.Firm.Address);
            Console.WriteLine("---Номер телефона: +" + itemRealization.Firm.Number);
            Console.WriteLine("---Дата реализации: " + itemRealization.Date);
            Console.WriteLine("---Объем партии : " + itemRealization.BatchSize);
            Console.WriteLine("---Цена партии : " + itemRealization.BatchPrice);
            Console.WriteLine();
            Console.WriteLine("Тип процессора: " + typeCPU);
            Console.WriteLine("Тактовая частота: " + frequencyCPU);
            Console.WriteLine("Объем ОЗУ: " + ram);
            Console.WriteLine("Объем жесткого диска: " + hdd);
            Console.WriteLine("Дата выпуска: " + releaseDate);

            Console.WriteLine();
        }
        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path + "//a_" + FirmManafacturer.Name + ItemRealization.Firm.Name + ItemRealization.Date.Year + ItemRealization.Date.Month + ReleaseDate.Year + ItemRealization.Date.Month + ItemRealization.Date.Day + ".txt"))
            {
                sw.WriteLine(firmManafacturer.Name);
                sw.WriteLine(firmManafacturer.Address);
                sw.WriteLine(firmManafacturer.Number);
                sw.WriteLine(itemRealization.Firm.Name);
                sw.WriteLine(itemRealization.Firm.Address);
                sw.WriteLine(itemRealization.Firm.Number);
                sw.WriteLine(itemRealization.Date);
                sw.WriteLine(itemRealization.BatchSize);
                sw.WriteLine(itemRealization.BatchPrice);
                sw.WriteLine(typeCPU);
                sw.WriteLine(frequencyCPU);
                sw.WriteLine(ram);
                sw.WriteLine(hdd);
                sw.WriteLine(releaseDate);
                sw.Close();
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
                            Console.WriteLine("=== [Сборка номер " + i + "] ===");
                            Console.WriteLine("Фирмы-изготовитель: ");
                            Console.WriteLine("---Название фирмы: " + ffstream.ReadLine());
                            Console.WriteLine("---Адрес: " + ffstream.ReadLine());
                            Console.WriteLine("---Номер телефона: +" + ffstream.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("Реализация: ");
                            Console.WriteLine("---Название фирмы: " + ffstream.ReadLine());
                            Console.WriteLine("---Адрес: " + ffstream.ReadLine());
                            Console.WriteLine("---Номер телефона: +" + ffstream.ReadLine());
                            Console.WriteLine("---Дата реализации: " + DateTime.Parse(ffstream.ReadLine()));
                            Console.WriteLine("---Объем партии : " + int.Parse(ffstream.ReadLine()));
                            Console.WriteLine("---Цена партии : " + int.Parse(ffstream.ReadLine()));
                            Console.WriteLine();
                            Console.WriteLine("Тип процессора: " + ffstream.ReadLine());
                            Console.WriteLine("Тактовая частота: " + float.Parse(ffstream.ReadLine()));
                            Console.WriteLine("Объем ОЗУ: " + float.Parse(ffstream.ReadLine()));
                            Console.WriteLine("Объем жесткого диска: " + float.Parse(ffstream.ReadLine()));
                            Console.WriteLine("Дата выпуска: " + DateTime.Parse(ffstream.ReadLine()));
                            Console.WriteLine();
                        }

                    }
                }
                i++;
            }
        }
        public void OutAllAsseblies(DirectoryInfo dirInfo)
        {
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                Console.WriteLine("=== [Сборка номер " + i + "] ===");

                using (StreamReader fstream = new StreamReader(file.FullName))
                {
                    Console.WriteLine("Фирмы-изготовитель: ");
                    Console.WriteLine("---Название фирмы: " + fstream.ReadLine());
                    Console.WriteLine("---Адрес: " + fstream.ReadLine());
                    Console.WriteLine("---Номер телефона: +" + fstream.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Реализация: ");
                    Console.WriteLine("---Название фирмы: " + fstream.ReadLine());
                    Console.WriteLine("---Адрес: " + fstream.ReadLine());
                    Console.WriteLine("---Номер телефона: +" + fstream.ReadLine());
                    Console.WriteLine("---Дата реализации: " + DateTime.Parse(fstream.ReadLine()));
                    Console.WriteLine("---Объем партии : " + int.Parse(fstream.ReadLine()));
                    Console.WriteLine("---Цена партии : " + int.Parse(fstream.ReadLine()));
                    Console.WriteLine();
                    Console.WriteLine("Тип процессора: " + fstream.ReadLine());
                    Console.WriteLine("Тактовая частота: " + float.Parse(fstream.ReadLine()));
                    Console.WriteLine("Объем ОЗУ: " + float.Parse(fstream.ReadLine()));
                    Console.WriteLine("Объем жесткого диска: " + float.Parse(fstream.ReadLine()));
                    Console.WriteLine("Дата выпуска: " + DateTime.Parse(fstream.ReadLine()));
                    Console.WriteLine();
                }
                i++;
            }
        }
        public void ChooseAssebly(int toChoose, DirectoryInfo dirInfo)
        {
            var files = dirInfo.GetFiles(cpath, SearchOption.TopDirectoryOnly);
            int i = 1;
            foreach (var file in files)
            {
                if (i == toChoose)
                {
                    Console.WriteLine("[Сборка номер " + i + "] - выбрана!");
                    using (StreamReader fstream = new StreamReader(file.FullName))
                    {
                        setAssebly(fstream.ReadLine(), fstream.ReadLine(), fstream.ReadLine(), fstream.ReadLine(), fstream.ReadLine(), fstream.ReadLine(), DateTime.Parse(fstream.ReadLine()), uint.Parse(fstream.ReadLine()), uint.Parse(fstream.ReadLine()), fstream.ReadLine(), float.Parse(fstream.ReadLine()), float.Parse(fstream.ReadLine()), float.Parse(fstream.ReadLine()), DateTime.Parse(fstream.ReadLine()));
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
                if (i == toDelete)
                {
                    Console.WriteLine("[Сборка номер " + i + "] - удалена!");
                    file.Delete();
                }
                i++;
            }
        }
    }
}
