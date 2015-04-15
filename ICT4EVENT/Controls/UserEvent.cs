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
        }
    }
}