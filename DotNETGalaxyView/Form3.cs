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

        private void btn_Upgrade_Click(object sender, EventArgs e)
        {
            if (buildingsDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = buildingsDataGridView.SelectedRows[0];

                int selectedBuildingId = (int)row.Cells[0].Value;

                var result = _context.Buildings.SingleOrDefault(b => b.BuildingId == selectedBuildingId);
                if (result != null)
                {
                    

                        // assign planetName and planetResource
                        //planetName = (string)row.Cells[1].Value;
                        //planetResource = (int)row.Cells[2].Value;


                    _context.SaveChanges();
                    buildingsDataGridView.Refresh();
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

    }
}
