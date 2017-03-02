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
        string imageDirectory;
        string sourceFile = "";
        string fileName = "";
        string destinationFile = "";

        public Vehicle selectedVehicle = Application.Current.Properties["selectedVehicle"] as Vehicle;
        public Vehicle editedVehicle = Application.Current.Properties["selectedVehicle"] as Vehicle;
        public EditVehicle()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetImageDirectory();

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
                MessageBox.Show("No vehicle entered");
                this.Close();
            }
        }
        private void SetImageDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo parent = Directory.GetParent(currentDirectory);
            DirectoryInfo grandparent = parent.Parent;
            currentDirectory = grandparent.FullName;
            imageDirectory = currentDirectory + "\\images/vehicles";
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
            string image = fileName.Replace("\\", "").ToString();

            editedVehicle.Make = make;
            editedVehicle.Model = model;
            editedVehicle.Price = price;
            editedVehicle.Year = year;
            editedVehicle.Colour = colour;
            editedVehicle.Mileage = mileage;
            editedVehicle.Description = description;
            editedVehicle.Image = image;

            MainWindow main = this.Owner as MainWindow;

            if (editedVehicle != selectedVehicle)
            {
                main.vehicleType.Remove(selectedVehicle);
                main.vehicleType.Add(editedVehicle);
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
            }

            catch (IOException ioe)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ioe.Message);
            }

            try
            {
                destinationFile = imageDirectory + fileName;
                if (!File.Exists(destinationFile))
                {
                    File.Copy(sourceFile, destinationFile);
                }
                
                tbxImagePath.Text = "";
                tbxImagePath.Text = fileName.Replace("\\", "").ToString();
            }

            catch (Exception fe)
            {
                MessageBox.Show("Error: Image needed for vehicle. Original Error: " + fe.Message);
            }
        }
    }
}
