using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ticketExz.models
{
    class Passenger
    {
        public const string PATH = "passenger.txt";
        public static List<Passenger> passengers = new List<Passenger>();

        public static int MaxNumber = 0;
        public int Number { get; set; }
        public string Fio { get; set; }
        public string DateBirth { get; set; }
        public List<int> ListFlights = new List<int>();


        public Passenger(string Fio, string DateBirth, List<int> ListFlights)
        {
            MaxNumber++;
            this.Number = MaxNumber;
            this.Fio = Fio;
            this.DateBirth = DateBirth;
            this.ListFlights = ListFlights;
        }

        public Passenger(int Number, string Fio, string DateBirth, List<int> ListFlights)
        {
            this.Number = Number;
            this.Fio = Fio;
            this.DateBirth = DateBirth;
            this.ListFlights = ListFlights;
        }

        public Passenger()
        {
            Number = 0;
        }

        public static void ReadPassenger()
        {
            if (!File.Exists(PATH))
                return;

            passengers.Clear();
            using (StreamReader reader = new StreamReader(PATH))
            {
                string row;
                int max = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    string[] data = row.Split('|');
                    int number = Int32.Parse(data[0]);
                    passengers.Add(new Passenger(number, data[1], data[2], data[3].Split(';').Select(Int32.Parse).ToList() )); //data[3].Split(';').ToList().Cast<int>()
                    if (MaxNumber < number)
                        max = number;
                }
                MaxNumber = max;
            }
        }

        public static void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            using (StreamWriter writer = new StreamWriter(PATH, true))
            {
                writer.WriteLine($"{passenger.Number}|{passenger.Fio}|{passenger.DateBirth}|{ string.Join(";", passenger.ListFlights) }");
            }
        }

        public static void RemovePassenger(Passenger passenger)
        {
            passengers.Remove(passenger);
            OverridePassengers();
        }
        
        public static void RemovePassenger(string fio)
        {
            Passenger passenger = passengers.Find(p => p.Fio == fio);
            passengers.Remove(passenger);
            OverridePassengers();
        }

        public static void OverridePassengers()
        {
            using (StreamWriter writer = new StreamWriter(PATH, false))
            {
                foreach (Passenger passenger in passengers)
                    writer.WriteLine($"{passenger.Number}|{passenger.Fio}|{passenger.DateBirth}|{ string.Join(";", passenger.ListFlights) }");
            }
        }

    }
}
