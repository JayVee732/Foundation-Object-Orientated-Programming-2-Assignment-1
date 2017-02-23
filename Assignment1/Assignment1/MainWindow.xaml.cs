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
        //Creation of list for use with program
        List<Vehicle> vehicleType = new List<Vehicle>();
        List<Vehicle> filteredVehicles = new List<Vehicle>();
        List<Car> carType = new List<Car> ();
        List<Bike> bikeType = new List<Bike>();
        List<Van> vanType = new List<Van>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //When the program is started up, this method is called
            vehicleType.Add(new Car() { Make = "Ford", Model = "Focus", Price = 10000, Year = 2010, Colour = "Red", Mileage = 50000, Description = "That's some good shtuff!", Image = "/images/cars/ford-focus-red.jpg", BodyType = "Hatchback" });
            vehicleType.Add(new Bike() { Make = "Ford", Model = "Bikirio", Price = 50000, Year = 1957, Colour = "Green", Mileage = 50000, Description = "That's some really good shtuff!", Image = "/images/bikes/ford-bike-black.jpg", Type = "Sports" });
            vehicleType.Add(new Van() { Make = "Toyoda", Model = "Vaaaan", Price = 8520, Year = 2047, Colour = "Blue", Mileage = 50000, Description = "That's some extra good shtuff!", Image = "/images/vans/ford-van-white.png", Wheelbase = "Medium", Type = "Combi Van" });

            lbxDisplay.ItemsSource = vehicleType;
            //Values to sort by
            string[] sortBy = { "Make", "Mileage", "Price" };
            cbxSortBy.ItemsSource = sortBy;
            cbxSortBy.SelectedIndex = 0;
        }

        private void lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle selectedVehicle = lbxDisplay.SelectedItem as Vehicle;
            //Clears the previous selection
            tblVehicleDisplay.Text = "";
            imgVehicle.Source = null;

            //When the selectedVehicle is not null
            if (selectedVehicle != null)
            {

                tblVehicleDisplay.Text = "Make: " + selectedVehicle.Make +
                                        "\nModel: " + selectedVehicle.Model +
                                        "\nPrice:  " + selectedVehicle.Price +
                                        "\nYear: " + selectedVehicle.Year +
                                        "\nMileage: " + selectedVehicle.Mileage +
                                        "\nDescription: " + selectedVehicle.Description;
                //Sets the images associated with the vehicle
                imgVehicle.Source = new BitmapImage(new Uri(selectedVehicle.Image, UriKind.Relative));
            }
        }

        #region Radio Buttons Filtering

        //All radio buttons work independently
        private void rbnAll_Checked(object sender, RoutedEventArgs e)
        {
            lbxDisplay.ItemsSource = "";
            lbxDisplay.ItemsSource = vehicleType;
        }

        private void rbnCars_Checked(object sender, RoutedEventArgs e)
        {
            carType.Clear();
            //loop through
            foreach (var carVehicle in vehicleType)
            {
                //if type is car
                if (carVehicle.GetType().Name.Equals("Car"))
                {
                    //add to filter, needs to be converted first
                    Car c = carVehicle as Car;
                    carType.Add(c);
                }
            }

            lbxDisplay.ItemsSource = carType;
        }

        private void rbnBikes_Checked(object sender, RoutedEventArgs e)
        {
            bikeType.Clear();
            //loop through
            foreach (var bikeVehicle in vehicleType)
            {
                //if type is bike
                if (bikeVehicle.GetType().Name.Equals("Bike"))
                {
                    //add to filter, needs to be converted first
                    Bike b = bikeVehicle as Bike;
                    bikeType.Add(b);
                }
            }

            lbxDisplay.ItemsSource = bikeType;
        }

        private void rbnVans_Checked(object sender, RoutedEventArgs e)
        {
            vanType.Clear();
            //loop through
            foreach (var vanVehicle in vehicleType)
            {
                //if type is van
                if (vanVehicle.GetType().Name.Equals("Van"))
                {
                    //add to filter, needs to be converted first
                    Van v = vanVehicle as Van;
                    vanType.Add(v);
                }
            }

            lbxDisplay.ItemsSource = vanType;
        }
        #endregion

        #region Sorting with Combo Box
        //Get any of this shit working 
        private void cbxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxDisplay.ItemsSource = "";
            filteredVehicles.Clear();
            string sortedBy = cbxSortBy.SelectedValue.ToString();

            //Change this to a switch statement
            if (sortedBy.Equals("Price"))
            {
                SortNumbers();
                lbxDisplay.ItemsSource = filteredVehicles;
            }

            else if (sortedBy.Equals("Mileage"))
            {
                SortNumbers();
                lbxDisplay.ItemsSource = filteredVehicles;
            }

            else if (sortedBy.Equals("Make"))
            {
                SortLetters();
                lbxDisplay.ItemsSource = filteredVehicles;
            }
        }

        private void SortNumbers()
        {
            foreach (var vehicle in vehicleType)
            {

            }
        }
        private void SortLetters()
        {

        }

        //private void SortedVehicles(string sortedBy)
        //{
        //    foreach (var vehicle in vehicleType)
        //    {
        //        string type = vehicleType.GetType().Name;

        //        if (type.Equals(sortedBy))
        //        {
        //            filteredVehicles.Add(vehicle);
        //        }
        //    }
        //}
        #endregion

        #region Buttons for Other Windows
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVeh = new AddVehicle();
            addVeh.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditVehicle editVeh = new EditVehicle();
            editVeh.Show();
        }
        #endregion
    }
}
