using System;
using System.Windows.Forms;

namespace YourApplication
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            mapControl.BackColor = Color.White;

            mapControl.MouseClick += MapControl_MouseClick;

            mapControl.InitializeMap();
            mapControl.SetZoomLevel(10);
            mapControl.SetCenterCoordinates(0, 0);
}


        private void PlaceObjectOnMap()
        {
            mapControl.MouseClick += MapControl_MouseClick;
        }

        private void MapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double latitude = mapControl.GetLatitudeFromPixel(e.X);
                double longitude = mapControl.GetLongitudeFromPixel(e.Y);

                UnitDialog unitDialog = new UnitDialog();
                DialogResult result = unitDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string location = unitDialog.Location;
                    string time = unitDialog.Time;
                    string status = unitDialog.Status;
                    string need = unitDialog.Need;
                    string unitID = unitDialog.UnitID;

                    Unit unit = new Unit(location, unitID, need, status, time);

                    mapControl.AddMarker(latitude, longitude, unit.ToString());
                }
            }
        }

    }
}