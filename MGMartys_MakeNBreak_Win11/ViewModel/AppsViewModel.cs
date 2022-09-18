using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class AppsViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        #region Hidden App Settings

        // CheckBox - Preinstalled Apps Enabled
        private Boolean _chckbxHiddenAppSettingsPreinstalledAppsEnabled;
        public Boolean ChckbxHiddenAppSettingsPreinstalledAppsEnabled
        {
            get => _chckbxHiddenAppSettingsPreinstalledAppsEnabled;
            set
            {
                if (_chckbxHiddenAppSettingsPreinstalledAppsEnabled == value)
                    return;

                _chckbxHiddenAppSettingsPreinstalledAppsEnabled = value;
                OnPropertyChanged(nameof(ChckbxHiddenAppSettingsPreinstalledAppsEnabled));
                HiddenAppSettingsPreinstalledAppsEnabled();
            }
        }

        private void HiddenAppSettingsPreinstalledAppsEnabled()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "PreInstalledAppsEnabled";
            string Name2 = "PreInstalledAppsEverEnabled";
            string Name3 = "OEMPreInstalledAppsEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxHiddenAppSettingsPreinstalledAppsEnabled)
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


        // CheckBox - Preinstalled Apps Enabled
        private Boolean _chckbxHiddenAppSettingsQuitlyReinstallApps;
        public Boolean ChckbxHiddenAppSettingsQuitlyReinstallApps
        {
            get => _chckbxHiddenAppSettingsQuitlyReinstallApps;
            set
            {
                if (_chckbxHiddenAppSettingsQuitlyReinstallApps == value)
                    return;

                _chckbxHiddenAppSettingsQuitlyReinstallApps = value;
                OnPropertyChanged(nameof(ChckbxHiddenAppSettingsQuitlyReinstallApps));
                HiddenAppSettingsQuitlyReinstallApps();
            }
        }

        private void HiddenAppSettingsQuitlyReinstallApps()
        {
            string Exe = "wt.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SilentInstalledAppsEnabled";
            string Name2 = "ContentDeliveryAllowed";
            string Name3 = "SubscribedContentEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsChecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = @"Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = @"Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked3 = @"Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxHiddenAppSettingsQuitlyReinstallApps)
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



        #endregion


        #region Uninstall Apps

        // Checkbox - ClipChamp - Command

        private Boolean _chckbxUninstallClipChamp;
        public Boolean ChckbxUninstallClipChamp
        {
            get => _chckbxUninstallClipChamp;
            set
            {
                if (_chckbxUninstallClipChamp == value)
                    return;

                _chckbxUninstallClipChamp = value;
                OnPropertyChanged(nameof(ChckbxUninstallClipChamp));
                UninstallClipChamp();
            }
        }

        public void UninstallClipChamp()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Clipchamp.Clipchamp* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Clipchamp.Clipchamp_2.4.9.0_neutral__yxz26nhyzhsrt\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallClipChamp)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Cortana - Command

        private Boolean _chckbxUninstallCortana;
        public Boolean ChckbxUninstallCortana
        {
            get => _chckbxUninstallCortana;
            set
            {
                if (_chckbxUninstallCortana == value)
                    return;

                _chckbxUninstallCortana = value;
                OnPropertyChanged(nameof(ChckbxUninstallCortana));
                UninstallCortana();
            }
        }

        public void UninstallCortana()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage -AllUsers *Microsoft.549981C3F5F10* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.549981C3F5F10_4.2204.13303.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallCortana)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }



        // Checkbox - Microsoft News - Command

        private Boolean _chckbxUninstallMicrosoftNews;
        public Boolean ChckbxUninstallMicrosoftNews
        {
            get => _chckbxUninstallMicrosoftNews;
            set
            {
                if (_chckbxUninstallMicrosoftNews == value)
                    return;

                _chckbxUninstallMicrosoftNews = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftNews));
                UninstallMicrosoftNews();
            }
        }

        public void UninstallMicrosoftNews()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.BingNews* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.BingNews_1.0.1.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftNews)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - MSN Weather - Command

        private Boolean _chckbxUninstallMSNWeather;
        public Boolean ChckbxUninstallMSNWeather
        {
            get => _chckbxUninstallMSNWeather;
            set
            {
                if (_chckbxUninstallMSNWeather == value)
                    return;

                _chckbxUninstallMSNWeather = value;
                OnPropertyChanged(nameof(ChckbxUninstallMSNWeather));
                UninstallMSNWeather();
            }
        }

        public void UninstallMSNWeather()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.BingWeather* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.BingWeather_3.2.7.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMSNWeather)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Get Help - Command

        private Boolean _chckbxUninstallGetHelp;
        public Boolean ChckbxUninstallGetHelp
        {
            get => _chckbxUninstallGetHelp;
            set
            {
                if (_chckbxUninstallGetHelp == value)
                    return;

                _chckbxUninstallGetHelp = value;
                OnPropertyChanged(nameof(ChckbxUninstallGetHelp));
                UninstallGetHelp();
            }
        }

        public void UninstallGetHelp()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.GetHelp* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.GetHelp_10.2206.2011.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallGetHelp)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft Tips - Command

        private Boolean _chckbxUninstallMicrosoftTips;
        public Boolean ChckbxUninstallMicrosoftTips
        {
            get => _chckbxUninstallMicrosoftTips;
            set
            {
                if (_chckbxUninstallMicrosoftTips == value)
                    return;

                _chckbxUninstallMicrosoftTips = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftTips));
                UninstallMicrosoftTips();
            }
        }

        public void UninstallMicrosoftTips()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.Getstarted* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.Getstarted_10.2206.2.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftTips)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Office - Command

        private Boolean _chckbxUninstallOffice;
        public Boolean ChckbxUninstallOffice
        {
            get => _chckbxUninstallOffice;
            set
            {
                if (_chckbxUninstallOffice == value)
                    return;

                _chckbxUninstallOffice = value;
                OnPropertyChanged(nameof(ChckbxUninstallOffice));
                UninstallOffice();
            }
        }

        public void UninstallOffice()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.MicrosoftOfficeHub* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.MicrosoftOfficeHub_18.2209.1061.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallOffice)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft Solitaire Collection - Command

        private Boolean _chckbxUninstallMicrosoftSolitaireCollection;
        public Boolean ChckbxUninstallMicrosoftSolitaireCollection
        {
            get => _chckbxUninstallMicrosoftSolitaireCollection;
            set
            {
                if (_chckbxUninstallMicrosoftSolitaireCollection == value)
                    return;

                _chckbxUninstallMicrosoftSolitaireCollection = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftSolitaireCollection));
                UninstallMicrosoftSolitaireCollection();
            }
        }

        public void UninstallMicrosoftSolitaireCollection()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.MicrosoftSolitaireCollection* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\.MicrosoftSolitaireCollection_4.14.90Microsoft20.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftSolitaireCollection)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft OneDrive - Command

        private Boolean _chckbxUninstallMicrosoftOneDrive;
        public Boolean ChckbxUninstallMicrosoftOneDrive
        {
            get => _chckbxUninstallMicrosoftOneDrive;
            set
            {
                if (_chckbxUninstallMicrosoftOneDrive == value)
                    return;

                _chckbxUninstallMicrosoftOneDrive = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftOneDrive));
                UninstallMicrosoftOneDrive();
            }
        }

        public void UninstallMicrosoftOneDrive()
        {
            string Exe = "wt.exe";
            string Uninstall = @"winget uninstall --id=Microsoft.OneDrive";
            string Install = @"winget install --id=Microsoft.OneDrive -e";

            if (ChckbxUninstallMicrosoftOneDrive)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - OneDrive - Command

        private Boolean _chckbxUninstallOneDrive;
        public Boolean ChckbxUninstallOneDrive
        {
            get => _chckbxUninstallOneDrive;
            set
            {
                if (_chckbxUninstallOneDrive == value)
                    return;

                _chckbxUninstallOneDrive = value;
                OnPropertyChanged(nameof(ChckbxUninstallOneDrive));
                UninstallOneDrive();
            }
        }

        public void UninstallOneDrive()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.OneDriveSync* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.OneDriveSync_22176.821.3.0_neutral__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallOneDrive)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft People - Command

        private Boolean _chckbxUninstallMicrosoftPeople;
        public Boolean ChckbxUninstallMicrosoftPeople
        {
            get => _chckbxUninstallMicrosoftPeople;
            set
            {
                if (_chckbxUninstallMicrosoftPeople == value)
                    return;

                _chckbxUninstallMicrosoftPeople = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftPeople));
                UninstallMicrosoftPeople();
            }
        }

        public void UninstallMicrosoftPeople()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.People* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.People_10.2105.4.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftPeople)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Store Experience Host - Command

        private Boolean _chckbxUninstallStoreExperienceHost;
        public Boolean ChckbxUninstallStoreExperienceHost
        {
            get => _chckbxUninstallStoreExperienceHost;
            set
            {
                if (_chckbxUninstallStoreExperienceHost == value)
                    return;

                _chckbxUninstallStoreExperienceHost = value;
                OnPropertyChanged(nameof(ChckbxUninstallStoreExperienceHost));
                UninstallStoreExperienceHost();
            }
        }

        public void UninstallStoreExperienceHost()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.StorePurchaseApp* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.StorePurchaseApp_12203.44.0.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallStoreExperienceHost)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft To Do - Command

        private Boolean _chckbxUninstallMicrosoftToDo;
        public Boolean ChckbxUninstallMicrosoftToDo
        {
            get => _chckbxUninstallMicrosoftToDo;
            set
            {
                if (_chckbxUninstallMicrosoftToDo == value)
                    return;

                _chckbxUninstallMicrosoftToDo = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftToDo));
                UninstallMicrosoftToDo();
            }
        }

        public void UninstallMicrosoftToDo()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.Todos* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.Todos_0.78.52391.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftToDo)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Windows Camera - Command

        private Boolean _chckbxUninstallWindowsCamera;
        public Boolean ChckbxUninstallWindowsCamera
        {
            get => _chckbxUninstallWindowsCamera;
            set
            {
                if (_chckbxUninstallWindowsCamera == value)
                    return;

                _chckbxUninstallWindowsCamera = value;
                OnPropertyChanged(nameof(ChckbxUninstallWindowsCamera));
                UninstallWindowsCamera();
            }
        }

        public void UninstallWindowsCamera()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.WindowsCamera* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.WindowsCamera_2022.2207.29.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallWindowsCamera)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Mail & Calendar - Command

        private Boolean _chckbxUninstallMailAndCalendar;
        public Boolean ChckbxUninstallMailAndCalendar
        {
            get => _chckbxUninstallMailAndCalendar;
            set
            {
                if (_chckbxUninstallMailAndCalendar == value)
                    return;

                _chckbxUninstallMailAndCalendar = value;
                OnPropertyChanged(nameof(ChckbxUninstallMailAndCalendar));
                UninstallMailAndCalendar();
            }
        }

        public void UninstallMailAndCalendar()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *microsoft.windowscommunicationsapps* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\microsoft.windowscommunicationsapps_16005.14326.20970.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMailAndCalendar)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Feedback Hub - Command

        private Boolean _chckbxUninstallFeedbackHub;
        public Boolean ChckbxUninstallFeedbackHub
        {
            get => _chckbxUninstallFeedbackHub;
            set
            {
                if (_chckbxUninstallFeedbackHub == value)
                    return;

                _chckbxUninstallFeedbackHub = value;
                OnPropertyChanged(nameof(ChckbxUninstallFeedbackHub));
                UninstallFeedbackHub();
            }
        }

        public void UninstallFeedbackHub()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.WindowsFeedbackHub* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.WindowsFeedbackHub_1.2203.761.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallFeedbackHub)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Windows Maps - Command

        private Boolean _chckbxUninstallWindowsMaps;
        public Boolean ChckbxUninstallWindowsMaps
        {
            get => _chckbxUninstallWindowsMaps;
            set
            {
                if (_chckbxUninstallWindowsMaps == value)
                    return;

                _chckbxUninstallWindowsMaps = value;
                OnPropertyChanged(nameof(ChckbxUninstallWindowsMaps));
                UninstallWindowsMaps();
            }
        }

        public void UninstallWindowsMaps()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.WindowsMaps* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.WindowsMaps_1.0.43.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallWindowsMaps)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Windows Voice Recorder - Command

        private Boolean _chckbxUninstallWindowsVoiceRecorder;
        public Boolean ChckbxUninstallWindowsVoiceRecorder
        {
            get => _chckbxUninstallWindowsVoiceRecorder;
            set
            {
                if (_chckbxUninstallWindowsVoiceRecorder == value)
                    return;

                _chckbxUninstallWindowsVoiceRecorder = value;
                OnPropertyChanged(nameof(ChckbxUninstallWindowsVoiceRecorder));
                UninstallWindowsVoiceRecorder();
            }
        }

        public void UninstallWindowsVoiceRecorder()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.WindowsSoundRecorder* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.WindowsSoundRecorder_1.0.61.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallWindowsVoiceRecorder)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Phone Link - Command

        private Boolean _chckbxUninstallPhoneLink;
        public Boolean ChckbxUninstallPhoneLink
        {
            get => _chckbxUninstallPhoneLink;
            set
            {
                if (_chckbxUninstallPhoneLink == value)
                    return;

                _chckbxUninstallPhoneLink = value;
                OnPropertyChanged(nameof(ChckbxUninstallPhoneLink));
                UninstallPhoneLink();
            }
        }

        public void UninstallPhoneLink()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.YourPhone* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.YourPhone_0.22062.543.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallPhoneLink)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Windows Media Player - Command

        private Boolean _chckbxUninstallWindowsMediaPlayer;
        public Boolean ChckbxUninstallWindowsMediaPlayer
        {
            get => _chckbxUninstallWindowsMediaPlayer;
            set
            {
                if (_chckbxUninstallWindowsMediaPlayer == value)
                    return;

                _chckbxUninstallWindowsMediaPlayer = value;
                OnPropertyChanged(nameof(ChckbxUninstallWindowsMediaPlayer));
                UninstallWindowsMediaPlayer();
            }
        }

        public void UninstallWindowsMediaPlayer()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.ZuneMusic* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.ZuneMusic_11.2205.22.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallWindowsMediaPlayer)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Movies and TV - Command

        private Boolean _chckbxUninstallMoviesAndTV;
        public Boolean ChckbxUninstallMoviesAndTV
        {
            get => _chckbxUninstallMoviesAndTV;
            set
            {
                if (_chckbxUninstallMoviesAndTV == value)
                    return;

                _chckbxUninstallMoviesAndTV = value;
                OnPropertyChanged(nameof(ChckbxUninstallMoviesAndTV));
                UninstallMoviesAndTV();
            }
        }

        public void UninstallMoviesAndTV()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *Microsoft.ZuneVideo* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\Microsoft.ZuneVideo_10.22061.10241.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMoviesAndTV)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Quick Assist - Command

        private Boolean _chckbxUninstallQuickAssist;
        public Boolean ChckbxUninstallQuickAssist
        {
            get => _chckbxUninstallQuickAssist;
            set
            {
                if (_chckbxUninstallQuickAssist == value)
                    return;

                _chckbxUninstallQuickAssist = value;
                OnPropertyChanged(nameof(ChckbxUninstallQuickAssist));
                UninstallQuickAssist();
            }
        }

        public void UninstallQuickAssist()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *MicrosoftCorporationII.QuickAssist* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\MicrosoftCorporationII.QuickAssist_2.0.9.0_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallQuickAssist)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Microsoft Teams - Command

        private Boolean _chckbxUninstallMicrosoftTeams;
        public Boolean ChckbxUninstallMicrosoftTeams
        {
            get => _chckbxUninstallMicrosoftTeams;
            set
            {
                if (_chckbxUninstallMicrosoftTeams == value)
                    return;

                _chckbxUninstallMicrosoftTeams = value;
                OnPropertyChanged(nameof(ChckbxUninstallMicrosoftTeams));
                UninstallMicrosoftTeams();
            }
        }

        public void UninstallMicrosoftTeams()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *MicrosoftTeams* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\MicrosoftTeams_22227.300.1508.3394_x64__8wekyb3d8bbwe\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallMicrosoftTeams)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }


        // Checkbox - Windows Web Experience Pack - Command

        private Boolean _chckbxUninstallWindowsWebExperiencePack;
        public Boolean ChckbxUninstallWindowsWebExperiencePack
        {
            get => _chckbxUninstallWindowsWebExperiencePack;
            set
            {
                if (_chckbxUninstallWindowsWebExperiencePack == value)
                    return;

                _chckbxUninstallWindowsWebExperiencePack = value;
                OnPropertyChanged(nameof(ChckbxUninstallWindowsWebExperiencePack));
                UninstallWindowsWebExperiencePack();
            }
        }

        public void UninstallWindowsWebExperiencePack()
        {
            string Exe = "wt.exe";
            string Uninstall = @"powershell Get-AppxPackage *MicrosoftWindows.Client.WebExperience* | Remove-AppxPackage";
            string Install = @"powershell Add-AppxPackage -register 'C:\Program Files\WindowsApps\MicrosoftWindows.Client.WebExperience_421.20070.625.0_x64__cw5n1h2txyewy\AppxManifest.xml' –DisableDevelopmentMode";

            if (ChckbxUninstallWindowsWebExperiencePack)
                Process.Start(Exe, Uninstall);
            else
                Process.Start(Exe, Install);
        }

        #endregion

    }
}
