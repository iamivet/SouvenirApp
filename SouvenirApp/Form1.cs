using SouvenirApp.Controllers;
using SouvenirApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SouvenirApp
{
    public partial class Form1 : Form
    {
        private SouvenirController souvenirController = new SouvenirController();
        private SouvenirTypeController souvenirTypeController = new SouvenirTypeController();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<SouvenirType> allTypes = souvenirTypeController.GetAllSоuvenirTypes()
;
            cmbTypes.DataSource = allTypes;
            cmbTypes.DisplayMember = "Name";
            cmbTypes.ValueMember = "Id";

            btnSeeAll_Click(sender, e);
        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeOrRemove_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnChangeOrRemove.Visible = false;

            btnChange.Visible = true;
            btnRemove.Visible = true;
            lblId.Visible = true;
            txtId.Visible = true;
        }

        private void ClearScreen()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
            cmbTypes.Text = "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Въведете данни!");
                txtPrice.Focus();
                return;
            }

            bool isValidPrice = decimal.TryParse(txtPrice.Text, out decimal price);

            if (!isValidPrice)
            {
                MessageBox.Show("Въведете правелен формат на данните!");
            }

            Souvenir newSouvenir = new Souvenir();
            newSouvenir.Name = txtName.Text;
            newSouvenir.Price = price;

            newSouvenir.TypeId = (int)cmbTypes.SelectedValue;
            newSouvenir.Type = souvenirTypeController.GetById(newSouvenir.TypeId);
            newSouvenir.Description = txtDescription.Text;

            souvenirController.Create(newSouvenir);
            MessageBox.Show("Записът е успешно добавен!");
            lstbSouvenirs.Items.Add($"{newSouvenir.Id}. {newSouvenir.Name} - Price: {newSouvenir.Price} Type:{newSouvenir.Type.Name}");
            ClearScreen();
            btnSeeAll_Click(sender, e);
        }

        private void btnSeeAll_Click(object sender, EventArgs e)
        {
            List<Souvenir> allSouvenirs = souvenirController.GetAllSоuvenirs();
            lstbSouvenirs.Items.Clear();
            foreach (var souvenir in allSouvenirs)
            {
                lstbSouvenirs.Items.Add($"{souvenir.Id}. {souvenir.Name} - Price: {souvenir.Price} Type: {souvenir.Type.Name}");
            }
        }


    }
}

