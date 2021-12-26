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
    /// Логика взаимодействия для FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : Page
    {
        public FlightsPage()
        {
            InitializeComponent();
            UpdateList();
        }

        public void UpdateList()
        {
            Flight.ReadFlights();
            LvFlights.ItemsSource = Flight.flights;
            LvFlights.Items.Refresh();
        }

        private void LvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Flight flight = (Flight)LvFlights.SelectedItem;
            if (flight != null)
            {
                tbxName.Text = flight.Name;
                tbxDateDeparture.Text = flight.DateDeparture;
                tbxDateArrival.Text = flight.DateArrival;
            }
        }

        private void AddFlights_CLick(object sender, RoutedEventArgs e)
        {
            string Name = tbxName.Text;
            string DateDeparture = tbxDateDeparture.Text;
            string DateArrival = tbxDateArrival.Text;
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(DateDeparture) && !String.IsNullOrEmpty(DateArrival))
            {
                Flight flight = new Flight(Name, DateDeparture, DateArrival);
                Flight.AddFlights(flight);
                UpdateList();
            }
        }

        private void ChangeFlights_CLick(object sender, RoutedEventArgs e)
        {
            if (LvFlights.SelectedIndex >= 0)
            {
                Flight flight = (Flight)LvFlights.SelectedItem;
                if (flight != null)
                {
                    flight.Name = tbxName.Text;
                    flight.DateDeparture = tbxDateDeparture.Text;
                    flight.DateArrival = tbxDateArrival.Text; 
                    Flight.OverrideFligths();
                    UpdateList();
                }
            }
        }

        private void RemoveFlights_CLick(object sender, RoutedEventArgs e)
        {
            if (LvFlights.SelectedIndex >= 0)
            {
                Flight flight = (Flight)LvFlights.SelectedItem;
                if (flight != null)
                    Flight.RemoveFligth(flight);
                UpdateList();
            }
        }
    }
}
