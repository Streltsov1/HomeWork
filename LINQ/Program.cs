using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace LINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            static void ShowCollection<T>(IEnumerable<T> collection, string? title = null)
            {
                Console.Write($"{title ?? "Collection"}: ");

                foreach (var item in collection)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Завдання 1"); // завдання 1
            int[] array = { 221, 5, 46, -5, -5, 7, 9, -1, 1, 96, -6 };
            string[] citys = { "Rivne", "Kiev", "Kharkiv", "Dnipro", "Lviv" };
            string[] words = { "zdc", "fewf", "rwer", "fdgd", "rew", "fewwf", "are", "fewfw" };

            var PositiveNum = array.Where(x => x > 0).OrderBy(x => x);
            ShowCollection(PositiveNum, "Positives numbers");
            Console.WriteLine("Завдання 2");// завдання 2
            var count = array.Count(x => (x / 10) < 10 && (x / 10) > 0);
            Console.WriteLine($"Number of two-valued elements of elements {count} ");
            var avg = array.Where(x => (x / 10) < 10 && (x / 10) > 0).Average();
            Console.WriteLine($"Average {avg}");
            Console.WriteLine("Завдання 3");// завдання 3
            int[] years = { 1998, 2012, 2048, 1963, 2000, 2016, 1900, 1800 };
            var LeapYear = years.Where(x => DateTime.IsLeapYear(x)).OrderByDescending(x => x);
            ShowCollection(LeapYear, "Leap year");
            Console.WriteLine("Завдання 4");// завдання 4
            var max = array.Where(x => x % 2 == 0).Max();
            Console.WriteLine($"Max even value {max}");
            Console.WriteLine("Завдання 5");// завдання 5
            var new_city = citys.Select(x => $"{x}!!!");
            ShowCollection(new_city, "City");
            Console.WriteLine("Завдання 6");// завдання 6
            var HaveSymbol = citys.Where(x => x.Contains('k') || x.Contains('K'));
            ShowCollection(HaveSymbol, "Have symbol - k");
            Console.WriteLine("Завдання 7");// завдання 7
            var group = words.GroupBy(x => x.Length);
            foreach (var g in group)
            {
                Console.Write($"Group key: {g.Key} : ");
                foreach (var item in g)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
