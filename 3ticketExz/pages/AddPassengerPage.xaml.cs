using _3ticketExz.classes;
using _3ticketExz.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3ticketExz.pages
{
    /// <summary>
    /// Логика взаимодействия для AddPassengerPage.xaml
    /// </summary>
    public partial class AddPassengerPage : Page
    {
        private Passenger selectedPassenger = new Passenger();

        public AddPassengerPage()
        {
            InitializeComponent();
            Flight.ReadFlights();
            lvFlights.ItemsSource = Flight.flights;
            DataContext = selectedPassenger;
        }
        
        public AddPassengerPage(int number)
        {
            InitializeComponent();
            Flight.ReadFlights();
            lvFlights.ItemsSource = Flight.flights;
            selectedPassenger = Passenger.passengers.Find(p => p.Number == number);
            DataContext = selectedPassenger;
            //List<Flight> ListFlights = Flight.flights.Find(f => f.Number == selectedPassenger.ListFlights);
            //lvFlights.SelectedItem = ListFlights;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxFio.Text) || string.IsNullOrEmpty(tbxDateBirth.Text) || lvFlights.SelectedItems.Count == 0)
                return;
            if (selectedPassenger.Number == 0)
            {
                selectedPassenger = new Passenger(selectedPassenger.Fio, selectedPassenger.DateBirth, selectedPassenger.ListFlights);
                DataContext = selectedPassenger;
                foreach (Flight selectedFlight in lvFlights.SelectedItems.Cast<Flight>())
                {
                    selectedPassenger?.ListFlights.Add(selectedFlight.Number);
                }
                Passenger.AddPassenger(selectedPassenger);
            }
            else
            {
                foreach (Flight selectedFlight in lvFlights.SelectedItems.Cast<Flight>())
                {
                    selectedPassenger?.ListFlights.Add(selectedFlight.Number);
                }
                Passenger.OverridePassengers();
            }
            MyFrame.MainFrame.GoBack();
        }

    }
}
