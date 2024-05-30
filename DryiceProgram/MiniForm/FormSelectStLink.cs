using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DryiceProgram.MiniForm {
    public partial class FormSelectStLink : Form {
        public FormSelectStLink() {
            InitializeComponent();
        }

        private void cbb_stLink_SelectedIndexChanged(object sender, EventArgs e) {
            this.Close();
        }
    }
}
