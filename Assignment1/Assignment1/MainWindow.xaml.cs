using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        IEnumerable<Vehicle> filteredVehicles = new List<Vehicle>();
        List<Car> carType = new List<Car> ();
        List<Bike> bikeType = new List<Bike>();
        List<Van> vanType = new List<Van>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void cbxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxDisplay.ItemsSource = "";
            filteredVehicles.Equals("");
            string sortedBy = cbxSortBy.SelectedValue.ToString();

            switch (sortedBy)
            {
                case "Make":
                    filteredVehicles = vehicleType.OrderBy(i => i.Make);
                    break;
                case "Mileage":
                    filteredVehicles = vehicleType.OrderBy(i => i.Mileage);
                    break;
                case "Price":
                    filteredVehicles = vehicleType.OrderBy(i => i.Price);
                    break;
            }

            lbxDisplay.ItemsSource = filteredVehicles;
        }
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

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("./vehicleData/vehicleData.txt"))
                {
                    string vehicle = sr.ReadLine();

                    while (vehicle != null)
                    {
                        string[] newVehicle = vehicle.Split(',');
                        string checkVehicle = newVehicle[0];

                        switch (checkVehicle)
                        {
                            case "Car":
                                vehicleType.Add(new Car() { Make = newVehicle[1], Model = newVehicle[2], Price = double.Parse(newVehicle[3]), Year = int.Parse(newVehicle[4]), Colour = newVehicle[5], Mileage = int.Parse(newVehicle[6]), Description = newVehicle[7], Image = newVehicle[8], BodyType = newVehicle[9] });

                                newVehicle = null;
                                vehicle = sr.ReadLine();
                                break;
                            case "Bike":
                                vehicleType.Add(new Bike() { Make = newVehicle[1], Model = newVehicle[2], Price = double.Parse(newVehicle[3]), Year = int.Parse(newVehicle[4]), Colour = newVehicle[5], Mileage = int.Parse(newVehicle[6]), Description = newVehicle[7], Image = newVehicle[8], Type = newVehicle[9] });

                                newVehicle = null;
                                vehicle = sr.ReadLine();
                                break;
                            case "Van":
                                vehicleType.Add(new Van() { Make = newVehicle[1], Model = newVehicle[2], Price = double.Parse(newVehicle[3]), Year = int.Parse(newVehicle[4]), Colour = newVehicle[5], Mileage = int.Parse(newVehicle[6]), Description = newVehicle[7], Image = newVehicle[8], Wheelbase = newVehicle[9], Type = newVehicle[10] });

                                newVehicle = null;
                                vehicle = sr.ReadLine();
                                break;
                        }
                    }
                }

            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
                throw;
            }

            lbxDisplay.ItemsSource = vehicleType;
        }
    }
}
