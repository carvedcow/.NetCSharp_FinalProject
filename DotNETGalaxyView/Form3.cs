using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNETGalaxyView
{
    public partial class Form3 : Form
    {
        // properties
        public int planetId { get; set; }
        public string planetName { get; set; }
        public int planetResource { get; set; }
        public int factoryLevel { get; set; }
        public int storageLevel { get; set; }
        BuildingContext _context;

        public Form3()
        {
            InitializeComponent();
        }

        // binds the table to database
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new BuildingContext();

            _context.Buildings.Load();

            buildingsBindingSource.DataSource = _context.Buildings.Local.Where(b => b.PlanetId == planetId).ToList();

            tb_planetName.Text = planetName;
            tb_planetResources.Text = planetResource.ToString();
        }

        // upgrade button clicked
        private void btn_Upgrade_Click(object sender, EventArgs e)
        {
            if (buildingsDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = buildingsDataGridView.SelectedRows[0];

                int selectedBuildingId = (int)row.Cells[0].Value;

                var result = _context.Buildings.SingleOrDefault(b => b.BuildingId == selectedBuildingId);
                if (result != null)
                {
                    if (planetResource >= result.BuildingCost)
                    {
                        planetResource -= result.BuildingCost;
                        tb_planetResources.Text = planetResource.ToString();
                        result.BuildingCost *= 2;
                        result.BuildingLevel += 1;

                        if (result.BuildingName.Equals("Factory"))
                            factoryLevel = result.BuildingLevel;
                        else
                            storageLevel = result.BuildingLevel;
                    }
                    _context.SaveChanges();
                    buildingsDataGridView.Refresh();
                }
            }
        }
    }
}
