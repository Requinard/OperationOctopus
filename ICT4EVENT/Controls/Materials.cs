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
    public partial class Materials : UserControl
    {
        Image Image{ get; set; }

        string Name{ get; set; }

        string Description { get; set; }
        public Materials(string name, string description)
        {
            InitializeComponent();
            this.Name = name;
            this.Description = description;
        }
    }
}
