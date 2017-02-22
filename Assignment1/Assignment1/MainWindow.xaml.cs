using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Creation of List for vehicles
        List<Vehicle> vehicleType = new List<Vehicle>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //When the program is started up, this method is called
            vehicleType.Add(new Car() { Make = "Ford", Model = "Focus", Price = 10000, Year = 2010, Colour = "Red", Mileage = 50000, Description = "That's some good shtuff!" });
            vehicleType.Add(new Bike() { Make = "Ford", Model = "Bikirio", Price = 50000, Year = 1957, Colour = "Green", Mileage = 50000, Description = "That's some really good shtuff!" });
            vehicleType.Add(new Van() { Make = "Toyoda", Model = "Vaaaan", Price = 8520, Year = 2047, Colour = "Blue", Mileage = 50000, Description = "That's some extra good shtuff!" });

            lbxDisplay.ItemsSource = vehicleType;
        }

        private void lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle selectedVehicle = lbxDisplay.SelectedItem as Vehicle;

            //When the selectedVehicle is not null
            if (selectedVehicle != null)
            {

                tblVehicleDisplay.Text = "Make: " + selectedVehicle.Make +
                                        "\nModel: " + selectedVehicle.Model +
                                        "\nPrice:  " + selectedVehicle.Price +
                                        "\nYear: " + selectedVehicle.Year +
                                        "\nMileage: " + selectedVehicle.Mileage +
                                        "\nDescription: " + selectedVehicle.Description;
            }
        }
    }
}
