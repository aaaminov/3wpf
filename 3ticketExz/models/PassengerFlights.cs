using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3ticketExz.models
{
    class PassengerFlights
    {
        public const string PATH = "passengers_&_flights.json";
        public static List<PassengerFlights> passengersFlights = new List<PassengerFlights>();

        public int Number { get; set; }
        public string Fio { get; set; }
        public string DateBirth { get; set; }
        public List<string> NamesFlights { get; set; }

        public PassengerFlights(int Number, string Fio, string DateBirth, List<string> NamesFlights)
        {
            this.Number = Number;
            this.Fio = Fio;
            this.DateBirth = DateBirth;
            this.NamesFlights = NamesFlights;
        }

        public static void ParseToPassengerFlights(List<Passenger> passengers, List<Flight> flights)
        {
            passengersFlights.Clear();
            foreach (Passenger passenger in passengers)
            {
                List<string> names = new List<string>();
                foreach (int num in passenger.ListFlights)
                {
                    names.Add(flights.Find(f => f.Number == num)?.Name);
                }
                PassengerFlights passengerFlights = new PassengerFlights(
                    passenger.Number, passenger.Fio, passenger.DateBirth, names);
                if (passengerFlights != null)
                    passengersFlights.Add(passengerFlights);
            }
        }

        public static void ParseToJson(List<Passenger> passengers, List<Flight> flights)
        {
            ParseToPassengerFlights(passengers, flights);
            string json = JsonConvert.SerializeObject(passengersFlights);
            File.WriteAllText(PATH, json, Encoding.Default);
        }

    }
}
