using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouvenirApp
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeOrRemove_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnChangeOrRemove.Visible = false;
            btnSeeAll.Visible = false;

            btnChange.Visible = true;
            btnRemove.Visible = true;
            lblId.Visible = true;
            txtId.Visible = true;
        }
    }
}
