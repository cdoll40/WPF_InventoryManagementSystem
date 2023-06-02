using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_InventoryManagementSystem.Core;
using WPF_InventoryManagementSystem.MVVM.Model;

namespace WPF_InventoryManagementSystem.MVVM.ViewModel {
    internal class CategoriesViewModel : INotifyPropertyChanged {
        private DatabaseModel databaseModel;
        private List<Categories> categoriesDataList;
        //private List<Products> productsDataList;
        //private bool isProductsReadOnly = true;
        //private bool isEditingEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Categories> CategoriesDataList {
            get { return categoriesDataList; }
            set {
                categoriesDataList = value;
                OnPropertyChanged(nameof(CategoriesDataList));
            }
        }

        //public List<Products> ProductsDataList {
        //    get { return productsDataList; }
        //    set {
        //        productsDataList = value;
        //        OnPropertyChanged(nameof(ProductsDataList));
        //    }
        //}

        //public bool IsProductsReadOnly {
        //    get { return isProductsReadOnly; }
        //    set {
        //        isProductsReadOnly = value;
        //        OnPropertyChanged(nameof(IsProductsReadOnly));
        //    }
        //}

        //public bool IsEditingEnabled {
        //    get { return isEditingEnabled; }
        //    set {
        //        isEditingEnabled = value;
        //        OnPropertyChanged(nameof(IsEditingEnabled));
        //    }
        //}

        //public ICommand EnableEditingCommand { get; private set; }
        //public ICommand SaveChangesCommand { get; private set; }


        public CategoriesViewModel() {
            databaseModel = new DatabaseModel();
            CategoriesDataList = databaseModel.GetCategories();
            //ProductsDataList = databaseModel.GetProducts();

            //EnableEditingCommand = new RelayCommand(o => {
            //    IsProductsReadOnly = false;
            //    IsEditingEnabled = true;
            //});

            //SaveChangesCommand = new RelayCommand(o => {
            //    // Save the changes made in the DataGrids to the database
            //    databaseModel.UpdateCategories(CategoriesDataList);
            //    databaseModel.UpdateProducts(ProductsDataList);

            //    // Retrieve the original products from the database
            //    List<Products> originalProducts = databaseModel.GetProducts();

            //    // Create a dictionary to store the original products by their unique identifier
            //    Dictionary<int, Products> originalProductDict = originalProducts.ToDictionary(p => p.ProductId);

            //    // Handle added products
            //    foreach (Products updatedProduct in ProductsDataList) {
            //        if (!originalProductDict.ContainsKey(updatedProduct.ProductId)) {
            //            // Insert the addedProduct into the database
            //            databaseModel.InsertProduct(updatedProduct);
            //        }
            //    }

            //    // Handle deleted products
            //    foreach (Products originalProduct in originalProducts) {
            //        if (!ProductsDataList.Any(p => p.ProductId == originalProduct.ProductId)) {
            //            // Delete the deletedProduct from the database
            //            databaseModel.DeleteProduct(originalProduct);
            //        }
            //    }

            //    // Update the data in the DataGrids by retrieving the updated data from the database
            //    // Recalculate and update the total count
            //    foreach (var category in CategoriesDataList) {
            //        category.UpdateTotalCount();
            //    }
            //    CategoriesDataList = databaseModel.GetCategories();
            //    ProductsDataList = databaseModel.GetProducts();

            //    IsProductsReadOnly = true;
            //    IsEditingEnabled = false;





            //    //// Save the changes made in the DataGrids to the database
            //    //databaseModel.UpdateProducts(ProductsDataList);
            //    //databaseModel.UpdateCategories(CategoriesDataList);

            //    //// Update the data in the DataGrids by retrieving the updated data from the database
            //    //CategoriesDataList = databaseModel.GetCategories();
            //    //ProductsDataList = databaseModel.GetProducts();

            //    //IsCategoriesReadOnly = true;
            //    //IsProductsReadOnly = true;
            //    //IsEditingEnabled = false;
            //});
        }


    }
}
