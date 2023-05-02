using System;
using System.Text;
using System.Linq;

namespace C_Sharp_String
{
    public static class Revers
    {
        public static string reverse(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            // завдання 1
            string text = "12345";
            string reverse = text.reverse();
            Console.WriteLine($"Нормальне слово: {text}\nСлово в зворотньому порядку: {reverse}");
            // завдання 2
            Console.Write("Введіть текст: ");
            text = Console.ReadLine();
            try
            {
                Console.WriteLine(text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            }
            catch
            {
                Console.WriteLine("Не знайдено точок у строці");
            }
            // завдання 3
            Console.Write("Введіть слово: ");
            text = Console.ReadLine();
            reverse = text.reverse();
            if (text.ToLower() == reverse.ToLower())
                Console.WriteLine("Це слово паліндром");
            else
                Console.WriteLine("Це слово не є паліндромом");
            // завдання 4
            Console.Write("Введіть текст: ");
            text = Console.ReadLine();
            double upper = 0;
            double lower = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    upper++;
                else if (char.IsLower(text[i]))
                    lower++;
            }
            Console.WriteLine($"Великих літер {100.0 / text.Length * upper}%, Малих літер {100.0 / text.Length * lower}%");
            // завдання 5
            Console.Write("Введіть текст: ");
            text = Console.ReadLine();
            string[] string_arr = text.Split();
            int index = 0;
            do
            {
                Console.Write($"Введіть номер слова, номер повинен бути в межах(1 - {string_arr.Length}): ");
                index = int.Parse(Console.ReadLine());
            } while (index < 1 || index > string_arr.Length);
            Console.WriteLine(string_arr[index - 1].First());
            // завдання 6
            Console.Write("Введіть текст: ");
            text = Console.ReadLine();
            string_arr = text.Split();
            for (int i = 0; i < string_arr.Length; i++)
            {
                if (string_arr[i].Length > 5)
                {
                    for (int j = 5; j < string_arr[i].Length; j++)
                    {
                        string_arr[i] = string_arr[i].Remove(j, 1).Insert(j, "$");
                    }
                }
            }
            foreach (var item in string_arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
