
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml.Linq;
using MGMartys_MakeNBreak_Win11.Model;
using Microsoft.Win32;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class DesktopViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

#region Context Menu


        //  CheckBox - "Get the "Classic" right click menu back" Command

        private Boolean _chckbxContextMenuClassicRightClickMenu;
        public Boolean ChckbxContextMenuClassicRightClickMenu
        {
            get => _chckbxContextMenuClassicRightClickMenu;
            set
            {
                if (_chckbxContextMenuClassicRightClickMenu == value)
                    return;

                _chckbxContextMenuClassicRightClickMenu = value;
                OnPropertyChanged(nameof(ChckbxContextMenuClassicRightClickMenu));
                ContextMenuClassicRightClickMenu();
            }
        }
        private void ContextMenuClassicRightClickMenu()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\";
            string Name = "InprocServer32";

            string ArgsChecked = @"Reg Add " + RegistryPath + Name + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /f";
            
            if (ChckbxContextMenuClassicRightClickMenu)
            {
                   Process.Start(Exe, ArgsChecked);
                }
                else
                    Process.Start(Exe, ArgsUnchecked);
            }


        //  CheckBox - "Enable New "Wide" Context Menu - Command"
        private Boolean _chckbxContextMenuNewWideContextMenu;
        public Boolean ChckbxContextMenuNewWideContextMenu
        {
            get => _chckbxContextMenuNewWideContextMenu;
            set
            {
                if (_chckbxContextMenuNewWideContextMenu == value)
                    return;

                _chckbxContextMenuNewWideContextMenu = value;
                OnPropertyChanged(nameof(ChckbxContextMenuNewWideContextMenu));
                ContextMenuNewWideContextMenu();
            }
        }
        private void ContextMenuNewWideContextMenu()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\FlightedFeatures";
            string Name = "ImmersiveContextMenu";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxContextMenuNewWideContextMenu)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Disable "Search on Internet" prompt in "Open with" - Command

        private Boolean _chckbxContextMenuSearchOnInternetContextMenu;
        public Boolean ChckbxContextMenuSearchOnInternetContextMenu
        {
            get => _chckbxContextMenuSearchOnInternetContextMenu;
            set
            {
                if (_chckbxContextMenuSearchOnInternetContextMenu == value)
                    return;

                _chckbxContextMenuSearchOnInternetContextMenu = value;
                OnPropertyChanged(nameof(ChckbxContextMenuSearchOnInternetContextMenu));
                ContextMenuSearchOnInternetContextMenu();
            }
        }

        public void ContextMenuSearchOnInternetContextMenu()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "NoInternetOpenWith";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxContextMenuSearchOnInternetContextMenu)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

