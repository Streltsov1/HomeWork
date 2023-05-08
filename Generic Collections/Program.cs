using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_Collections
{
    class PhoneBook
    {
        private Dictionary<string, long> Phone = new Dictionary<string, long>();
        public void AddNew(string name = null, long number = 0)
        {
            if (name == null)
            {
                Console.Write("Введіть ім'я: ");
                name = Console.ReadLine();
            }
            if (number < 380000000000 || number >= 380999999999)
            {
                do
                {
                    Console.Write("Введіть номер телефону (приклад: 380123456789): ");
                    number = long.Parse(Console.ReadLine());
                } while (number < 380000000000 || number >= 380999999999);
            }
            Phone.Add(name, number);
        }
        public void ChangeNumber(string name)
        {
            long number = 0;
            do
            {
                Console.Write("Введіть новий номер телефону (приклад: 380123456789): ");
                number = long.Parse(Console.ReadLine());
            } while (number < 380000000000 || number >= 380999999999);
            Phone[name] = number;
        }
        public long Find(string name)
        {
                return Phone[name];
        }
        public void Delete(string name)
        {
            Phone.Remove(name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //завдання - 1
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Завдання 1");
            ArrayList arrayList = new ArrayList { 5, 67, false, 654, 6.5, 85.24, true };
            List<int> ints = new List<int>();
            List<bool> bools = new List<bool>();
            List<double> doubles = new List<double>();
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i] is int)
                    ints.Add((int)arrayList[i]);
                else if (arrayList[i] is bool)
                    bools.Add((bool)arrayList[i]);
                else if (arrayList[i] is double)
                    doubles.Add((double)arrayList[i]);
            }
            foreach (var item in ints)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in bools)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in doubles)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            //завдання -2
            Console.WriteLine("Завдання 2");
            List<string> list = new List<string> { "Mgrgeg", "Gergerg", "Bregetve", "Aregetve" };
            int max = 0;
            list.Sort();
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Length > list[max].Length)
                    max = i;
            }
            Console.WriteLine($"Найдовше слово: {list[max]}");
            //завдання -3
            Console.WriteLine("Завдання 3");
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.AddNew("Oleg", 380741258963);
            phoneBook.AddNew("Artem", 380954744702);
            phoneBook.AddNew("Mama", 380987456321);
            phoneBook.AddNew("Misha", 380673066912);
            try
            {
                phoneBook.ChangeNumber("Oleg");
                Console.WriteLine(phoneBook.Find("Oleg"));
                phoneBook.Delete("Oleg");
                Console.WriteLine(phoneBook.Find("Oleg"));
            }
            catch (Exception)
            {
                Console.WriteLine("Незнайденно номер з таким ім'ям");
            }
        }
    }
}
