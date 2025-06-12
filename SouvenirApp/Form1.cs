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

            SeeAll(sender, e);
        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeOrRemove_Click(object sender, EventArgs e)
        {
            ChageVisible(false, false, true, true, true, true, true);
 
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
            SeeAll(sender, e);
        }

     

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи id, натисни бутона Find,ако искате да изтриете този запис натиснете Remove.");
                txtId.Focus();
                return;
            }

            if (!IsValidId())
            {
                return;
            }

            souvenirController.Delete(int.Parse(txtId.Text));
            MessageBox.Show("Елементът е изтрит!");

            lstbSouvenirs.Items.RemoveAt(int.Parse(txtId.Text)-1);
            SeeAll(sender, e);

            ChageVisible(true, true,false, false, false, false, false);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
           
            if(!IsValidId())
            {
                return;
            }

            Souvenir searchSouvenir = souvenirController.GetById(int.Parse(txtId.Text));

            txtName.Text = searchSouvenir.Name;
            txtPrice.Text = searchSouvenir.Price.ToString();
            txtDescription.Text = searchSouvenir.Description;
            cmbTypes.Text = searchSouvenir.Type.Name;

        }

       

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Въведи id, натисни бутона Find,ако искате да промените този запис натиснете change.");
                txtId.Focus();
                return;
            }

            if (!IsValidId())
            {
                return;
            }

            Souvenir changedSouvenir = new Souvenir()
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Description = txtDescription.Text,
                TypeId = (int)cmbTypes.SelectedValue
            };

            souvenirController.Update(int.Parse(txtId.Text),changedSouvenir);
            MessageBox.Show("Елементът е променен!");

            SeeAll(sender, e);
            ChageVisible(true, true, false, false, false, false, false);
        }

        public bool IsValidId()
        {
            bool isValidId = int.TryParse(txtId.Text, out int id);

            if (!isValidId)
            {
                MessageBox.Show("Не правелен формат на id!");
                return false;
            }


            if (souvenirController.GetById(id) == null)
            {
                MessageBox.Show("Няма такова id!");
                return false;
            }

            return true;
        }

        private void SeeAll(object sender, EventArgs e)
        {
            List<Souvenir> allSouvenirs = souvenirController.GetAllSоuvenirs();
            lstbSouvenirs.Items.Clear();
            foreach (var souvenir in allSouvenirs)
            {
                lstbSouvenirs.Items.Add($"{souvenir.Id}. {souvenir.Name} - Price: {souvenir.Price} Type: {souvenir.Type.Name}");
            }
        }


        private void ChageVisible(bool btnAddVisiale, bool btnCnageOrRemoveVisiale, 
            bool btnChangeVisiale, bool btnRemoveVisiale, bool btnFindVisiale,bool lblIdVisiable,
             bool txtIdVisible)
        {
            btnAdd.Visible = btnAddVisiale;
            btnChangeOrRemove.Visible = btnCnageOrRemoveVisiale;

            btnChange.Visible = btnChangeVisiale;
            btnFind.Visible = btnFindVisiale;
            btnRemove.Visible = btnRemoveVisiale;
            lblId.Visible = lblIdVisiable;
            txtId.Visible = txtIdVisible;
;
        }
    }
}