#region Desktop Settings



        // Checkbox - Maximize wallpaper quality - Command

        private Boolean _chckbxDesktopSettingsMaximizeWallpaperQuality;
        public Boolean ChckbxDesktopSettingsMaximizeWallpaperQuality
        {
            get => _chckbxDesktopSettingsMaximizeWallpaperQuality;
            set
            {
                if (_chckbxDesktopSettingsMaximizeWallpaperQuality == value)
                    return;

                _chckbxDesktopSettingsMaximizeWallpaperQuality = value;
                OnPropertyChanged(nameof(ChckbxDesktopSettingsMaximizeWallpaperQuality));
                DesktopSettingsMaximizeWallpaperQuality();
            }
        }

        public void DesktopSettingsMaximizeWallpaperQuality()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = "JPEGImportQuality";
            string Type = "REG_DWORD";
            string Value = "100";
            string Default = "70";
            string ArgsChecked = "Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = "Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxDesktopSettingsMaximizeWallpaperQuality)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Open Menu's faster - Command

        private Boolean _chckbxDesktopSettingsOpenMenusFaster;
        public Boolean ChckbxDesktopSettingsOpenMenusFaster
        {
            get => _chckbxDesktopSettingsOpenMenusFaster;
            set
            {
                if (_chckbxDesktopSettingsOpenMenusFaster == value)
                    return;

                _chckbxDesktopSettingsOpenMenusFaster = value;
                OnPropertyChanged(nameof(ChckbxDesktopSettingsOpenMenusFaster));
                DesktopSettingsOpenMenusFaster();
            }
        }

        public void DesktopSettingsOpenMenusFaster()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = "MenuShowDelay";
            string Type = "REG_SZ";
            string Value = "8";
            string Default = "400";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxDesktopSettingsOpenMenusFaster)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Reduces the time the system waits when clicking 'End Task' in 'Task Manager' - Command

        private Boolean _chckbxDesktopSettingsReduceTimeSystemWaitsEndTask;
        public Boolean ChckbxDesktopSettingsReduceTimeSystemWaitsEndTask
        {
            get => _chckbxDesktopSettingsReduceTimeSystemWaitsEndTask;
            set
            {
                if (_chckbxDesktopSettingsReduceTimeSystemWaitsEndTask == value)
                    return;

                _chckbxDesktopSettingsReduceTimeSystemWaitsEndTask = value;
                OnPropertyChanged(nameof(ChckbxDesktopSettingsReduceTimeSystemWaitsEndTask));
                DesktopSettingsReduceTimeSystemWaitsEndTask();
            }
        }

        public void DesktopSettingsReduceTimeSystemWaitsEndTask()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = "HungAppTimeout";
            string Type = "REG_SZ";
            string Value = "1000";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxDesktopSettingsReduceTimeSystemWaitsEndTask)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Reduces time to wait to kill service that are not responding - Command

        private Boolean _chckbxDesktopSettingsReduceTimeToWaitKillService;
        public Boolean ChckbxDesktopSettingsReduceTimeToWaitKillService
        {
            get => _chckbxDesktopSettingsReduceTimeToWaitKillService;
            set
            {
                if (_chckbxDesktopSettingsReduceTimeToWaitKillService == value)
                    return;

                _chckbxDesktopSettingsReduceTimeToWaitKillService = value;
                OnPropertyChanged(nameof(ChckbxDesktopSettingsReduceTimeToWaitKillService));
                DesktopSettingsReduceTimeToWaitKillService();
            }
        }

        public void DesktopSettingsReduceTimeToWaitKillService()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = @"LowLevelHooksTimeout";
            string Type = @"REG_DWORD";
            string Value = @"1000";
            
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxDesktopSettingsReduceTimeToWaitKillService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

#region File System

        // File System


        // Checkbox - Don't Show "Potentially Harmfull File - Open" when installing/ opening from network - Command

        private Boolean _chckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile;
        public Boolean ChckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile
        {
            get => _chckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile;
            set
            {
                if (_chckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile == value)
                    return;

                _chckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile = value;
                OnPropertyChanged(nameof(ChckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile));
                DesktopSettingsFileSystemDontShowPotentiallyHarmfullFile();
            }
        }

        public void DesktopSettingsFileSystemDontShowPotentiallyHarmfullFile()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Group Policy Objects\\{3D2C7559-33D6-4493-AC1F-4DC5F8DB73E5}Machine\\Software\\Policies\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3\"";
            string RegistryPath2 = "\"HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\\Zones\\3\"";
            string Name = "1806";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = @"Reg Add " + RegistryPath2 + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = @"Reg Add " + RegistryPath2 + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile)
            {
               Process.Start(Exe, ArgsChecked);
               Process.Start(Exe, ArgsChecked2);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
                Process.Start(Exe, ArgsUnchecked2);
        }

        // Checkbox - Don't check for Low Disk Space in the background - Command

        private Boolean _chckbxFileSystemDontCheckLowDisk;
        public Boolean ChckbxFileSystemDontCheckLowDisk
        {
            get => _chckbxFileSystemDontCheckLowDisk;
            set
            {
                if (_chckbxFileSystemDontCheckLowDisk == value)
                    return;

                _chckbxFileSystemDontCheckLowDisk = value;
                OnPropertyChanged(nameof(ChckbxFileSystemDontCheckLowDisk));
                FileSystemDontCheckLowDisk();
            }
        }

        public void FileSystemDontCheckLowDisk()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "NoLowDiskSpaceChecks";
            string Type = "REG_DWORD";
            string Value = "1";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxFileSystemDontCheckLowDisk)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Do not track Shell shortcuts during roaming - Command

        private Boolean _chckbxFileSystemDoNotTrackShell;
        public Boolean ChckbxFileSystemDoNotTrackShell
        {
            get => _chckbxFileSystemDoNotTrackShell;
            set
            {
                if (_chckbxFileSystemDoNotTrackShell == value)
                    return;

                _chckbxFileSystemDoNotTrackShell = value;
                OnPropertyChanged(nameof(ChckbxFileSystemDoNotTrackShell));
                FileSystemDoNotTrackShell();
            }
        }

        public void FileSystemDoNotTrackShell()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "LinkResolveIgnoreLinkInfo";
            string Type = "REG_DWORD";
            string Value = "1";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxFileSystemDoNotTrackShell)
            {
                
                    Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Do not use the search-based method when resolving shell shortcuts  - Command

        private Boolean _chckbxFileSystemDoNotUseSearch;
        public Boolean ChckbxFileSystemDoNotUseSearch
        {
            get => _chckbxFileSystemDoNotUseSearch;
            set
            {
                if (_chckbxFileSystemDoNotUseSearch == value)
                    return;

                _chckbxFileSystemDoNotUseSearch = value;
                OnPropertyChanged(nameof(ChckbxFileSystemDoNotUseSearch));
                FileSystemDoNotUseSearch();
            }
        }

        public void FileSystemDoNotUseSearch()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "NoResolveSearch";
            string Type = "REG_DWORD";
            string Value = "1";


            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxFileSystemDoNotUseSearch)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Do not use the tracking-based method when resolving shell shortcuts - Command

        private Boolean _chckbxFileSystemDoNotUseTracking;
        public Boolean ChckbxFileSystemDoNotUseTracking
        {
            get => _chckbxFileSystemDoNotUseTracking;
            set
            {
                if (_chckbxFileSystemDoNotUseTracking == value)
                    return;

                _chckbxFileSystemDoNotUseTracking = value;
                OnPropertyChanged(nameof(ChckbxFileSystemDoNotUseTracking));
                FileSystemDoNotUseTracking();
            }
        }

        public void FileSystemDoNotUseTracking()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "NoResolveTrack";
            string Type = "REG_DWORD";
            string Value = "1";


            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxFileSystemDoNotUseTracking)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

