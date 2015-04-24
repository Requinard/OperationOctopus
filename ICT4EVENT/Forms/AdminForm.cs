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
            flowEvent.Controls.Clear();
            FillEventList();
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
            }
        }

    }





}