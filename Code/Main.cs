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
using System.IO;


namespace OOP_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int i = 1;

        public ObservableCollection<Unit> Units { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Units = new ObservableCollection<Unit>();
            UnitsList.ItemsSource = Units;
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string location = txtLocation.Text;
            string unitNumber = txtUnitNumber.Text;
            string need = txtNeed.Text;
            string status = txtStatus.Text;
            string time = txtTime.Text;

            Unit newUnit = new Unit(location, unitNumber, need, status, time);
            Units.Add(newUnit);

            txtLocation.Text = "";
            txtUnitNumber.Text = "";
            txtNeed.Text = "";
            txtStatus.Text = "";
            txtTime.Text = "";
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem != null)
            {
                Unit selectedUnit = UnitsList.SelectedItem as Unit;
                string newLocation = txtLocation.Text;
                string newUnitNumber = txtUnitNumber.Text;
                string newNeed = txtNeed.Text;
                string newStatus = txtStatus.Text;
                string newTime = txtTime.Text;

                selectedUnit.Location = newLocation;
                selectedUnit.UnitNumber = newUnitNumber;
                selectedUnit.Need = newNeed;
                selectedUnit.Status = newStatus;
                selectedUnit.Time = newTime;

                UnitsList.Items.Refresh();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UnitsList.SelectedItem != null)
            {
                Unit selectedUnit = UnitsList.SelectedItem as Unit;
                Units.Remove(selectedUnit);

                txtLocation.Text = "";
                txtUnitNumber.Text = "";
                txtNeed.Text = "";
                txtStatus.Text = "";
                txtTime.Text = "";
            }
        }

        private void UnitsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UnitsList.SelectedItem != null)
            {
                Unit selectedUnit = UnitsList.SelectedItem as Unit;
                txtLocation.Text = selectedUnit.Location;
                txtUnitNumber.Text = selectedUnit.UnitNumber;
                txtNeed.Text = selectedUnit.Need;
                txtStatus.Text = selectedUnit.Status;
                txtTime.Text = selectedUnit.Time;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you want to save the units as XML
            string filePath = "units.xml";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<Unit>));
                serializer.Serialize(writer, Units);
            }

            MessageBox.Show("Units saved to file.");
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            i--;

            if (i < 1)
            {
                i = 4;
            }

            picture.Source = new BitmapImage(new Uri("/images/image"+i+".jpg", UriKind.Relative));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            i++;

            if (i > 4)
            {
                i = 1;
            }
            picture.Source = new BitmapImage(new Uri("/images/image"+i+".jpg", UriKind.Relative));
        }
    }

    public class Unit
    {
        public string Location { get; set; }
        public string UnitNumber { get; set; }
        public string Need { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }

        public Unit() { }

        public Unit(string location, string unitNumber, string need, string status, string time)
        {
            Location = location;
            UnitNumber = unitNumber;
            Need = need;
            Status = status;
            Time = time;
        }
    }
}
