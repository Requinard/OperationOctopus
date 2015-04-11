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
        private bool FirstTime = true;

        private int[] Bungalows = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 17, 18, 19, 20, 23, 24, 25, 26};
        private int[] Blokhutten = {72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 91, 92, 95, 96, 138, 139, 140, 141, 142, 124, 143, 144, 145, 146, 147, 148, 149, 150 };



        public CampingForm()
        {
            InitializeComponent();
        }

        private void txtGebruikers_Enter(object sender, EventArgs e)
        {
            if (FirstTime)
            {
                txtGebruikers.Text = "";
                FirstTime = false;
            }
        }

        private bool CheckPlaceSize(decimal place, int amountofusers)
        {
            place = Convert.ToInt32(place);

            if (place >= 2 && place <= 678)
            {
                if(((place >= 34 && place <= 41) || (place >= 93 && place <= 94) || (place >= 97 && place <= 100) || (place >= 125 && place <= 127) ) && (amountofusers > 6))
                {
                    MessageBox.Show("Er kunnen maximaal 6 personen in een stacaravan.");
                    return false;
                }

                if((place >= 601 && place <= 626) && (amountofusers > 4))
                {
                    MessageBox.Show("Er kunnen maximaal 4 personen op een comfortplaats");
                    return false;
                }

                if((place >= 643 && place <= 678) && (amountofusers > 4))
                {
                    MessageBox.Show("Er kunnen maximaal 4 personen per huurtentje");
                    return false;
                }

                if (((place >= 101 && place <= 123) || (place >= 200 && place <= 2013) || (place >= 401 && place <= 419) ||
                     (place >= 314 && place <= 323) || (place == 431 || place == 544)) && (amountofusers > 5))
                {
                    MessageBox.Show("Er kunnen maximaal 5 personen per eigen tent");
                    return false;
                }

                if ((place >= 85 && place <= 90) && (amountofusers > 4))
                {
                    MessageBox.Show("Er kunnen maximaal 4 personen per invalidenaccomodatie");
                }

                foreach (int p in Bungalows)
                {
                    if (p == place)
                    {
                        return true;
                    }
                }

                foreach (int p in Blokhutten)
                {
                    if (p == place)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int lines = txtGebruikers.Lines.Count();
            if (CheckPlaceSize(nmrPlaats.Value, lines))
            {
            }
        }
    }
}
