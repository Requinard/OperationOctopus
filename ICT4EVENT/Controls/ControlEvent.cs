using System;
using System.Drawing;
using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserEvent : UserControl
    {
        private EventModel eventModel;

        public UserEvent(EventModel eventModel)
        {
            
            InitializeComponent();
            this.eventModel = eventModel;
            lblEventName.Text = eventModel.Name;
            lblDescription.Text = eventModel.Description;
            lblLocation.Text = eventModel.Location;
            lblStartDate.Text = eventModel.StartDate.ToString();
            lblEndDate.Text = eventModel.EndDate.ToString();
            Random r = new Random();
            BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
        }
        
        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            if (eventModel.Destroy())
            {
                return true;
            }
            return false;
        }
    }
}