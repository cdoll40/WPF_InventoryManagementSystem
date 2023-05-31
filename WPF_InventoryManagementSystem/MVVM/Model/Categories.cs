using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace WPF_InventoryManagementSystem.MVVM.Model {
    public class Categories : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }


        private int productCount;
        public int ProductCount {
            get { return productCount; }
            set {
                if (productCount != value) {
                    productCount = value;
                    OnPropertyChanged(nameof(ProductCount));
                    UpdateTotalCount();
                }
            }
        }

        public int TotalCount { get; set; }

        public void UpdateTotalCount() {
            string connectionString = "server=localhost;user=root;password=root;database=ims;";
            using (var connection = new MySqlConnection(connectionString)) {
                connection.Open();

                // Retrieve the current product count from the database
                string getProductCountQuery = $"SELECT SUM(count) FROM products WHERE category_id = {CategoryId}";
                MySqlCommand getProductCountCommand = new MySqlCommand(getProductCountQuery, connection);
                int newProductCount = Convert.ToInt32(getProductCountCommand.ExecuteScalar());

                productCount = newProductCount;
                OnPropertyChanged(nameof(productCount));

                // Update the product_count column in the categories table
                string updateProductCountQuery = $"UPDATE categories SET product_count = {newProductCount} WHERE category_id = {CategoryId}";
                MySqlCommand updateProductCountCommand = new MySqlCommand(updateProductCountQuery, connection);
                updateProductCountCommand.ExecuteNonQuery();

                // Retrieve the updated total count from the database
                string getTotalCountQuery = "SELECT COUNT(*) FROM products WHERE category_id = @categoryId";
                MySqlCommand getTotalCountCommand = new MySqlCommand(getTotalCountQuery, connection);
                getTotalCountCommand.Parameters.AddWithValue("@categoryId", CategoryId);
                int newTotalCount = Convert.ToInt32(getTotalCountCommand.ExecuteScalar());

                TotalCount = newTotalCount;
                OnPropertyChanged(nameof(TotalCount));

                // Update the total_count column in the categories table
                string updateTotalCountQuery = $"UPDATE categories SET total_count = {newTotalCount} WHERE category_id = @categoryId";
                MySqlCommand updateTotalCountCommand = new MySqlCommand(updateTotalCountQuery, connection);
                updateTotalCountCommand.Parameters.AddWithValue("@categoryId", CategoryId);
                updateTotalCountCommand.ExecuteNonQuery();

                connection.Close();

            }

        }
    }
}
