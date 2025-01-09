using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcommerceWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            txtName = new TextBox();
            txtDescription = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            btnAdd = new Label();
            btnEdit = new Label();
            btnDelete = new Label();
            btnRefresh = new Label();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(353, 476);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridProducts;
            // 
            // txtName
            // 
            txtName.Location = new Point(462, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(198, 23);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(462, 74);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(198, 23);
            txtDescription.TabIndex = 2;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(462, 130);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(198, 23);
            txtPrice.TabIndex = 3;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(462, 180);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(200, 23);
            txtStock.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.AutoSize = true;
            btnAdd.Location = new Point(723, 33);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(38, 15);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "label1";
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnEdit
            // 
            btnEdit.AutoSize = true;
            btnEdit.Location = new Point(725, 79);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(38, 15);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "label1";
            btnEdit.Click += btnEdit_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(730, 140);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(38, 15);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "label1";
            btnDelete.Click += label1_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(731, 183);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(38, 15);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "label1";
            btnRefresh.Click += btnRefresh_Click_1;
            // 
            // Form1
            // 
            ClientSize = new Size(989, 500);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtDescription);
            Controls.Add(txtName);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Load += Form1_Load_1;
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridProducts(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                DeleteProduct(id);
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells["Id"].Value;
                EditProduct(id);
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
