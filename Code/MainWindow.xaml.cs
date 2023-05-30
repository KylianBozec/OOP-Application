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
using Microsoft.VisualBasic;


namespace OOP_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //int i = 1;

        public ObservableCollection<Unit> Units { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Units = new ObservableCollection<Unit>();
            UnitsList.ItemsSource = Units;
        }

        private void myCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (UnitsList.SelectedItem != null)
            {
                Unit selectedUnit = UnitsList.SelectedItem as Unit;
                string unitInfo = $"<- Location: {selectedUnit.Location}\n" +
                                  $"   Unit Number: {selectedUnit.UnitNumber}\n" +
                                  $"   Need: {selectedUnit.Need}\n" +
                                  $"   Status: {selectedUnit.Status}\n" +
                                  $"   Time: {selectedUnit.Time}";

                Label label = new Label
                {
                    Content = unitInfo,
                    Foreground = Brushes.Black,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold
                };

                Point position = e.GetPosition(myCanvas);
                Canvas.SetLeft(label, position.X);
                Canvas.SetTop(label, position.Y);

                myCanvas.Children.Add(label);
            }
        }



        private void cmbImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string imageName = "";
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            imageName = selectedItem.Content.ToString();
            picture.Source = new BitmapImage(new Uri("/images/"+imageName+ ".jpg", UriKind.Relative));
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (tabUnits.IsSelected)
            {
                btnSave.Visibility = Visibility.Visible; 
            }
            else
            {
                btnSave.Visibility = Visibility.Collapsed;  
            }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "Units.txt";
            
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Unit unit in Units)
                {
                    writer.WriteLine($"Location: {unit.Location}");
                    writer.WriteLine($"Unit Number: {unit.UnitNumber}");
                    writer.WriteLine($"Need: {unit.Need}");
                    writer.WriteLine($"Status: {unit.Status}");
                    writer.WriteLine($"Time: {unit.Time}");
                    writer.WriteLine();
                }
            }

            MessageBox.Show("Units saved to file.");
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
