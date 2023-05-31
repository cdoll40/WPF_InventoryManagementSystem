using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_InventoryManagementSystem.Core;

namespace WPF_InventoryManagementSystem.MVVM.ViewModel {
    internal class MainInvViewModel : ObservableObject {

        public RelayCommand CategoriesViewCommand { get; set; }
        public RelayCommand ProductsViewCommand { get; set; }

        public CategoriesViewModel CategoriesVM { get; set; }
        public ProductsViewModel ProductsVM { get; set; }

        private object _currentView;

        public object CurrentView {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainInvViewModel() {

            CategoriesVM = new CategoriesViewModel();
            ProductsVM = new ProductsViewModel();

            CurrentView = CategoriesVM;

            CategoriesViewCommand = new RelayCommand(o => {
                CurrentView = CategoriesVM;
            });

            ProductsViewCommand = new RelayCommand(o => {
                CurrentView = ProductsVM;
            });
        }
    }
}
