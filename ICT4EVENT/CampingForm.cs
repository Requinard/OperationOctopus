using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class CampingForm : Form
    {
        public CampingForm()
        {
            InitializeComponent();
        }

        private void txtGebruikers_Enter(object sender, EventArgs e)
        {
            txtGebruikers.Text = "";
        }
    }
}
