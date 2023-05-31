using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPF_InventoryManagementSystem.MVVM.Model {
    public class DatabaseModel {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;user=root;password=root;database=ims;";

        public DatabaseModel() {
            connection = new MySqlConnection(connectionString);
        }

        public List<Categories> GetCategories() {
            List<Categories> data = new List<Categories>();

            string query = "SELECT * FROM categories";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    Categories category = new Categories();
                    category.CategoryId = reader.GetInt32("category_id");
                    category.CategoryName = reader.GetString("category_name");
                    category.ProductCount = reader.GetInt32("product_count");
                    category.TotalCount = reader.GetInt32("total_count");

                    data.Add(category);
                }
            }

            connection.Close();

            return data;
        }
        public List<Products> GetProducts() {
            List<Products> data = new List<Products>();

            string query = "SELECT * FROM products";
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();

            using (MySqlDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    Products product = new Products();
                    product.ProductId = reader.GetInt32("product_id");
                    product.ProductName = reader.GetString("product_name");
                    product.CategoryId = reader.GetInt32("category_id");
                    product.Count = reader.GetInt32("count");

                    data.Add(product);
                }
            }

            connection.Close();

            return data;
        }

        public void UpdateCategories(List<Categories> categories) {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                foreach (Categories category in categories) {
                    string query = $"UPDATE categories SET product_count = @ProductCount, total_count = @TotalCount WHERE category_id = @CategoryId";

                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@ProductCount", category.ProductCount);
                        command.Parameters.AddWithValue("@TotalCount", category.TotalCount);
                        command.Parameters.AddWithValue("@CategoryId", category.CategoryId);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public void UpdateProducts(List<Products> products) {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                foreach (Products product in products) {
                    string query = $"UPDATE products SET product_name = @ProductName, count = @Count WHERE product_id = @ProductId";

                    using (MySqlCommand command = new MySqlCommand(query, connection)) {
                        command.Parameters.AddWithValue("@ProductName", product.ProductName);
                        command.Parameters.AddWithValue("@Count", product.Count);
                        command.Parameters.AddWithValue("@ProductId", product.ProductId);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public void InsertProduct(Products product) {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                string query = "INSERT INTO products (product_id, product_name, category_id, count) VALUES (@ProductId, @ProductName, @CategoryId, @Count)";

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    command.Parameters.AddWithValue("@Count", product.Count);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void DeleteProduct(Products product) {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                connection.Open();

                string query = "DELETE FROM products WHERE product_id = @ProductId";

                using (MySqlCommand command = new MySqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

    }
}
