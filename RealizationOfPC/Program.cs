using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationOfPC
{
    class Program
    {
        static public string CompanyManufacturePath = "CompanyManufacture";
        static public string CompanySalesPath = "CompanySales";
        static public string AssebliesPath = "Asseblies";

        static CompanyManufacture CM = new CompanyManufacture("", "", "");
        static CompanySales CS = new CompanySales("", "", "");
        static DateTime dateR = new DateTime(2020, 1, 1);
        static DateTime dateA = new DateTime(2020, 1, 1);
        static Realization R = new Realization(0, 0, dateR, CS);
        static Assebly A = new Assebly(CM, R, "none", 0, 0, 0, dateA);

        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(CompanyManufacturePath);
            if (!dirInfo.Exists) dirInfo.Create();

            dirInfo = new DirectoryInfo(CompanySalesPath);
            if (!dirInfo.Exists) dirInfo.Create();

            dirInfo = new DirectoryInfo(AssebliesPath);
            if (!dirInfo.Exists) dirInfo.Create();

            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("1)Фирмы-изготовители\n" +
                  "2)Фирмы-реализаторы\n\n" +
                  "3)Реализации\n\n" +
                  "4)Сборки\n\n" +
                  "5)Закрыть");
            Console.WriteLine();
            Console.Write(">");

            int i;
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch
            {
                i = -1;
            }

            switch (i)
            {
                case 1:
                    CompanyManufactures();
                    break;
                case 2:
                    CompanySaleses();
                    break;
                case 3:
                    if (CS.Name == "none")
                    {
                        Console.WriteLine("Выберите фирму - реализатор");
                        System.Threading.Thread.Sleep(650);
                        Console.Clear();
                        Menu();
                    }
                    Realizations();
                    break;
                case 4:
                    Asseblies();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Вы нажали что-то другое...");
                    System.Threading.Thread.Sleep(300);
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        static void CompanyManufactures()
        {
            Console.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(CompanyManufacturePath);
            while (true)
            {
                

                CompanyManufacture.OutTitle(dirInfo);
                Console.WriteLine();
                CM.GetCompany();
                switch (Vibor())
                {
                    case 0:
                        if (CM.Name == "none")
                        {
                            Console.WriteLine("Выберите фирму - изготовитель");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            CompanyManufactures();
                        }
                        int i = 0;
                        Console.Clear();
                        Console.WriteLine("1)Название");
                        Console.WriteLine("2)Адресс");
                        Console.WriteLine("3)Номер");
                        try
                        {
                            i = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        
                        File.Delete(dirInfo.FullName + "//cm_" + CM.Name+".txt");
                        switch (i)
                        {
                            case 1:
                                CM.Name = Console.ReadLine();
                                break;
                            case 2:
                                CM.Address = Console.ReadLine();
                                break;
                            case 3:
                                CM.Number = Console.ReadLine();
                                break;
                            default:
                                break;
                        }
                        CM.WriteFile(dirInfo.FullName);
                        break;
                    case 1:
                        Console.Clear();
                        CM.OutAllCompanies(dirInfo);
                        PressKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите что искать:");
                        CM.Find(Console.ReadLine(),dirInfo);
                        PressKey();
                        break;
                    case 3:
                        Console.Clear();
                        CM.OutAllCompanies(dirInfo);
                        Console.WriteLine("Введите номер фирмы:");
                        CM.ChooseCompany(Vvod(dirInfo), dirInfo);
                        Reset();
                        PressKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Название фирмы:");
                        CM.Name = Console.ReadLine();

                        Console.Write("Адресс фирмы:");
                        CM.Address = Console.ReadLine();

                        Console.Write("Номер телефона фирмы: +");
                        CM.Number = Console.ReadLine();

                        CM.WriteFile(dirInfo.FullName);
                        PressKey();
                        break;
                    case 5:
                        Console.Clear();
                        CM.OutAllCompanies(dirInfo);
                        Console.WriteLine("Введите номер фирмы:");
                        CompanyManufacture.Delete(Vvod(dirInfo), dirInfo);
                        PressKey();
                        break;
                    case 9:
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Вы нажали что-то другое...");
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        CompanyManufactures();
                        break;
                }
            }
        }
        static void CompanySaleses()
        {
            Console.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(CompanySalesPath);
            while (true)
            {
                CompanySales.OutTitle(dirInfo);
                Console.WriteLine();
                CS.GetCompany();
                switch (Vibor())
                {
                    case 0:
                        if (CS.Name == "none")
                        {
                            Console.WriteLine("Выберите фирму - реализатор");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            CompanySaleses();
                        }
                        int i = 0;
                        Console.Clear();
                        Console.WriteLine("1)Название");
                        Console.WriteLine("2)Адресс");
                        Console.WriteLine("3)Номер");
                        try
                        {
                            i = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        File.Delete(dirInfo.FullName + "//cm_" + CS.Name + ".txt");
                        switch (i)
                        {
                            case 1:
                                CS.Name = Console.ReadLine();
                                break;
                            case 2:
                                CS.Address = Console.ReadLine();
                                break;
                            case 3:
                                CS.Number = Console.ReadLine();
                                break;
                            default:
                                break;
                        }
                        CS.WriteFile(dirInfo.FullName);
                        break;
                    case 1:
                        Console.Clear();
                        CS.OutAllCompanies(dirInfo);
                        PressKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите что искать:");
                        CS.Find(Console.ReadLine(), dirInfo);
                        PressKey();
                        break;
                    case 3:
                        Console.Clear();
                        CS.OutAllCompanies(dirInfo);
                        Console.WriteLine("Введите номер фирмы:");
                        CS.ChooseCompany(Vvod(dirInfo), dirInfo);
                        Reset();
                        PressKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Название фирмы:");
                        CS.Name = Console.ReadLine();

                        Console.Write("Адресс фирмы:");
                        CS.Address = Console.ReadLine();

                        Console.Write("Номер телефона фирмы: +");
                        CS.Number = Console.ReadLine();

                        CS.WriteFile(dirInfo.FullName);
                        PressKey();
                        break;
                    case 5:
                        Console.Clear();
                        CS.OutAllCompanies(dirInfo);
                        Console.WriteLine("Введите номер фирмы:");
                        CompanySales.Delete(Vvod(dirInfo), dirInfo);
                        PressKey();
                        break;
                    case 9:
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Вы нажали что-то другое...");
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        CompanySaleses();
                        break;
                }
            }
        }
        static void Realizations()
        {
            Console.Clear();
            while (true)
            {
                if (CS.Name == "")
                {
                    Console.WriteLine("Выберите фирму - реализатор");
                    System.Threading.Thread.Sleep(650);
                    Console.Clear();
                    Menu();
                }
                Realization.OutTitle();
                Console.WriteLine();
                R.GetRelease();
                Console.WriteLine("1)Установить реализацию\n" +
                    "\n9)Назад");
                int i = 0;
                try
                {
                    i = int.Parse(Console.ReadLine());
                }
                catch
                {
                    i = 0;
                }
                
                switch (i)
                {
                    case 1:
                        Reset();
                        Console.Clear();
                        try
                        {
                            Console.Write("Дата реализации:");
                            R.Date = DateTime.Parse(Console.ReadLine());

                            Console.Write("Объем партии:");
                            R.BatchSize = uint.Parse(Console.ReadLine());

                            Console.Write("Цена партии:");
                            R.BatchPrice = uint.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("err in Realization menu");
                        }
                        PressKey();
                        break;
                    case 9:
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Вы нажали что-то другое...");
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        Realizations();
                        break;
                }
            }
        }
        static void Asseblies()
        {

            Console.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(AssebliesPath);
            while (true)
            {
                Assebly.OutTitle(dirInfo);
                Console.WriteLine();
                A.GetAssebly();
                switch (Vibor())
                {
                    case 0:
                        if (R.BatchSize == 0)
                        {
                            Console.WriteLine("Установите реализацию");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            Menu();
                        }
                        if (CM.Name == "")
                        {
                            Console.WriteLine("Выберите фирму - изготовитель");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            Menu();
                        }
                        int i = 0;
                        Console.Clear();
                        Console.WriteLine("1)Тип процессора");
                        Console.WriteLine("2)Тактовая частота");
                        Console.WriteLine("3)Объем ОЗУ");
                        Console.WriteLine("4)Объем жесткого диска");
                        Console.WriteLine("5)Дата выпуска");
                        try
                        {
                            i = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка ввода");
                        }
                        switch (i)
                        {
                            case 1:
                                try
                                {
                                    A.TypeCPU = Console.ReadLine();
                                }
                                catch
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    Asseblies();
                                }
                                break;
                            case 2:
                                try
                                {
                                    float value = float.Parse(Console.ReadLine());
                                    if(value > 0)
                                    {
                                        A.FrequencyCPU = value;
                                    }
                                    
                                }
                                catch
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    Asseblies();
                                }
                                break;
                            case 3:
                                try
                                {
                                    float value = float.Parse(Console.ReadLine());
                                    if (value > 0)
                                    {
                                        A.Ram = value;
                                    }
                                   
                                }
                                catch
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    Asseblies();
                                }
                                break;
                            case 4:  
                                try
                                {
                                 
                                    float value = float.Parse(Console.ReadLine());
                                    if (value > 0)
                                    {
                                        A.Hdd = value;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    Asseblies();
                                }
                                break;
                            case 5:
                                try
                                {
                                    A.ReleaseDate = DateTime.Parse(Console.ReadLine()); ;
                                }
                                catch
                                {
                                    Console.WriteLine("Ошибка ввода");
                                    Asseblies();
                                }
                                break;
                            default:
                                break;
                        }
                        File.Delete(dirInfo.FullName + "//a_" + A.FirmManafacturer.Name + A.ItemRealization.Firm.Name + A.ItemRealization.Date.Year + A.ItemRealization.Date.Month + A.ReleaseDate.Year + A.ItemRealization.Date.Month + A.ItemRealization.Date.Day + ".txt");
                        A.WriteFile(dirInfo.FullName);
                        break;
                    case 1:
                        Console.Clear();
                        A.OutAllAsseblies(dirInfo);
                        PressKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Введите что искать:");
                        A.Find(Console.ReadLine(), dirInfo);
                        PressKey();
                        break;
                    case 3:
                        Console.Clear();
                        A.OutAllAsseblies(dirInfo);
                        Console.WriteLine("Введите номер фирмы:");
                        A.ChooseAssebly(Vvod(dirInfo), dirInfo);
                        PressKey();
                        break;
                    case 4:
                        if (R.BatchSize == 0)
                        {
                            Console.WriteLine("Установите реализацию");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            Menu();
                        }
                        if (CM.Name == "")
                        {
                            Console.WriteLine("Выберите фирму - изготовитель");
                            System.Threading.Thread.Sleep(650);
                            Console.Clear();
                            Menu();
                        }
                        Console.Clear();
                        Console.Write("Тип процессора:");
                        A.TypeCPU = Console.ReadLine();

                        Console.Write("Тактовая частота(MHz):");
                        A.FrequencyCPU = float.Parse(Console.ReadLine());

                        Console.Write("Объем ОЗУ(MB):");
                        A.Ram = float.Parse(Console.ReadLine());

                        Console.Write("Объем жесткого диска(MB):");
                        A.Hdd = float.Parse(Console.ReadLine());

                        Console.Write("Дата выпуска:");
                        A.ReleaseDate = DateTime.Parse(Console.ReadLine());

                        A.WriteFile(dirInfo.FullName);
                        PressKey();
                        break;
                    case 5:
                        Console.Clear();
                        A.OutAllAsseblies(dirInfo);
                        Console.WriteLine("Введите номер сборки:");
                        Assebly.Delete(Vvod(dirInfo), dirInfo);
                        PressKey();
                        break;
                    case 9:
                        Console.Clear();
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Вы нажали что-то другое...");
                        System.Threading.Thread.Sleep(300);
                        Console.Clear();
                        Asseblies();
                        break;
                }
            }
        }


        // Вспомогательные функции
        static int Vibor()
        {
            Console.WriteLine("0)Редактировать");
            Console.WriteLine();
            Console.WriteLine("1)Вывести всё");
            Console.WriteLine("2)Найти по запросу");
            Console.WriteLine();
            Console.WriteLine("3)Выбрать");
            Console.WriteLine();
            Console.WriteLine("4)Добавить");
            Console.WriteLine("5)Удалить");
            Console.WriteLine();
            Console.WriteLine("9)Назад");
            Console.Write(">");

            int i = -1;
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch
            {
                i = -1;
            }

            return i;

        }
        static void PressKey()
        {
            Console.WriteLine("Нажмите клавишу что бы продолжить...");
            Console.ReadKey();
            Console.Clear();
        }
        static int Vvod(DirectoryInfo dirInfo)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if ((number < 0) && (number > (CompanyManufacture.NumberOfFirms(dirInfo) + 1)))
                {
                    Console.WriteLine("Номер фирмы вышел за предел доступных фирм!");
                    System.Threading.Thread.Sleep(500);
                }
                return number;
            }
            catch
            {
                Console.WriteLine("Ошибка ввода");
                return -1;
            }
            
        }

        static void Reset()
        {
            dateR = new DateTime(2020, 1, 1);
            dateA = new DateTime(2020, 1, 1);
            A = new Assebly(CM, R, "none", 0, 0, 0, dateA);
        }
    }
}
