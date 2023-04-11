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

namespace Satisfactory_Calculator
{
    /// <summary>
    /// Interaction logic for Vehicles.xaml
    /// </summary>
    public partial class Vehicles : Page
    {
        private MainWindow mainWindow = null;
        public Vehicles(MainWindow main)
        {
            InitializeComponent();
            this.mainWindow = main;
        }

        private void AllVehiclesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MyVehiclesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewMyVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnRemoveVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddPercentage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemovePercentage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
