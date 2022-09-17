
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}";
            string RegKey = @"\\InprocServer32";
            string Name = @"(Default)";
            string Type = @"String";
            string Value = @" ";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + RegKey + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + RegKey + "' -Name '" + Name + "' -Type " + Type + " -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-Item -Path '" + RegistryHive + RegistryPath + "' -Recurse";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath + RegKey, true);


            
            if (ChckbxContextMenuClassicRightClickMenu)
            {
                    if (CheckRegKeyCU == null)
                    {
                        Process.Start(Exe, ArgsNoKey);
                        Process.Start(Exe, ArgsChecked);
                    }
                    else
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
            string RegistryHive = @"HKLM:\";
            string RegistryPath = @"SOFTWARE\Microsoft\\Windows\CurrentVersion\FlightedFeatures";
            string Name = @"ImmersiveContextMenu";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name " + Name + " -Type " + Type + " -Value " + Value + " -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxContextMenuNewWideContextMenu)
            {
                if (CheckRegKeyLM == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            string Name = @"NoInternetOpenWith";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name " + Name + " -Type " + Type + " -Value " + Value + " -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxContextMenuSearchOnInternetContextMenu)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"JPEGImportQuality";
            string Type = @"DWord";
            string Value = @"100";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxDesktopSettingsMaximizeWallpaperQuality)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"MenuShowDelay";
            string Type = @"String";
            string Value = @"8";
            string Default = @"400";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxDesktopSettingsOpenMenusFaster)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"HungAppTimeout";
            string Type = @"String";
            string Value = @"1000";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);


            if (ChckbxDesktopSettingsReduceTimeSystemWaitsEndTask)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"LowLevelHooksTimeout";
            string Type = @"DWord";
            string Value = @"1000";


            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);


            if (ChckbxDesktopSettingsReduceTimeToWaitKillService)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Group Policy Objects\{3D2C7559-33D6-4493-AC1F-4DC5F8DB73E5}Machine\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3";
            string RegistryPath2 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\3";
            string Name = @"1806";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxDesktopSettingsFileSystemDontShowPotentiallyHarmfullFile)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                    Process.Start(Exe, ArgsChecked2);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoLowDiskSpaceChecks";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileSystemDontCheckLowDisk)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"LinkResolveIgnoreLinkInfo";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileSystemDoNotTrackShell)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoResolveSearch";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileSystemDoNotUseSearch)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\Explorer";
            string Name = @"NoResolveTrack";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileSystemDoNotUseTracking)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Classes\\CLSID\\{645FF040-5081-101B-9F08-00AA002F954E}";
            string Name = @"System.IsPinnedToNameSpaceTree";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-Item -Path '" + RegistryPath + "' -Recurse";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxNavigationPaneAddRecycleBin)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = @"Max Cached Icons";
            string Type = @"String";
            string Value = @"4096";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxNavigationPaneSetIconCache)
            {
                if (CheckRegKeyLM == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Policies";
            string Name = @"LongPathsEnabled";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxNavigationPaneEnableFileSystemLong)
            {
                if (CheckRegKeyLM == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";
            string Name = @"StartupDelayInMSec";
            string Type = @"DWord";
            string Value = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-Item -Path '" + RegistryPath + "' -Recurse";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            

            if (ChckbxNavigationPaneSetWindowsStartupDelay)
            {
                if (CheckRegKeyLM == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"AutoEndTasks";
            string Type = @"String";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxRebootShutdownLogoutAutoCloseApps)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"WaitToKillAppTimeout";
            string Type = @"String";
            string Value = @"4096";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxRebootShutdownLogoutWaitTimeBeforeClosingApps)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\CurrentControlSet\Control";
            string Name = @"WaitToKillServiceTimeout";
            string Type = @"String";
            string Value = @"2000";
            string Default = @"5000";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxRebootShutdownLogoutWaitTimeBeforeStoppingServices)
            {
                if (CheckRegKeyLM == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
                    Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

    }
}
