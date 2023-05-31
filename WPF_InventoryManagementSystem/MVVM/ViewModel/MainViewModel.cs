using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_InventoryManagementSystem.Core;

namespace WPF_InventoryManagementSystem.MVVM.ViewModel {
    internal class MainViewModel : ObservableObject {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public InventoryViewModel DiscoveryVM { get; set; }

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
            DiscoveryVM = new InventoryViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => {
                CurrentView = HomeVM;
            });

            DiscoveryViewCommand = new RelayCommand(o => {
                CurrentView = DiscoveryVM;
            });
        }
    }
}
