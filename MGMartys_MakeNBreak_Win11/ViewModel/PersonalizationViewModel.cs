using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;
using MGMartys_MakeNBreak_Win11.Model;
using MGMartys_MakeNBreak_Win11.Utilities;
using ModernDashboard.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class PersonalizationViewModel : INotifyPropertyChanged
    {

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        #region Colors

        //  CheckBox Group - Set Taskbar and Startmenu to:

        // Set Taskbar and Startmenu to Light Theme Command
        private ICommand _rbtnTaskbarLight;
        public ICommand RbtnTaskbarLight
        {
            get
            {
                if (_rbtnTaskbarLight == null)
                {
                    _rbtnTaskbarLight = new RelayCommand(param => SetTaskbarLight());
                }
                return _rbtnTaskbarLight;
            }
        }

        // Set Taskbar Light
        public void SetTaskbarLight()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 1 /f";
            Process.Start(Exe, Checked);
            // Process.Start("wt", "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name SystemUsesLightTheme -Value 1");
        }

        // Set Taskbar and Startmenu to Dark Theme Command
        private ICommand _rbtnTaskbarDark;
        public ICommand RbtnTaskbarDark
        {
            get
            {
                if (_rbtnTaskbarDark == null)
                {
                    _rbtnTaskbarDark = new RelayCommand(param => SetTaskbarDark());
                }
                return _rbtnTaskbarDark;
            }
        }

        // Set Taskbar Dark
        public void SetTaskbarDark()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 0 /f";
            Process.Start(Exe, Checked);
            //          Process.Start("wt", "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name SystemUsesLightTheme -Value 0");
        }




        //  CheckBox Group - Set Apps to:

        // Set Apps to Light Theme Command
        private ICommand _rbtnAppsLight;
        public ICommand RbtnAppsLight
        {
            get
            {
                if (_rbtnAppsLight == null)
                {
                    _rbtnAppsLight = new RelayCommand(param => SetAppsLight());
                }
                return _rbtnAppsLight;
            }
        }

        // Set Apps Light
        public void SetAppsLight()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 1 /f";
            Process.Start(Exe, Checked);
            //          Process.Start("wt", "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name AppsUseLightTheme -Value 1");
        }

        // Set Apps to Dark Theme Command
        private ICommand _rbtnAppsDark;
        public ICommand RbtnAppsDark
        {
            get
            {
                if (_rbtnAppsDark == null)
                {
                    _rbtnAppsDark = new RelayCommand(param => SetAppsDark());
                }
                return _rbtnAppsDark;
            }
        }

        // Set Apps Dark
        public void SetAppsDark()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 0 /f";
            Process.Start(Exe, Checked);

            //          Process.Start("wt", "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name AppsUseLightTheme -Value 0");
        }




        //  CheckBox - Turn Transparency Off Command
        private Boolean _chckbxTransparencyEffects;
        public Boolean ChckbxTransparencyEffects
        {
            get => _chckbxTransparencyEffects;
            set
            {
                if (_chckbxTransparencyEffects == value)
                    return;

                _chckbxTransparencyEffects = value;
                OnPropertyChanged(nameof(ChckbxTransparencyEffects));
                TransparencyEffects();
            }
        }
        private void TransparencyEffects()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 0 /f";
            string Unchecked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 1 /f";
            
            if (ChckbxTransparencyEffects)
                Process.Start(Exe, Checked);
            //              Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name EnableTransparency -Value 0");
            else
                Process.Start(Exe, Unchecked);
            //              Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name EnableTransparency -Value 1");
        }




        //  CheckBox - Show accent color on Start and taskbar
        private Boolean _chckbxShowAccentStart;
        public Boolean ChckbxShowAccentStart
        {
            get => _chckbxShowAccentStart;
            set
            {
                if (_chckbxShowAccentStart == value)
                    return;

                _chckbxShowAccentStart = value;
                OnPropertyChanged(nameof(ChckbxShowAccentStart));
                ShowAccentStart();
            }
        }
        private void ShowAccentStart()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 0 /f";
            string Unchecked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v EnableTransparency /t REG_DWORD /d 1 /f";

            if (ChckbxShowAccentStart)
                Process.Start(Exe, Checked);
            // Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v ColorPrevalence /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name ColorPrevalence -Value 1");
            else
                Process.Start(Exe, Unchecked);
            // Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v ColorPrevalence /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name ColorPrevalence -Value 0");
        }




        //  CheckBox - Show accent color on title bars and windows borders
        private Boolean _chckbxShowAccentTitle;
        public Boolean ChckbxShowAccentTitle
        {
            get => _chckbxShowAccentTitle;
            set
            {
                if (_chckbxShowAccentTitle == value)
                    return;

                _chckbxShowAccentTitle = value;
                OnPropertyChanged(nameof(ChckbxShowAccentTitle));
                ShowAccentTitle();
            }
        }
        private void ShowAccentTitle()
        {
            string Exe = "Wt.exe";
            string Checked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\DWM\" /v ColorPrevalence /t REG_DWORD /d 1 /f";
            string Unchecked = "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\DWM\" /v ColorPrevalence /t REG_DWORD /d 0 /f";

            if (ChckbxShowAccentTitle)
                Process.Start(Exe, Checked);
            // Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\DWM\" /v ColorPrevalence /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\DWM' -Name ColorPrevalence -Value 1");
            else
                Process.Start(Exe, Unchecked);
            // Process.Start("wt", "Reg Add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\DWM\" /v ColorPrevalence /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\DWM' -Name ColorPrevalence -Value 0");
        }



        //  Button - Set Accent Color Command
        private ICommand _btnChangeAccentColor;
        public ICommand BtnChangeAccentColor
        {
            get
            {
                if (_btnChangeAccentColor == null)
                {
                    _btnChangeAccentColor = new RelayCommand(param => ChangeAccentColor());
                }
                return _btnChangeAccentColor;
            }
        }

        // Set Accent Color
        public void ChangeAccentColor()
        {
            
            string Click = "ms-settings:colors";
            Process.Start(Click);
            //          MessageBox.Show("Accent Clicked");
            //Process.Start("ms-settings:colors");
        }



        // Changed Pc Name
        private string _changedPcName;
        public string ChangedPcName
        {
            get => _changedPcName;
            set
            {
                _changedPcName = value;
                OnPropertyChanged("ChangedPcName");
            }
        }

        //  Button - ChangePcName
        private ICommand _btnChangePcName;
        public ICommand BtnChangePcName
        {
            get
            {
                if (_btnChangePcName == null)
                {
                    _btnChangePcName = new RelayCommand(param => ChangePcName());
                }
                return _btnChangePcName;
            }
        }

        public string GetChangedPcName()
        {
            return ChangedPcName;
        }

        // Change PC Name
        public void ChangePcName()
        {
            string Exe = "Wt.exe";
            string Click = "powershell Rename-Computer -NewName " + ChangedPcName;
            Process.Start(Exe, Click);
            //          MessageBox.Show("Accent Clicked");
           //Process.Start("wt.exe", "powershell Rename-Computer -NewName " + ChangedPcName);

        }


        #endregion Colors

        #region Start

        //  CheckBox - "Show recently added apps" Command
        private Boolean _chckbxRecentlyAddedApps;
        public Boolean ChckbxRecentlyAddedApps
        {
            get => _chckbxRecentlyAddedApps;
            set
            {
                if (_chckbxRecentlyAddedApps == value)
                    return;

                _chckbxRecentlyAddedApps = value;
                OnPropertyChanged(nameof(ChckbxRecentlyAddedApps));
                RecentlyAddedApps();
            }
        }
        private void RecentlyAddedApps()
        {
            string Exe = "wt.exe";
            string Checked = "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"HideRecentlyAddedApps\" /t REG_DWORD /d 1 /f";
            string Unchecked = "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"HideRecentlyAddedApps\" /t REG_DWORD /d 0 /f";

            if (ChckbxRecentlyAddedApps)
                Process.Start(Exe, Checked);
            // Process.Start("wt", "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"HideRecentlyAddedApps\" /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name HideRecentlyAddedApps -Value 1");
            else
                Process.Start(Exe, Unchecked);
            // Process.Start("wt", "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"HideRecentlyAddedApps\" /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name HideRecentlyAddedApps -Value 0");
        }

        

           


        //  CheckBox - "Show most used apps" Command
        private Boolean _chckbxMostUsedApps;
        public Boolean ChckbxMostUsedApps
        {
            get => _chckbxMostUsedApps;
            set
            {
                if (_chckbxMostUsedApps == value)
                    return;

                _chckbxMostUsedApps = value;
                OnPropertyChanged(nameof(ChckbxMostUsedApps));
                MostUsedApps();
            }
        }
        private void MostUsedApps()
        {
            string Exe = "wt.exe";
            string Checked = "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"ShowOrHideMostUsedApps\" /t REG_DWORD /d 2 /f";
            string Unchecked = "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"ShowOrHideMostUsedApps\" /t REG_DWORD /d 0 /f";

            if (ChckbxMostUsedApps)
                Process.Start(Exe, Checked);
            // Process.Start("wt", "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"ShowOrHideMostUsedApps\" /t REG_DWORD /d 2 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name ShowOrHideMostUsedApps -Value 2");

            else
                Process.Start(Exe, Unchecked);
            // Process.Start("wt", "reg add \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer\" /v \"ShowOrHideMostUsedApps\" /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKLM:\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer' -Name ShowOrHideMostUsedApps -Value 0");
        }




        //  CheckBox - "Show recently openend items in Start, Jump Lists and File Explorer Command
        private Boolean _chckbxRecentlyOpenedStart;
        public Boolean ChckbxRecentlyOpenedStart
        {
            get => _chckbxRecentlyOpenedStart;
            set
            {
                if (_chckbxRecentlyOpenedStart == value)
                    return;

                _chckbxRecentlyOpenedStart = value;
                OnPropertyChanged(nameof(ChckbxRecentlyOpenedStart));
                RecentlyOpenedStart();
            }
        }
        private void RecentlyOpenedStart()
        {
            string Exe = "wt.exe";
            string RegistryPath = @"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"Start_TrackDocs";
            string Type = @"REG_DWORD";
            string Checked = @"0";
            string Unchecked = @"1";
            string ArgsChecked = @"reg add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Checked + " /f";
            string ArgsUnchecked = @"reg add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Unchecked + " /f";

            if (ChckbxRecentlyOpenedStart)
                Process.Start(Exe, ArgsChecked);
            // Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"Start_TrackDocs\" /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name Start_TrackDocs -Value 0");
            else
                Process.Start(Exe, ArgsUnchecked);
            // Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"Start_TrackDocs\" /t REG_DWORD /d 1 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name Start_TrackDocs -Value 1");
        }

        #endregion Start

        #region Taskbar

    // Hide 'Taskbar Items'

        //  CheckBox - Hide 'Search'
        private Boolean _chckbxTaskbarItemSearch;
        public Boolean ChckbxTaskbarItemSearch
        {
            get => _chckbxTaskbarItemSearch;
            set
            {
                if (_chckbxTaskbarItemSearch == value)
                    return;

                _chckbxTaskbarItemSearch = value;
                OnPropertyChanged(nameof(ChckbxTaskbarItemSearch));
                TaskbarItemSearch();
            }
        }
        private void TaskbarItemSearch()
        {
            if (ChckbxTaskbarItemSearch)
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search\" /v \"SearchboxTaskbarMode\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name SearchboxTaskbarMode -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search\" /v \"SearchboxTaskbarMode\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search' -Name SearchboxTaskbarMode -Value 1");
        }
     

        //  CheckBox - Hide 'Task View'
        private Boolean _chckbxTaskbarItemTaskView;
        public Boolean ChckbxTaskbarItemTaskView
        {
            get => _chckbxTaskbarItemTaskView;
            set
            {
                if (_chckbxTaskbarItemTaskView == value)
                    return;

                _chckbxTaskbarItemTaskView = value;
                OnPropertyChanged(nameof(ChckbxTaskbarItemTaskView));
                TaskbarItemTaskView();
            }
        }
        private void TaskbarItemTaskView()
        {
            if (ChckbxTaskbarItemTaskView)
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"ShowTaskViewButton\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name ShowTaskViewButton -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"ShowTaskViewButton\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name ShowTaskViewButton -Value 1");
        }


        // CheckBox - Hide 'Widgets'
        private Boolean _chckbxTaskbarItemWidgets;
        public Boolean ChckbxTaskbarItemWidgets
        {
            get => _chckbxTaskbarItemWidgets;
            set
            {
                if (_chckbxTaskbarItemWidgets == value)
                    return;

                _chckbxTaskbarItemWidgets = value;
                OnPropertyChanged(nameof(ChckbxTaskbarItemWidgets));
                TaskbarItemWidgets();
            }
        }
        private void TaskbarItemWidgets()
        {
            if (ChckbxTaskbarItemWidgets)
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarDa\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarDa -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarDa\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarDa -Value 1");
        }


        // CheckBox - Hide 'Chat'
        private Boolean _chckbxTaskbarItemChat;
        public Boolean ChckbxTaskbarItemChat
        {
            get => _chckbxTaskbarItemChat;
            set
            {
                if (_chckbxTaskbarItemChat == value)
                    return;

                _chckbxTaskbarItemChat = value;
                OnPropertyChanged(nameof(ChckbxTaskbarItemChat));
                TaskbarItemChat();
            }
        }
        private void TaskbarItemChat()
        {
            if (ChckbxTaskbarItemChat)
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarMn\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarMn -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarMn\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarMn -Value 1");
        }



    // Hide 'System Tray Icons'

        //  CheckBox - Hide 'Pen Menu'
        private Boolean _chckbxSystemTrayIconPenMenu;
        public Boolean ChckbxSystemTrayIconPenMenu
        {
            get => _chckbxSystemTrayIconPenMenu;
            set
            {
                if (_chckbxSystemTrayIconPenMenu == value)
                    return;

                _chckbxSystemTrayIconPenMenu = value;
                OnPropertyChanged(nameof(ChckbxSystemTrayIconPenMenu));
                SystemTrayIconPenMenu();
            }
        }
        private void SystemTrayIconPenMenu()
        {
            if (ChckbxTaskbarItemSearch)
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace\" /v \"PenWorkspaceButtonDesiredVisibility\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace' -Name PenWorkspaceButtonDesiredVisibility -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace\" /v \"PenWorkspaceButtonDesiredVisibility\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace' -Name PenWorkspaceButtonDesiredVisibility -Value 1");
        }


        //  CheckBox - Hide 'Touch Keyboard'
        private Boolean _chckbxSystemTrayIconTouchKeyboard;
        public Boolean ChckbxSystemTrayIconTouchKeyboard
        {
            get => _chckbxSystemTrayIconTouchKeyboard;
            set
            {
                if (_chckbxSystemTrayIconTouchKeyboard == value)
                    return;

                _chckbxSystemTrayIconTouchKeyboard = value;
                OnPropertyChanged(nameof(ChckbxSystemTrayIconTouchKeyboard));
                SystemTrayIconTouchKeyboard();
            }
        }
        private void SystemTrayIconTouchKeyboard()
        {
            if (ChckbxSystemTrayIconTouchKeyboard)
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\TabletTip\\1.7\" /v \"TipbandDesiredVisibility \" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\TabletTip\\1.7' -Name TipbandDesiredVisibility -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\SOFTWARE\\Microsoft\\TabletTip\\1.7\" /v \"TipbandDesiredVisibility \" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\TabletTip\\1.7' -Name TipbandDesiredVisibility -Value 1");
        }


        // CheckBox - Hide 'Virtual Touchpad'
        private Boolean _chckbxSystemTrayIconVirtualTouchpad;
        public Boolean ChckbxSystemTrayIconVirtualTouchpad
        {
            get => _chckbxSystemTrayIconVirtualTouchpad;
            set
            {
                if (_chckbxSystemTrayIconVirtualTouchpad == value)
                    return;

                _chckbxSystemTrayIconVirtualTouchpad = value;
                OnPropertyChanged(nameof(ChckbxSystemTrayIconVirtualTouchpad));
                SystemTrayIconVirtualTouchpad();
            }
        }
        private void SystemTrayIconVirtualTouchpad()
        {
            if (ChckbxSystemTrayIconVirtualTouchpad)
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Touchpad\" /v \"TouchpadDesiredVisibility\"  \" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Touchpad' -Name TouchpadDesiredVisibility -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Touchpad\" /v \"TouchpadDesiredVisibility\"  \" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Touchpad' -Name TouchpadDesiredVisibility -Value 1");
        }


    // Taskbar Behaviors

        //  CheckBox - Taskbar Alignment
        private Boolean _chckbxTaskbarAlignment;
        public Boolean ChckbxTaskbarAlignment
        {
            get => _chckbxTaskbarAlignment;
            set
            {
                if (_chckbxTaskbarAlignment == value)
                    return;

                _chckbxTaskbarAlignment = value;
                OnPropertyChanged(nameof(ChckbxTaskbarAlignment));
                TaskbarAlignment();
            }
        }
        private void TaskbarAlignment()
        {
            if (ChckbxTaskbarAlignment)
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarAl\" /t REG_DWORD /d 0 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarAl -Value 0");
            else
                Process.Start("wt", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v \"TaskbarAl\" /t REG_DWORD /d 1 /f");
                // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced' -Name TaskbarAl -Value 1");
        }


        //  CheckBox - Automatically hide the taskbar - Off
        private Boolean _chckbxAutoHideTaskbar;
        public Boolean ChckbxAutoHideTaskbar
        {
            get => _chckbxAutoHideTaskbar;
            set
            {
                if (_chckbxAutoHideTaskbar == value)
                    return;

                _chckbxAutoHideTaskbar = value;
                OnPropertyChanged(nameof(ChckbxAutoHideTaskbar));
                AutoHideTaskbar();
            }
        }
        private void AutoHideTaskbar()
        {
            if (ChckbxAutoHideTaskbar)
            {
             // Process.Start("wt.exe", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3\" /v \"Settings\" /t REG_BINARY /d 30000000feffffff7af400000300000030000000300000000000000070050000000a0000a00500006000000001000000 /f");
                Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3' -Name Settings -Value ([byte[]](0x30,0x00,0x00,0x00,0xfe,0xff,0xff,0xff,0x7a,0xf4,0x00,0x00,0x03,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0xa0,0x05,0x00,0x00,0x60,0x00,0x00,0x00,0x01,0x00,0x00,0x00))");
                Process.Start("wt.exe", "taskkill /f /im explorer.exe");
                Process.Start("wt.exe", "powershell Start-Process explorer");

            }
            else
            {
             // Process.Start("wt.exe", "reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3\" /v \"Settings\" /t REG_BINARY /d 30000000feffffff7bf400000300000030000000300000000000000070050000000a0000a00500006000000001000000 /f");
                Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3' -Name Settings -Value ([byte[]](0x30,0x00,0x00,0x00,0xfe,0xff,0xff,0xff,0x7b,0xf4,0x00,0x00,0x03,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0xa0,0x05,0x00,0x00,0x60,0x00,0x00,0x00,0x01,0x00,0x00,0x00))");
                Process.Start("wt.exe", "taskkill /f /im explorer.exe");
                Process.Start("wt.exe", "powershell Start-Process explorer");
            }
        }

        #endregion Taskbar

    }
}

