﻿using System;
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
    public partial class MateriaalVerHuurForm : Form
    {
        private SocialMediaEventManager socialManager;

        public MateriaalVerHuurForm()
        {
            InitializeComponent();

            socialManager = new SocialMediaEventManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

         
        }

    }
}
