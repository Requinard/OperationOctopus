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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            FillEventList();
            UserEvent.EventRemoved += RemoveEvent;
        }

        public void AddEvent(UserEvent userEvent)
        {
            flowEvent.Controls.Add(userEvent);
        }

        public void FillEventList()
        {
            List<EventModel> eventModels = EventManager.FindAllEvents();
            foreach (EventModel eventModel in eventModels)
            {
                flowEvent.Controls.Add(new UserEvent(eventModel));
            }
        }

        private void btnUpdateEvents_Click_1(object sender, EventArgs e)
        {
           UpdateEvents();
        }

        private void btnCreateEvent_Click_1(object sender, EventArgs e)
        {
            gbCreateNewEvent.Visible = true;
        }

        private void btnConfirmEvent_Click(object sender, EventArgs e)
        {
            EventModel eventModel = EventManager.CreateNewEvent(tbEventName.Text, tbLocation.Text, tbDescription.Text,
                dtpStartDate.Value, dtpEndDate.Value);

            if (eventModel != null)
            {
                flowEvent.Controls.Add(new UserEvent(eventModel));
                List<EventModel> events = new List<EventModel>();
                events = EventManager.FindAllEvents();
                foreach (EventModel _event in events)
                {
                    if (eventModel.Name == _event.Name)
                    {
                        UserManager.RegisterUserForEvent(Settings.ActiveUser, _event);
                    }
                }
            }
        }

        private void UpdateEvents()
        {
            flowEvent.Controls.Clear();
            FillEventList();
        }

        private void RemoveEvent(EventModel eventModel)
        {
            if ( MessageBox.Show(("Weet je zeker dat je het event: " + eventModel.Name+ " wil verwijderen ?"),
                        "Weet je het zeker", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               eventModel.Destroy();
               UpdateEvents();
            }
        }

    }





}