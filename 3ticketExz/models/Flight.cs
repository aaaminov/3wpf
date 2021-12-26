using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ticketExz.models
{
    class Flight
    {
        public const string PATH = "flight.txt";
        public static List<Flight> flights = new List<Flight>();

        public static int MaxNumber = 0;
        public int Number { get; set; }
        public string Name { get; set; }
        public string DateDeparture { get; set; }
        public string DateArrival { get; set; }

        public Flight(string Name, string DateDeparture, string DateArrival)
        {
            MaxNumber++;
            this.Number = MaxNumber;
            this.Name = Name;
            this.DateDeparture = DateDeparture;
            this.DateArrival = DateArrival;
        }
        
        public Flight(int Number, string Name, string DateDeparture, string DateArrival)
        {
            this.Number = Number;
            this.Name = Name;
            this.DateDeparture = DateDeparture;
            this.DateArrival = DateArrival;
        }

        public static void ReadFlights()
        {
            if (!File.Exists(PATH))
                return;

            flights.Clear();
            using (StreamReader reader = new StreamReader(PATH))
            {
                string row;
                int max = 0;
                while ((row = reader.ReadLine()) != null)
                {
                    string[] data = row.Split('|');
                    int number = Int32.Parse(data[0]);
                    flights.Add(new Flight(number, data[1], data[2], data[3]));
                    if (MaxNumber < number)
                        max = number;
                }
                MaxNumber = max;
            }
        }

        public static void AddFlights(Flight flight)
        {
            flights.Add(flight);
            using (StreamWriter writer = new StreamWriter(PATH, true))
            {
                writer.WriteLine($"{flight.Number}|{flight.Name}|{flight.DateDeparture}|{flight.DateArrival}");
            }
        }

        public static void RemoveFligth(Flight flight)
        {
            flights.Remove(flight);
            OverrideFligths();
        }

        public static void OverrideFligths()
        {
            using (StreamWriter writer = new StreamWriter(PATH, false))
            {
                foreach (Flight flight in flights)
                    writer.WriteLine($"{flight.Number}|{flight.Name}|{flight.DateDeparture}|{flight.DateArrival}");
            }
        }

    }
}
