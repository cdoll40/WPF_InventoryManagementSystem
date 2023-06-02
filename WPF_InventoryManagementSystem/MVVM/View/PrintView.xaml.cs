using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_InventoryManagementSystem.MVVM.Model;

namespace WPF_InventoryManagementSystem.MVVM.View {
    /// <summary>
    /// Interaction logic for PrintView.xaml
    /// </summary>
    public partial class PrintView : UserControl {

        private DatabaseModel databaseModel;
        private List<Categories> CategoriesDataList;

        public string CurrentDateTime { get; set; }

        public PrintView() {
            InitializeComponent();

            databaseModel = new DatabaseModel();
            CategoriesDataList = databaseModel.GetCategories();

            // Set the current date and time
            CurrentDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

            // Set the data context of the window to itself
            DataContext = this;

            // Set the ItemsSource of the categoriesDataGrid to the CategoriesDataList
            categoriesDataGrid.ItemsSource = CategoriesDataList;
        }
    }
}
