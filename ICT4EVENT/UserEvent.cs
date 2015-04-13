﻿using System;
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