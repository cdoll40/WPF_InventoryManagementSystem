using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_InventoryManagementSystem.Core;

namespace WPF_InventoryManagementSystem.MVVM.ViewModel {
    internal class MainViewModel : ObservableObject {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand InventoryViewCommand { get; set; }
        public RelayCommand PrintViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public InventoryViewModel InventoryVM { get; set; }
        public PrintViewModel PrintVM { get; set; }

        private object _currentView;

        public object CurrentView {
            get { return _currentView; }
            set {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() {

            HomeVM = new HomeViewModel();
            InventoryVM = new InventoryViewModel();
            PrintVM = new PrintViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = HomeVM;
            });

            InventoryViewCommand = new RelayCommand(o => {
                CurrentView = InventoryVM;
            });

            PrintViewCommand = new RelayCommand(o => {
                CurrentView = PrintVM;
            });
        }
    }
}