#region Navigation Pane

        // Checkbox - Add Recycle Bin to Navigation Pane - Command

        private Boolean _chckbxNavigationPaneAddRecycleBin;
        public Boolean ChckbxNavigationPaneAddRecycleBin
        {
            get => _chckbxNavigationPaneAddRecycleBin;
            set
            {
                if (_chckbxNavigationPaneAddRecycleBin == value)
                    return;

                _chckbxNavigationPaneAddRecycleBin = value;
                OnPropertyChanged(nameof(ChckbxNavigationPaneAddRecycleBin));
                NavigationPaneAddRecycleBin();
            }
        }

        public void NavigationPaneAddRecycleBin()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Classes\\CLSID\\{645FF040-5081-101B-9F08-00AA002F954E}";
            string Name = "System.IsPinnedToNameSpaceTree";
            string Type = "REG_DWORD";
            string Value = "1";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /f";

            if (ChckbxNavigationPaneAddRecycleBin)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Set icon cache size to 4096 KB - Command

        private Boolean _chckbxNavigationPaneSetIconCache;
        public Boolean ChckbxNavigationPaneSetIconCache
        {
            get => _chckbxNavigationPaneSetIconCache;
            set
            {
                if (_chckbxNavigationPaneSetIconCache == value)
                    return;

                _chckbxNavigationPaneSetIconCache = value;
                OnPropertyChanged(nameof(ChckbxNavigationPaneSetIconCache));
                NavigationPaneSetIconCache();
            }
        }

        public void NavigationPaneSetIconCache()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = "\"Max Cached Icons\"";
            string Type = "REG_SZ";
            string Value = "4096";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxNavigationPaneSetIconCache)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Enable File System long paths - Command

        private Boolean _chckbxNavigationPaneEnableFileSystemLong;
        public Boolean ChckbxNavigationPaneEnableFileSystemLong
        {
            get => _chckbxNavigationPaneEnableFileSystemLong;
            set
            {
                if (_chckbxNavigationPaneEnableFileSystemLong == value)
                    return;

                _chckbxNavigationPaneEnableFileSystemLong = value;
                OnPropertyChanged(nameof(ChckbxNavigationPaneEnableFileSystemLong));
                NavigationPaneEnableFileSystemLong();
            }
        }

        public void NavigationPaneEnableFileSystemLong()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKLM\\SYSTEM\\CurrentControlSet\\Policies";
            string Name = "LongPathsEnabled";
            string Type = "REG_DWORD";
            string Value = "1";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxNavigationPaneEnableFileSystemLong)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Set Windows Startup delay to 0 ms - Command

        private Boolean _chckbxNavigationPaneSetWindowsStartupDelay;
        public Boolean ChckbxNavigationPaneSetWindowsStartupDelay
        {
            get => _chckbxNavigationPaneSetWindowsStartupDelay;
            set
            {
                if (_chckbxNavigationPaneSetWindowsStartupDelay == value)
                    return;

                _chckbxNavigationPaneSetWindowsStartupDelay = value;
                OnPropertyChanged(nameof(ChckbxNavigationPaneSetWindowsStartupDelay));
                NavigationPaneSetWindowsStartupDelay();
            }
        }

        public void NavigationPaneSetWindowsStartupDelay()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKLM\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";
            string Name = "StartupDelayInMSec";
            string Type = "REG_DWORD";
            string Value = "0";


            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /f";


            if (ChckbxNavigationPaneSetWindowsStartupDelay)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

