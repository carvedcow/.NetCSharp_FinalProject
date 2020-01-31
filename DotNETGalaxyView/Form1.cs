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
    public partial class Form1 : Form
    {
        // Properties
        public string incomingForm2Name;
        public int incomingForm3FactoryLevel = 1;
        public int incomingForm3StorageLevel = 1;
        public int addedResource = 10;
        public int maxResource = 100;
        BuildingContext _context;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _context = new BuildingContext();
            // Call the Load method to get the data for the given DbSet
            // from the database.
            // The data is materialized as entities. The entities are managed by
            // the DbContext instance.
            _context.Planets.Load();
            // Bind the categoryBindingSource.DataSource to
            // all the Unchanged, Modified and Added Category objects that
            // are currently tracked by the DbContext.
            // Note that we need to call ToBindingList() on the
            // ObservableCollection<TEntity> returned by
            // the DbSet.Local property to get the BindingList<T>
            // in order to facilitate two-way binding in WinForms.
            this.planetBindingSource.DataSource = _context.Planets.Local.ToBindingList();
        }

        // not used
        private void planetBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            // Currently, the Entity Framework doesn’t mark the entities
            // that are removed from a navigation property (in our example the Products)
            // as deleted in the context.
            // The following code uses LINQ to Objects against the Local collection
            // to find all products and marks any that do not have
            // a Category reference as deleted.
            // The ToList call is required because otherwise
            // the collection will be modified
            // by the Remove call while it is being enumerated.
            // In most other situations you can do LINQ to Objects directly
            // against the Local property without using ToList first.
            foreach (var building in _context.Buildings.Local.ToList())
            {
                if (building.Planet == null)
                {
                    _context.Buildings.Remove(building);
                }
            }
            // save to data base
            _context.SaveChanges();

            // refresh data
            planetDataGridView.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // dispose context and close connection
            this._context.Dispose();

        }

        // create new planet
        private void btn_ColPlanet_Click(object sender, EventArgs e)
        {
            using (Form2 frm2 = new Form2())
            {
                // show form2
                frm2.ShowDialog();
                // save new planet name
                incomingForm2Name = frm2.incomingForm2Name;

            }

            // save new planet to context
            Show();
            if (!String.IsNullOrEmpty(incomingForm2Name))
            {
                var newPlanet = new Planet()
                {
                    PlanetName = incomingForm2Name
                };
                var factory = new Building()
                {
                    BuildingName = "Factory",
                    BuildingCost = 10,
                    BuildingLevel = 1,
                    BuildingId = newPlanet.PlanetId
                };
                var storage = new Building()
                {
                    BuildingName = "Storage",
                    BuildingCost = 10,
                    BuildingLevel = 1,
                    BuildingId = newPlanet.PlanetId
                };
                _context.Planets.Add(newPlanet);
                _context.Buildings.Add(factory);
                _context.Buildings.Add(storage);
                _context.SaveChanges();
                planetDataGridView.Refresh();
            }
        }

        // view building
        private void btn_ViewBuildings_Click(object sender, EventArgs e)
        {
            if (planetDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = planetDataGridView.SelectedRows[0];

                int selectedPlanetObjectId = (int)row.Cells[0].Value;

                var result = _context.Planets.SingleOrDefault(p => p.PlanetId == selectedPlanetObjectId);
                if (result != null)
                {
                    using (Form3 frm3 = new Form3())
                    {
                        // assign planetName and planetResource
                        frm3.planetId = (int)row.Cells[0].Value;
                        frm3.planetName = (string)row.Cells[1].Value;
                        frm3.planetResource = (int)row.Cells[2].Value;

                        // show form3
                        frm3.ShowDialog();
                        result.PlanetResources = frm3.planetResource;
                        incomingForm3FactoryLevel = frm3.factoryLevel;
                        incomingForm3StorageLevel = frm3.storageLevel;
                        Show();
                    }

                    _context.SaveChanges();
                    planetDataGridView.Refresh();
                }
            }
        }

        private void btn_AbandonPlanet_Click(object sender, EventArgs e)
        {
            // delete planet

            if (planetDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = planetDataGridView.SelectedRows[0];

                int selectedRow = (int)row.Cells[0].Value;

                var result = _context.Planets.SingleOrDefault(p => p.PlanetId == selectedRow);
                if (result != null)
                {
                    _context.Planets.Remove(result);
                    _context.SaveChanges();
                }
            }

        }

        private void btn_CollectResource_Click(object sender, EventArgs e)
        {
            // collect resource


            if (planetDataGridView.SelectedRows.Count != 0)
            {
                DataGridViewRow row = planetDataGridView.SelectedRows[0];

                int selectedRow = (int)row.Cells[0].Value;

                var result = _context.Planets.SingleOrDefault(p => p.PlanetId == selectedRow);
                if (result != null)
                {
                    if (result.PlanetResources < maxResource * incomingForm3StorageLevel)
                    {
                        result.PlanetResources += addedResource * incomingForm3FactoryLevel;
                        _context.SaveChanges();
                        planetDataGridView.Refresh();
                    }
                }
            }
        }
    }
}
