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
                new MenuItems { MenuName = "Services", MenuImage = @"/Resources/Icons/services_icon.png" },
                new MenuItems { MenuName = "Remove Apps", MenuImage = @"/Resources/Icons/Apps_icon.png" },
                new MenuItems { MenuName = "Install Software", MenuImage = @"/Resources/Icons/Software_Icon.png" }
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            MenuItemsCollection.Filter += MenuItems_Filter;

            // Set Startup Page
            SelectedViewModel = new StartupViewModel();
        }

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        // Text Search Filter.
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }
       
        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if(string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            MenuItems _item = e.Item as MenuItems;
            if(_item.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
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
                    SelectedMenuItem = "Services";
                    break;
                case "Remove Apps":
                    SelectedViewModel = new AppsViewModel();
                    SelectedMenuItem = "Remove Apps";
                    break;
                case "Install Software":
                    SelectedViewModel = new SoftwareViewModel();
                    SelectedMenuItem = "Install Software";
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

        // Show PC View
        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }

        // This PC button Command
        private ICommand _pccommand;
        public ICommand ThisPCCommand
        {
            get
            {
                if (_pccommand == null)
                {
                    _pccommand = new RelayCommand(param => PCView());
                }
                return _pccommand;
            }
        }

        // Show Home View
        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }

        // Back button Command
        private ICommand _backHomeCommand;
        public ICommand BackHomeCommand
        {
            get
            {
                if (_backHomeCommand == null)
                {
                    _backHomeCommand = new RelayCommand(p => ShowHome());
                }
                return _backHomeCommand;
            }
        }

       

        // Close App
        public void CloseApp(object obj)
        {
            MainWindow win = obj as MainWindow;
            win.Close();
        }

        // Close App Command
        private ICommand _closeCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(p => CloseApp(p));
                }
                return _closeCommand;
            }
        }



        


    

    }
}