#region Reboot, Shutdown or Logout

        // Checkbox - Auto Close 'Apps' - Command

        private Boolean _chckbxRebootShutdownLogoutAutoCloseApps;
        public Boolean ChckbxRebootShutdownLogoutAutoCloseApps
        {
            get => _chckbxRebootShutdownLogoutAutoCloseApps;
            set
            {
                if (_chckbxRebootShutdownLogoutAutoCloseApps == value)
                    return;

                _chckbxRebootShutdownLogoutAutoCloseApps = value;
                OnPropertyChanged(nameof(ChckbxRebootShutdownLogoutAutoCloseApps));
                RebootShutdownLogoutAutoCloseApps();
            }
        }

        public void RebootShutdownLogoutAutoCloseApps()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = "AutoEndTasks";
            string Type = "REG_SZ";
            string Value = "1";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxRebootShutdownLogoutAutoCloseApps)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Wait time before closing 'Apps' - Command

        private Boolean _chckbxRebootShutdownLogoutWaitTimeBeforeClosingApps;
        public Boolean ChckbxRebootShutdownLogoutWaitTimeBeforeClosingApps
        {
            get => _chckbxRebootShutdownLogoutWaitTimeBeforeClosingApps;
            set
            {
                if (_chckbxRebootShutdownLogoutWaitTimeBeforeClosingApps == value)
                    return;

                _chckbxRebootShutdownLogoutWaitTimeBeforeClosingApps = value;
                OnPropertyChanged(nameof(ChckbxRebootShutdownLogoutWaitTimeBeforeClosingApps));
                RebootShutdownLogoutWaitTimeBeforeClosingApps();
            }
        }

        public void RebootShutdownLogoutWaitTimeBeforeClosingApps()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\"";
            string Name = "WaitToKillAppTimeout";
            string Type = "REG_SZ";
            string Value = "4096";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxRebootShutdownLogoutWaitTimeBeforeClosingApps)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Wait time before stopping 'Services' - Command

        private Boolean _chckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices;
        public Boolean ChckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices
        {
            get => _chckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices;
            set
            {
                if (_chckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices == value)
                    return;

                _chckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices = value;
                OnPropertyChanged(nameof(ChckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices));
                RebootShutdownLogoutWaitTimeBeforeStoppingServices();
            }
        }

        public void RebootShutdownLogoutWaitTimeBeforeStoppingServices()
        {
            string Exe = "Wt.exe";
            string RegistryPath = "HKLM\\SYSTEM\\CurrentControlSet\\Control";
            string Name = "WaitToKillServiceTimeout";
            string Type = "REG_SZ";
            string Value = "2000";
            string Default = "5000";

            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Suggestions


        // CheckBox - Start Menu Suggestions - Command
        private Boolean _chckbxSuggestionsStartMenuSuggestions;
        public Boolean ChckbxSuggestionsStartMenuSuggestions
        {
            get => _chckbxSuggestionsStartMenuSuggestions;
            set
            {
                if (_chckbxSuggestionsStartMenuSuggestions == value)
                    return;

                _chckbxSuggestionsStartMenuSuggestions = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsStartMenuSuggestions));
                SuggestionsStartMenuSuggestions();
            }
        }

        private void SuggestionsStartMenuSuggestions()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SystemPaneSuggestionsEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsStartMenuSuggestions)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // CheckBox - Show suggestions occasionally - Command
        private Boolean _chckbxSuggestionsShowSuggestionsOccasionally;
        public Boolean ChckbxSuggestionsShowSuggestionsOccasionally
        {
            get => _chckbxSuggestionsShowSuggestionsOccasionally;
            set
            {
                if (_chckbxSuggestionsShowSuggestionsOccasionally == value)
                    return;

                _chckbxSuggestionsShowSuggestionsOccasionally = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsShowSuggestionsOccasionally));
                SuggestionsShowSuggestionsOccasionally();
            }
        }

        private void SuggestionsShowSuggestionsOccasionally()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SubscribedContent-338388Enabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsShowSuggestionsOccasionally)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // CheckBox - Show suggestions in timeline - Command
        private Boolean _chckbxSuggestionsShowSuggestionsInTimeline;
        public Boolean ChckbxSuggestionsShowSuggestionsInTimeline
        {
            get => _chckbxSuggestionsShowSuggestionsInTimeline;
            set
            {
                if (_chckbxSuggestionsShowSuggestionsInTimeline == value)
                    return;

                _chckbxSuggestionsShowSuggestionsInTimeline = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsShowSuggestionsInTimeline));
                SuggestionsShowSuggestionsInTimeline();
            }
        }

        private void SuggestionsShowSuggestionsInTimeline()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SubscribedContent-353698Enabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsShowSuggestionsInTimeline)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // CheckBox - Lockscreen suggestions and Rotation - Command
        private Boolean _chckbxSuggestionsLockscreenSuggestionsAndRotation;
        public Boolean ChckbxSuggestionsLockscreenSuggestionsAndRotation
        {
            get => _chckbxSuggestionsLockscreenSuggestionsAndRotation;
            set
            {
                if (_chckbxSuggestionsLockscreenSuggestionsAndRotation == value)
                    return;

                _chckbxSuggestionsLockscreenSuggestionsAndRotation = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsLockscreenSuggestionsAndRotation));
                SuggestionsLockscreenSuggestionsAndRotation();
            }
        }

        private void SuggestionsLockscreenSuggestionsAndRotation()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SoftLandingEnabled";
            string Name2 = "RotatingLockScreenEnabled";
            string Name3 = "RotatingLockScreenOverlayEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsLockscreenSuggestionsAndRotation)
            {
                Process.Start(Exe, ArgsChecked);
                Process.Start(Exe, ArgsChecked2);
                Process.Start(Exe, ArgsChecked3);
            }
            else
            {
                Process.Start(Exe, ArgsUnchecked);
                Process.Start(Exe, ArgsUnchecked2);
                Process.Start(Exe, ArgsUnchecked3);
            }
        }


        // CheckBox - Ads in File Explorer - Command
        private Boolean _chckbxSuggestionsAdsInFileExplorer;
        public Boolean ChckbxSuggestionsAdsInFileExplorer
        {
            get => _chckbxSuggestionsAdsInFileExplorer;
            set
            {
                if (_chckbxSuggestionsAdsInFileExplorer == value)
                    return;

                _chckbxSuggestionsAdsInFileExplorer = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsAdsInFileExplorer));
                SuggestionsAdsInFileExplorer();
            }
        }

        private void SuggestionsAdsInFileExplorer()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "ShowSyncProviderNotifications";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsAdsInFileExplorer)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // CheckBox - Show me the Windows welcome experience after updates and occasionally - Command
        private Boolean _chckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally;
        public Boolean ChckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally
        {
            get => _chckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally;
            set
            {
                if (_chckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally == value)
                    return;

                _chckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally));
                SuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally();
            }
        }

        private void SuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SubscribedContent-310093Enabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsShowMeTheWindowsWelcomeExperienceAfterUpdatesAndOccasionally)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // CheckBox - Get tips, tricks, suggestions as you use Windows - Command
        private Boolean _chckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows;
        public Boolean ChckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows
        {
            get => _chckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows;
            set
            {
                if (_chckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows == value)
                    return;

                _chckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows = value;
                OnPropertyChanged(nameof(ChckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows));
                SuggestionsGetTipsTricksSuggestionsAsYouUseWindows();
            }
        }

        private void SuggestionsGetTipsTricksSuggestionsAsYouUseWindows()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SubscribedContent-338389Enabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSuggestionsGetTipsTricksSuggestionsAsYouUseWindows)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        #endregion

    }
}
