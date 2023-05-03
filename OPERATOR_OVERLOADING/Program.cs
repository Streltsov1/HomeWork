using System;

namespace OPERATOR_OVERLOADING
{
    class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public Time()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
        }
        public Time(int hours, int minuts, int seconds)
        {
            Hours = hours < 0 ? 0 : hours > 23 ? hours%23 : hours;
            Minutes = minuts < 0 ? 0 : minuts > 59 ? minuts%59 : minuts;
            Seconds = seconds < 0 ? 0 : seconds > 59 ? seconds%59 : seconds; ;
        }
        public Time(int seconds)
        {
            Hours = seconds / 3600;
            Minutes = seconds % 3600 / 60;
            Seconds = seconds % 3600 % 60;
        }
        public override string ToString()
        {
            string time = "";
            if(Hours < 10)
                time += $"0{Hours}:";
            else
                time += $"{Hours}:";
            if(Minutes < 10)
                time += $"0{Minutes}:";
            else
                time += $"{Minutes}:";
            if (Seconds < 10)
                time += $"0{Seconds}";
            else
                time += $"{Seconds}";
            return time;
        }
        public void Reset()
        {
            DateTime time = DateTime.Now;
            Hours = time.Hour;
            Minutes = time.Minute;
            Seconds = time.Second;
        }
        public static Time operator --(Time t)
        {
            --t.Seconds;
            return t;
        }
        public static Time operator ++(Time t)
        {
            ++t.Seconds;
            return t;
        }
        public static bool operator <(Time t1, Time t2)
        {
            return t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds < t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        }
        public static bool operator >(Time t1, Time t2)
        {
            return t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds > t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        }
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds == t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        }
        public static bool operator !=(Time t1, Time t2)
        {
            return t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds != t2.Hours * 3600 + t2.Minutes * 60 + t2.Seconds;
        }
        public static bool operator true(Time t)
        {
            DateTime t1 = DateTime.Now;
            return t.Hours * 3600 + t.Minutes * 60 + t.Seconds > t1.Hour * 3600 + t1.Minute * 60 + t1.Second;
        }
        public static bool operator false(Time t)
        {
            DateTime t1 = DateTime.Now;
            return t.Hours * 3600 + t.Minutes * 60 + t.Seconds < t1.Hour * 3600 + t1.Minute * 60 + t1.Second;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Time time = new Time(25,23,66);
            Time time1 = new Time(36666);
            Console.WriteLine(time.ToString());
            Console.WriteLine(time1.ToString());
            time.Reset();
            Console.WriteLine(time.ToString());
            time++;
            Console.WriteLine(time.ToString());
            if(time1 > time)
                Console.WriteLine("Time1 > Time");
            else
                Console.WriteLine("Time1 < Time");
            if(time1 == time)
                Console.WriteLine("Time1 == Time");
            else
                Console.WriteLine("Time1 != Time");
            if(time1)
                Console.WriteLine("it is future");
            else
                Console.WriteLine("it is past");

        }
    }
}
