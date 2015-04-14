using System.Windows.Forms;

namespace ICT4EVENT
{
    public partial class UserEvent : UserControl
    {
        public UserEvent(string eventName, string host, string location, string description)
        {
            InitializeComponent();
            lblEventName.Text = eventName;
            lblHost.Text = host;
            lblLocation.Text = location;
            lblDescription.Text = description;
        }
    }
}