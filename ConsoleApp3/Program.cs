using System;

namespace ConsoleApp3
{
    enum VagonType { Tank = 0, Passenger, Restaurant }
    struct Vagon
    {
        readonly private int number;
        public int Number => number;
        private const int seatsNumber = 25;
        public int SeatsNumber => seatsNumber;
        public int Passengers { get; set; }
        public VagonType Type { get; set; }
        public Vagon(int num, int passenger, VagonType type)
        {
            number = num;
            Passengers = passenger;
            Type = type;
        }
        public int FreeSeats() => seatsNumber - Passengers;
    }
    enum TrainType { Freight=0, Passenger, Mail_Baggage }
    class Train
    {
        readonly private int number;
        public int Number => number;
        public TrainType Type { get; set; }
        public string RouteName { get; set; }
        public DateTime DispatchDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        private Vagon[] vagons;
        private int vagonNumber = 0;
        public int VagonNumber => vagonNumber;

        public Train(int num, TrainType type, string routeName, DateTime dispatch, DateTime arrival)
        {
            number = num;
            Type = type;
            RouteName = routeName;
            DispatchDate = dispatch;
            ArrivalDate = arrival;
        }
        public void AddVagon(Vagon vagon)
        {
            vagonNumber++;
            Vagon[] new_vagon = new Vagon[vagonNumber];
            for (int i = 0; i < vagonNumber - 1; i++)
            {
                new_vagon[i] = vagons[i];
            }
            new_vagon[vagonNumber - 1] = vagon;
            vagons = new_vagon;
        }
        public TimeSpan TimeLeft() => ArrivalDate.Subtract(DispatchDate);
        public override string ToString()
        {
            return $"This is {Type} train #{number} current route {RouteName}, time of dispatch {DispatchDate}, time of arrival {ArrivalDate}, number of vagons {vagonNumber}";
        }
        public int FreeSeats()
        {
            int free = 0;
            for (int i = 0; i < vagonNumber; i++)
            {
                free += vagons[i].FreeSeats();
            }
            return free;
        }
        public double AvgPassengers()
        {
            double avg = 0;
            for (int i = 0; i < vagonNumber; i++)
            {
                avg += vagons[i].Passengers;
            }
            return avg/VagonNumber;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vagon vagon1 = new Vagon(1, 10, VagonType.Passenger);
            Vagon vagon2 = new Vagon(2, 20, VagonType.Passenger);
            Vagon vagon3 = new Vagon(3, 3, VagonType.Restaurant);
            Vagon vagon4 = new Vagon(4, 0, VagonType.Tank);
            Train train = new Train(123, TrainType.Passenger,"Rivne-Kiyv", DateTime.Now, DateTime.Now.AddHours(10));
            train.AddVagon(vagon1);
            train.AddVagon(vagon2);
            train.AddVagon(vagon3);
            train.AddVagon(vagon1);
            train.AddVagon(vagon1);
            train.AddVagon(vagon3);
            Console.WriteLine(train.ToString());
            Console.WriteLine($"time to arrival {train.TimeLeft() }");
            Console.WriteLine($"Number of vagons {train.VagonNumber}, free seats {train.FreeSeats()}, average number of passenger {train.AvgPassengers()}");
            train.RouteName = "Rivne-Dnipro";
            train.ArrivalDate = DateTime.Now.AddHours(15);
            Console.WriteLine(train.ToString());

        }
    }
}
