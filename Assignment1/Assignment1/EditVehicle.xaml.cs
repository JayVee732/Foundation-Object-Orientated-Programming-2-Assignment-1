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
    /// Interaction logic for EditVehicle.xaml
    /// </summary>
    public partial class EditVehicle : Window
    {
        public Vehicle selectedVehicle = Application.Current.Properties["selectedVehicle"] as Vehicle;
        public Vehicle editedVehicle = Application.Current.Properties["selectedVehicle"] as Vehicle;
        public EditVehicle()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedVehicle != null)
                {
                    tbxMake.Text = selectedVehicle.Make;
                    tbxModel.Text = selectedVehicle.Model;
                    tbxPrice.Text = selectedVehicle.Price.ToString();
                    tbxYear.Text = selectedVehicle.Year.ToString();
                    tbxColour.Text = selectedVehicle.Colour;
                    tbxMileage.Text = selectedVehicle.Mileage.ToString();
                    tbxDescription.Text = selectedVehicle.Description;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string make = tbxMake.Text;
            string model = tbxModel.Text;
            double price = double.Parse(tbxPrice.Text);
            int year = int.Parse(tbxYear.Text);
            string colour = tbxColour.Text;
            int mileage = int.Parse(tbxMileage.Text);
            string description = tbxDescription.Text;
            
            editedVehicle.Make = make;
            editedVehicle.Model = model;
            editedVehicle.Price = price;
            editedVehicle.Year = year;
            editedVehicle.Colour = colour;
            editedVehicle.Mileage = mileage;
            editedVehicle.Description = description;

            MainWindow main = this.Owner as MainWindow;

            if (editedVehicle != selectedVehicle)
            {
                main.vehicleType.Remove(selectedVehicle);
                main.vehicleType.Add(editedVehicle);
                main.lbxDisplay.ItemsSource = null;
                main.lbxDisplay.ItemsSource = main.vehicleType;
            }
            
            main.lbxDisplay.ItemsSource = null;
            main.lbxDisplay.ItemsSource = main.vehicleType;

            main.tblVehicleDisplay.Text = "";
            main.imgVehicle.Source = null;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
