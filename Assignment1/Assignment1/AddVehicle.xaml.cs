using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        string imageDirectory;
        string sourceFile = "";
        string fileName = "";
        string destinationFile = "";
        public AddVehicle()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] vehicleType = { "Car", "Bike", "Van" };
            cbxVehicleType.ItemsSource = vehicleType;
            cbxVehicleType.SelectedIndex = 0;
            
            cbxType.IsEnabled = false;
            cbxWheelbase.IsEnabled = false;

            SetImageDirectory();
        }

        private void SetImageDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDirectory);
            DirectoryInfo grandparent = parent.Parent;
            currentDirectory = grandparent.FullName;
            imageDirectory = currentDirectory + "\\images/vehicles";
        }

        private void cbxVehicleType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string vehicleTypeSelected = cbxVehicleType.SelectedValue.ToString();
            
            if (vehicleTypeSelected == "Car")
            {
                string[] carBodyType = { "Convertible", "Hatchback", "Coupe", "Estate", "MPV", "SUV", "Saloon", "Unlisted" };
                cbxBodyType.ItemsSource = carBodyType;
                cbxBodyType.SelectedIndex = 0;
                cbxBodyType.IsEnabled = true;

                cbxType.IsEnabled = false;
                cbxType.SelectedIndex = -1;

                cbxWheelbase.IsEnabled = false;
                cbxWheelbase.SelectedIndex = -1;
            }

            else if (vehicleTypeSelected == "Bike")
            {
                string[] bikeType = { "Scooter", "Trail Bike", "Sport", "Commuter", "Tourer", "Unlisted" };
                cbxType.ItemsSource = bikeType;
                cbxType.SelectedIndex = 0;
                cbxType.IsEnabled = true;

                cbxBodyType.IsEnabled = false;
                cbxBodyType.SelectedIndex = -1;

                cbxWheelbase.IsEnabled = false;
                cbxWheelbase.SelectedIndex = -1;
            }

            else if (vehicleTypeSelected == "Van")
            {
                string[] vanType = { "Combi Van", "Dropside", "Panel Van", "Pcikup", "Tipper", "Unlisted" };
                cbxType.ItemsSource = vanType;
                cbxType.SelectedIndex = 0;
                cbxType.IsEnabled = true;

                string[] wheelbase = { "Short", "Medium", "Long", "Unlisted" };
                cbxWheelbase.ItemsSource = wheelbase;
                cbxWheelbase.SelectedIndex = 0;
                cbxWheelbase.IsEnabled = true;
                
                cbxBodyType.IsEnabled = false;
                cbxBodyType.SelectedIndex = -1;
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow main = this.Owner as MainWindow;
                string newVehicle = cbxVehicleType.SelectedValue.ToString();

                string make = tbxMake.Text;
                string model = tbxModel.Text;
                double price = double.Parse(tbxPrice.Text);
                int year = int.Parse(tbxYear.Text);
                string colour = tbxColour.Text;
                int mileage = int.Parse(tbxMileage.Text);
                string description = tbxDescription.Text;
                string image = fileName.Replace("\\", "").ToString();

                string bodyType;
                string type;
                string wheelbase;

                switch (newVehicle)
                {
                    case "Car":
                        bodyType = cbxBodyType.SelectedValue.ToString();
                        main.vehicleType.Add(new Car() { Make = make, Model = model, Price = price, Year = year, Colour = colour, Mileage = mileage, Description = description, Image = image, BodyType = bodyType });
                        break;
                    case "Bike":
                        type = cbxType.SelectedValue.ToString();
                        main.vehicleType.Add(new Bike() { Make = make, Model = model, Price = price, Year = year, Colour = colour, Mileage = mileage, Description = description, Image = image, Type = type });
                        break;
                    case "Van":
                        type = cbxType.SelectedValue.ToString();
                        wheelbase = cbxWheelbase.SelectedValue.ToString();
                        main.vehicleType.Add(new Van() { Make = make, Model = model, Price = price, Year = year, Colour = colour, Mileage = mileage, Description = description, Image = image, Type = type, Wheelbase = wheelbase });
                        break;
                }
                
                main.lbxDisplay.ItemsSource = null;
                main.lbxDisplay.ItemsSource = main.vehicleType;

                this.Close();
            }

            catch (FormatException)
            {
                MessageBox.Show("Error - All boxes must be filled");
            }
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Title = "Select Vehicle Image";
            dlg.Filter = "Images (*.JPG;*.JPEG;*.PNG) | *.JPG;*.JPEG;*.PNG";
            Nullable<bool> result = dlg.ShowDialog();
            try
            {
                if (result == true)
                {
                    sourceFile = dlg.FileName;
                    fileName = sourceFile.Substring(sourceFile.LastIndexOf('\\'));
                }

                destinationFile = imageDirectory + fileName;

                if (!File.Exists(destinationFile))
                {
                    File.Copy(sourceFile, destinationFile);
                }

                tbxImagePath.Text = "";
                tbxImagePath.Text = fileName.Replace("\\", "").ToString();
            }

            catch (IOException ioe)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ioe.Message);
            }

            catch (Exception fe)
            {
                MessageBox.Show("Error: Image needed for vehicle. Original Error: " + fe.Message);
            }         
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
