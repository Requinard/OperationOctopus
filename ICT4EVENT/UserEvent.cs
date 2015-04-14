using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserEvent : UserControl
    {
        private Random r = new Random();
        
        public UserEvent(string eventName, string host, string location, string description, Image eventImage, Random random)
        {
            InitializeComponent();
            

            lblEventName.Text = eventName;
            lblHost.Text = host;
            lblLocation.Text ="@"+ location;
            lblDescription.Text = description;
            pbEventLogo.Image = eventImage;


            BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

            this.Size = new Size(this.Size.Width, (lblDescription.Size.Height + lblDescription.Location.Y + 3));
        }

        public void RandomBackcolor()
        {
            
            this.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

            if ((BackColor.R < 50 && BackColor.G < 50 && BackColor.B < 50) || (BackColor.R > 200 && BackColor.G >200 && BackColor.B > 200))
            {
                this.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            }
        }
    }

}
