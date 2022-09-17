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
using Microsoft.Win32;

using static System.Net.Mime.MediaTypeNames;




namespace MGMartys_MakeNBreak_Win11.ViewModel
{
   
    public class ExplorerViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        

        #region Context Menu

        //  CheckBox - "Get the "Classic" right click menu back" Command
        private Boolean _chckbxClassicRightClickMenu;
        public Boolean ChckbxClassicRightClickMenu
        {
            get => _chckbxClassicRightClickMenu;
            set
            {
                if (_chckbxClassicRightClickMenu == value)
                    return;

                _chckbxClassicRightClickMenu = value;
                OnPropertyChanged(nameof(ChckbxClassicRightClickMenu));
                ClassicRightClickMenu();
            }
        }
        private void ClassicRightClickMenu()
        {
            string Exe = "wt.exe";
            string RegistryPathAdd = @"'HKCU:\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\'";
            string RegistryPathRem = @"'HKCU:\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}'";
            string ArgsNew = @"powershell New-Item -Path " + RegistryPathAdd + " -Value ' ' -Force";
            string ArgsRemove = @"powershell Remove-Item -Path " + RegistryPathRem + " -Recurse";
            

            if (ChckbxClassicRightClickMenu)
            {
                Process.Start(Exe, ArgsNew);
             }
            else
                Process.Start(Exe, ArgsRemove);
        }

        
        //  CheckBox - "Enable New "Wide" Context Menu - Command"
        private Boolean _chckbxNewWideContextMenu;
        public Boolean ChckbxNewWideContextMenu
        {
            get => _chckbxNewWideContextMenu;
            set
            {
                if (_chckbxNewWideContextMenu == value)
                    return;

                _chckbxNewWideContextMenu = value;
                OnPropertyChanged(nameof(ChckbxNewWideContextMenu));
                NewWideContextMenu();
            }
        }
        private void NewWideContextMenu()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\FlightedFeatures";
            string Name = @"ImmersiveContextMenu";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);




            if (ChckbxNewWideContextMenu)
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

        private Boolean _chckbxSearchOnInternetContextMenu;
        public Boolean ChckbxSearchOnInternetContextMenu
        {
            get => _chckbxSearchOnInternetContextMenu;
            set
            {
                if (_chckbxSearchOnInternetContextMenu == value)
                    return;

                _chckbxSearchOnInternetContextMenu = value;
                OnPropertyChanged(nameof(ChckbxSearchOnInternetContextMenu));
                SearchOnInternetContextMenu();
            }
        }

        public void SearchOnInternetContextMenu()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoInternetOpenWith";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSearchOnInternetContextMenu)
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

        #region Folder Options

    // Folder Options - Tab: General

        // Checkbox - Open File Explorer to: "This PC" instead of "Quick Access" - Command

        private Boolean _chckbxFolderOptionsGeneralFileExplorerToThisPc;
        public Boolean ChckbxFolderOptionsGeneralFileExplorerToThisPc
        {
            get => _chckbxFolderOptionsGeneralFileExplorerToThisPc;
            set
            {
                if (_chckbxFolderOptionsGeneralFileExplorerToThisPc == value)
                    return;

                _chckbxFolderOptionsGeneralFileExplorerToThisPc = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionsGeneralFileExplorerToThisPc));
                FolderOptionsGeneralFileExplorerToThisPc();
            }
        }

        public void FolderOptionsGeneralFileExplorerToThisPc()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"LaunchTo";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionsGeneralFileExplorerToThisPc)
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


        // Checkbox - Disable 'Show recently used files in Quick Access' - Command

        private Boolean _chckbxFolderOptionsGeneralShowRecentlyUsedFiles;
        public Boolean ChckbxFolderOptionsGeneralShowRecentlyUsedFiles
        {
            get => _chckbxFolderOptionsGeneralShowRecentlyUsedFiles;
            set
            {
                if (_chckbxFolderOptionsGeneralShowRecentlyUsedFiles == value)
                    return;

                _chckbxFolderOptionsGeneralShowRecentlyUsedFiles = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionsGeneralShowRecentlyUsedFiles));
                FolderOptionsGeneralShowRecentlyUsedFiles();
            }
        }

        public void FolderOptionsGeneralShowRecentlyUsedFiles()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = @"ShowRecent";
            string Checked = @"0";
            string Unchecked = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionsGeneralShowRecentlyUsedFiles)
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


        // Checkbox - Disable 'Show frequently used folders in Quick Access' - Command

        private Boolean _chckbxFolderOptionsGeneralShowFrequentlyUsedFolders;
        public Boolean ChckbxFolderOptionsGeneralShowFrequentlyUsedFolders
        {
            get => _chckbxFolderOptionsGeneralShowFrequentlyUsedFolders;
            set
            {
                if (_chckbxFolderOptionsGeneralShowFrequentlyUsedFolders == value)
                    return;

                _chckbxFolderOptionsGeneralShowFrequentlyUsedFolders = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionsGeneralShowFrequentlyUsedFolders));
                FolderOptionsGeneralShowFrequentlyUsedFolders();
            }
        }

        public void FolderOptionsGeneralShowFrequentlyUsedFolders()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = @"ShowFrequent";
            string Checked = @"0";
            string Unchecked = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionsGeneralShowFrequentlyUsedFolders)
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


        // Checkbox - Disable 'Show files from Office.com' - Command

        private Boolean _chckbxFolderOptionsGeneralShowFilesFromOffice;
        public Boolean ChckbxFolderOptionsGeneralShowFilesFromOffice
        {
            get => _chckbxFolderOptionsGeneralShowFilesFromOffice;
            set
            {
                if (_chckbxFolderOptionsGeneralShowFilesFromOffice == value)
                    return;

                _chckbxFolderOptionsGeneralShowFilesFromOffice = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionsGeneralShowFilesFromOffice));
                FolderOptionsGeneralShowFilesFromOffice();
            }
        }

        public void FolderOptionsGeneralShowFilesFromOffice()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoInternetOpenWith";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionsGeneralShowFilesFromOffice)
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



    // Folder Options - Tab: View

        // Checkbox - Enable 'Show hidden files, folders and drives' - Command

        private Boolean _chckbxFolderOptionViewShowHiddenFiles;
        public Boolean ChckbxFolderOptionViewShowHiddenFiles
        {
            get => _chckbxFolderOptionViewShowHiddenFiles;
            set
            {
                if (_chckbxFolderOptionViewShowHiddenFiles == value)
                    return;

                _chckbxFolderOptionViewShowHiddenFiles = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionViewShowHiddenFiles));
                FolderOptionViewShowHiddenFiles();
            }
        }

        public void FolderOptionViewShowHiddenFiles()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"Hidden";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionViewShowHiddenFiles)
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


        // Checkbox - Disable 'Hide file extensions for known file types' - Command

        private Boolean _chckbxFolderOptionViewHideFileExtensions;
        public Boolean ChckbxFolderOptionViewHideFileExtensions
        {
            get => _chckbxFolderOptionViewHideFileExtensions;
            set
            {
                if (_chckbxFolderOptionViewHideFileExtensions == value)
                    return;

                _chckbxFolderOptionViewHideFileExtensions = value;
                OnPropertyChanged(nameof(ChckbxFolderOptionViewHideFileExtensions));
                FolderOptionViewHideFileExtensions();
            }
        }

        public void FolderOptionViewHideFileExtensions()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"HideFileExt";
            string Checked = @"0";
            string Unchecked = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFolderOptionViewHideFileExtensions)
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

        #region File Explorer

    // File Explorer - Background processes

       
        // Checkbox -  - Command

        private Boolean _chckbxFileExplorerDontCheckLowDisk;
        public Boolean ChckbxFileExplorerDontCheckLowDisk
        {
            get => _chckbxFileExplorerDontCheckLowDisk;
            set
            {
                if (_chckbxFileExplorerDontCheckLowDisk == value)
                    return;

                _chckbxFileExplorerDontCheckLowDisk = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerDontCheckLowDisk));
                FileExplorerDontCheckLowDisk();
            }
        }

        public void FileExplorerDontCheckLowDisk()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoLowDiskSpaceChecks";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerDontCheckLowDisk)
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

        private Boolean _chckbxFileExplorerDoNotTrackShell;
        public Boolean ChckbxFileExplorerDoNotTrackShell
        {
            get => _chckbxFileExplorerDoNotTrackShell;
            set
            {
                if (_chckbxFileExplorerDoNotTrackShell == value)
                    return;

                _chckbxFileExplorerDoNotTrackShell = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerDoNotTrackShell));
                FileExplorerDoNotTrackShell();
            }
        }

        public void FileExplorerDoNotTrackShell()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"LinkResolveIgnoreLinkInfo";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerDoNotTrackShell)
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


        // Checkbox -  - Command

        private Boolean _chckbxFileExplorerDoNotUseSearch;
        public Boolean ChckbxFileExplorerDoNotUseSearch
        {
            get => _chckbxFileExplorerDoNotUseSearch;
            set
            {
                if (_chckbxFileExplorerDoNotUseSearch == value)
                    return;

                _chckbxFileExplorerDoNotUseSearch = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerDoNotUseSearch));
                FileExplorerDoNotUseSearch();
            }
        }

        public void FileExplorerDoNotUseSearch()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"NoResolveSearch";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerDoNotUseSearch)
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

        private Boolean _chckbxFileExplorerDoNotUseTracking;
        public Boolean ChckbxFileExplorerDoNotUseTracking
        {
            get => _chckbxFileExplorerDoNotUseTracking;
            set
            {
                if (_chckbxFileExplorerDoNotUseTracking == value)
                    return;

                _chckbxFileExplorerDoNotUseTracking = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerDoNotUseTracking));
                FileExplorerDoNotUseTracking();
            }
        }

        public void FileExplorerDoNotUseTracking()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Policies\Explorer";
            string Name = @"NoResolveTrack";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerDoNotUseTracking)
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


        // File Explorer - Navigation Pane

        // Checkbox - Add Recycle Bin to Navigation Pane - Command

        private Boolean _chckbxFileExplorerAddRecycleBin;
        public Boolean ChckbxFileExplorerAddRecycleBin
        {
            get => _chckbxFileExplorerAddRecycleBin;
            set
            {
                if (_chckbxFileExplorerAddRecycleBin == value)
                    return;

                _chckbxFileExplorerAddRecycleBin = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerAddRecycleBin));
                FileExplorerAddRecycleBin();
            }
        }

        public void FileExplorerAddRecycleBin()
        {
            string RegistryHive = @"'HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Classes\\CLSID\\{645FF040-5081-101B-9F08-00AA002F954E}'";
            string Name = @"System.IsPinnedToNameSpaceTree";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerAddRecycleBin)
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

        private Boolean _chckbxFileExplorerSetIconCache;
        public Boolean ChckbxFileExplorerSetIconCache
        {
            get => _chckbxFileExplorerSetIconCache;
            set
            {
                if (_chckbxFileExplorerSetIconCache == value)
                    return;

                _chckbxFileExplorerSetIconCache = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerSetIconCache));
                FileExplorerSetIconCache();
            }
        }

        public void FileExplorerSetIconCache()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = @"'Max Cached Icons'";
            string Checked = @"4096";
            string Unchecked = @"1024";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerSetIconCache)
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

        private Boolean _chckbxFileExplorerEnableFileSystemLong;
        public Boolean ChckbxFileExplorerEnableFileSystemLong
        {
            get => _chckbxFileExplorerEnableFileSystemLong;
            set
            {
                if (_chckbxFileExplorerEnableFileSystemLong == value)
                    return;

                _chckbxFileExplorerEnableFileSystemLong = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerEnableFileSystemLong));
                FileExplorerEnableFileSystemLong();
            }
        }

        public void FileExplorerEnableFileSystemLong()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Policies";
            string Name = @"LongPathsEnabled";
            string Checked = @"1";
            string Unchecked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerEnableFileSystemLong)
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

        private Boolean _chckbxFileExplorerSetWindowsStartupDelay;
        public Boolean ChckbxFileExplorerSetWindowsStartupDelay
        {
            get => _chckbxFileExplorerSetWindowsStartupDelay;
            set
            {
                if (_chckbxFileExplorerSetWindowsStartupDelay == value)
                    return;

                _chckbxFileExplorerSetWindowsStartupDelay = value;
                OnPropertyChanged(nameof(ChckbxFileExplorerSetWindowsStartupDelay));
                FileExplorerSetWindowsStartupDelay();
            }
        }

        public void FileExplorerSetWindowsStartupDelay()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";
            string Name = @"StartupDelayInMSec";
            string Checked = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Remove-Item -Path " + RegistryHive + RegistryPath + " -Recurse";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxFileExplorerSetWindowsStartupDelay)
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

