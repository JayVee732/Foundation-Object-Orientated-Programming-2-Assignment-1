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
        public Vehicle currentVehicle = Application.Current.Properties["currentVehicle"] as Vehicle;
        public EditVehicle()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentVehicle != null)
                {
                    tbxMake.Text = currentVehicle.Make;
                    tbxModel.Text = currentVehicle.Model;
                    tbxPrice.Text = currentVehicle.Price.ToString();
                    tbxYear.Text = currentVehicle.Year.ToString();
                    tbxColour.Text = currentVehicle.Colour;
                    tbxMileage.Text = currentVehicle.Mileage.ToString();
                    tbxDescription.Text = currentVehicle.Description;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Work more on this
            string make = tbxMake.Text;
            string model = tbxModel.Text;
            double price = double.Parse(tbxPrice.Text);
            int year = int.Parse(tbxYear.Text);
            string colour = tbxColour.Text;
            int mileage = int.Parse(tbxMileage.Text);
            string description = tbxDescription.Text;
            
            make = currentVehicle.Make;
            model = currentVehicle.Model;
            price = currentVehicle.Price;
            year = currentVehicle.Year;
            colour = currentVehicle.Colour;
            mileage = currentVehicle.Mileage;
            description = currentVehicle.Description;

            MainWindow main = this.Owner as MainWindow;
            
            main.vehicleType.Add(currentVehicle);
            main.lbxDisplay.ItemsSource = null;
            main.lbxDisplay.ItemsSource = main.vehicleType;

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
