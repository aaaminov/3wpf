using _3ticketExz.classes;
using _3ticketExz.models; //лол
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
    /// Логика взаимодействия для PassengerPage.xaml
    /// </summary>
    public partial class PassengerPage : Page
    {
        public PassengerPage()
        {
            InitializeComponent(); //хз
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            dgPassengers.ItemsSource = null;
            dgPassengers.Items.Clear();
            Passenger.ReadPassenger();
            Flight.ReadFlights();
            PassengerFlights.ParseToPassengerFlights(Passenger.passengers, Flight.flights);
            dgPassengers.ItemsSource = PassengerFlights.passengersFlights;
            dgPassengers.Items.Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            PassengerFlights passengerFlights = (sender as Button).DataContext as PassengerFlights;
            MyFrame.MainFrame.Navigate(new AddPassengerPage(passengerFlights.Number));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.MainFrame.Navigate(new AddPassengerPage());
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var passengersFlights = dgPassengers.SelectedItems.Cast<PassengerFlights>().ToList();
            if (MessageBox.Show("удалить?","внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    foreach (PassengerFlights pl in passengersFlights)
                    {
                        Passenger.RemovePassenger(pl.Fio);
                    }
                    UpdateDataGrid();
                }
                catch (Exception exc) { }
            }
        }
    }
}
