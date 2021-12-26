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
    /// Логика взаимодействия для ChooserPage.xaml
    /// </summary>
    public partial class ChooserPage : Page
    {
        public ChooserPage()
        {
            InitializeComponent();
        }

        private void Fligths_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.MainFrame.Navigate(new FlightsPage());
        }

        private void Passenger_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.MainFrame.Navigate(new PassengerPage());
        }

        private void Make_Json_Click(object sender, RoutedEventArgs e)
        {
            Flight.ReadFlights();
            Passenger.ReadPassenger();
            PassengerFlights.ParseToJson(Passenger.passengers, Flight.flights);
            MessageBox.Show("json сделан");
        }
    }
}
