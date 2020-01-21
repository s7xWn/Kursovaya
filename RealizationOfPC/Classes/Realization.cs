using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealizationOfPC
{
    class Realization
    {
        private CompanySales firm;
        private DateTime date;
        private uint batchSize;
        private uint batchPrice;

        public uint BatchSize { get { return batchSize; } set { batchSize = value; } }
        public uint BatchPrice { get { return batchPrice; } set { batchPrice = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public CompanySales Firm { get { return firm; } set { firm = value; } }

        public Realization(uint batchSize, uint batchPrice,DateTime date, CompanySales firm)
        {
            this.firm = firm;
            this.date = date;
            this.batchPrice = batchPrice;
            this.batchSize = batchSize;
        }
        public static void OutTitle()
        {
            Console.WriteLine("=== [Реализации] ===");
        }
        public void GetRelease()
        {
            Console.WriteLine("Название фирмы: " + firm.Name);
            Console.WriteLine("Дата реализации: " + date);
            Console.WriteLine("Объем партии : " + batchSize);
            Console.WriteLine("Цена партии : " + batchPrice);
            Console.WriteLine();
        }
        public void SetRelease(string firm, DateTime date, uint batchPrice, uint batchSize)
        {
            this.firm.Name = firm;
            this.date = date;
            this.batchPrice = batchPrice;
            this.batchSize = batchSize;
        }
    }   
}
