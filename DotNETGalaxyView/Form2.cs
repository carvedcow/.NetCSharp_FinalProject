using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNETGalaxyView
{
    public partial class Form2 : Form
    {
        public string incomingForm2Name;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAddPlanet_Click(object sender, EventArgs e)
        {
            incomingForm2Name = tbxPlanetName.Text;
            this.Close();
        }

    }
}
