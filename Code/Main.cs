using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DesktopApplication
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Unit> units;
        private Unit selectedUnit;

        public ObservableCollection<Unit> Units
        {
            get { return units; }
            set
            {
                units = value;
                NotifyPropertyChanged();
            }
        }

        public Unit SelectedUnit
        {
            get { return selectedUnit; }
            set
            {
                selectedUnit = value;
                NotifyPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Units = new ObservableCollection<Unit>();
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

            ClearInputFields();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUnit != null)
            {
                SelectedUnit.Location = txtLocation.Text;
                SelectedUnit.UnitNumber = txtUnitNumber.Text;
                SelectedUnit.Need = txtNeed.Text;
                SelectedUnit.Status = txtStatus.Text;
                SelectedUnit.Time = txtTime.Text;
            }

            ClearInputFields();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUnit != null)
            {
                Units.Remove(SelectedUnit);
                SelectedUnit = null;
            }

            ClearInputFields();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void ClearInputFields()
        {
            txtLocation.Text = string.Empty;
            txtUnitNumber.Text = string.Empty;
            txtNeed.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtTime.Text = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Unit : INotifyPropertyChanged
    {
        private string location;
        private string unitNumber;
        private string need;
        private string status;
        private string time;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                NotifyPropertyChanged();
            }
        }

        public string UnitNumber
        {
            get { return unitNumber; }
            set
            {
                unitNumber = value;
                NotifyPropertyChanged();
            }
        }

        public string Need
        {
            get { return need; }
            set
            {
                need = value;
                NotifyPropertyChanged();
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }

        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                NotifyPropertyChanged();
            }
        }

        public Unit(string location, string unitNumber, string need, string status, string time)
        {
            Location = location;
            UnitNumber = unitNumber;
            Need = need;
            Status = status;
            Time = time;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
