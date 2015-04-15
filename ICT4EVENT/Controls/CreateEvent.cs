using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4EVENT.Controls
{
    public partial class CreateEvent : UserControl
    {
        public CreateEvent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventManager.CreateNewEvent(tbEventName.Text, tbLocation.Text, tbDescription.Text, dateTimePicker1.Value,
                dateTimePicker2.Value);
        }
    }
}
