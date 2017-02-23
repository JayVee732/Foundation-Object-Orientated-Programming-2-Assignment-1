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

        public EditVehicle()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Not tested
        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Images (*.JPG;*.JPEG;*.PNG) | *.JPG;*.JPEG;*.PNG";

            Nullable<bool> result = dlg.ShowDialog();
            string sourceFile = "";
            string fileName = "";

            if (result == true)
            {
                sourceFile = dlg.FileName;
                fileName = sourceFile.Substring(sourceFile.LastIndexOf('\\'));
            }

            string destinationFile = imageDirectory + fileName;
            File.Copy(sourceFile, destinationFile);
        }

        private void SetImageDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            DirectoryInfo parent = Directory.GetParent(currentDirectory);

            DirectoryInfo grandparent = parent.Parent;

            currentDirectory = grandparent.FullName;

            imageDirectory = currentDirectory + "\\images";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Work more on this
        }
    }
}
