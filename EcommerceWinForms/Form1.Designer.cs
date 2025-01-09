using EcommerceModels;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EcommerceWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://localhost:7258/api/Product"; // Replace with your API base URL


        private async void LoadProducts()
        {
            try
            {
                var products = await _httpClient.GetFromJsonAsync<List<Product>>(ApiBaseUrl);
                dataGridView1.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load products: {ex.Message}");
            }
        }

        private async void AddProduct()
        {
            try
            {
                var product = new Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                var response = await _httpClient.PostAsJsonAsync(ApiBaseUrl, product);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product added successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show($"Failed to add product: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}");
            }
        }

        private async void EditProduct(int id)
        {
            try
            {
                var product = new Product
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                var response = await _httpClient.PutAsJsonAsync($"{ApiBaseUrl}/{id}", product);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product updated successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show($"Failed to update product: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing product: {ex.Message}");
            }
        }

        private async void DeleteProduct(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiBaseUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Product deleted successfully!");
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show($"Failed to delete product: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnEdit_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private DataGridView dataGridView1;
        private TextBox txtName;
        private TextBox txtDescription;
        private TextBox txtPrice;
        private TextBox txtStock;
        private Label btnAdd;
        private Label btnEdit;
        private Label btnDelete;
        private Label btnRefresh;
    }
}
