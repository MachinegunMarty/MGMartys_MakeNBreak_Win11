/// <summary>
/// ViewModel - [ "The Connector" ]
/// ViewModel exposes data contained in the Model objects to the View. The ViewModel performs 
/// all modifications made to the Model data.
/// </summary>

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using MGMartys_MakeNBreak_Win11.Model;
using MGMartys_MakeNBreak_Win11.Utilities;


namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties,
        // passing these settings to the underlying view.
        private CollectionViewSource MenuItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management,
        // custom sorting, filtering, and grouping.
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public MainWindowViewModel()
        {
            // ObservableCollection represents a dynamic data collection that provides notifications when items
            // get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = @"/Resources/Icons/Home_Icon.png" },
                new MenuItems { MenuName = "Desktop", MenuImage = @"/Resources/Icons/Desktop_Icon.png" },
                new MenuItems { MenuName = "Gaming", MenuImage = @"/Resources/Icons/Gamepad_Icon.png" },
                new MenuItems { MenuName = "Control Panel", MenuImage = @"/Resources/Icons/ControlPanel_Icon.png" },
                new MenuItems { MenuName = "Settings", MenuImage = @"/Resources/Icons/Settings_Icon.png" },
                new MenuItems { MenuName = "Services", MenuImage = @"/Resources/Icons/Services_Icon.png" },
                new MenuItems { MenuName = "Apps", MenuImage = @"/Resources/Icons/Apps_icon.png" },
                new MenuItems { MenuName = "Winget", MenuImage = @"/Resources/Icons/Winget_Icon_Edit.png" },
                new MenuItems { MenuName = "WSL", MenuImage = @"/Resources/Icons/WSL_Icon_Edit.png" }
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
         

            // Set Startup Page
            SelectedViewModel = new StartupViewModel();
        }

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        // Selected ViewModel
        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        // Selected NavItem
        private object _selectedMenuItem;
        public object SelectedMenuItem
        {
            get => _selectedMenuItem;
            set { _selectedMenuItem = value; OnPropertyChanged("SelectedMenuItem"); }
        }

       

        // Switch Views
        public void SwitchViews(object parameter)
        {
            switch(parameter)
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    SelectedMenuItem = "Home";
                   
                    break;
                case "Desktop":
                    SelectedViewModel = new DesktopViewModel();
                    SelectedMenuItem = "Desktop";
                    break;
                case "Gaming":
                    SelectedViewModel = new GamingViewModel();
                    SelectedMenuItem = "Gaming";
                    break;
                case "Control Panel":
                    SelectedViewModel = new ControlPanelViewModel();
                    SelectedMenuItem = "Control Panel";
                    break;
                case "Settings":
                    SelectedViewModel = new SettingsViewModel();
                    SelectedMenuItem = "Settings";
                    break;
                case "Services":
                    SelectedViewModel = new ServicesViewModel();
                    SelectedMenuItem = "Disable Services";
                    break;
                case "Apps":
                    SelectedViewModel = new AppsViewModel();
                    SelectedMenuItem = "Remove Apps";
                    break;
                case "Winget":
                    SelectedViewModel = new WingetViewModel();
                    SelectedMenuItem = "Install Software with Winget";
                    break;
                case "WSL":
                    SelectedViewModel = new WSLViewModel();
                    SelectedMenuItem = "Windows Subsystem for Linux";
                    break;
                default:
                    SelectedViewModel = new HomeViewModel();
                    SelectedMenuItem = "Home";
                    break;
            }
        }

        // Menu Button Command
        private ICommand _menucommand;
        public ICommand MenuCommand
        {
            get
            {
                if (_menucommand == null)
                {
                    _menucommand = new RelayCommand(param => SwitchViews(param));
                }
                return _menucommand;
            }
        }

           


    

    }
}
