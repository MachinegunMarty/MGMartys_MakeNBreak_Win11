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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Clipchamp.Clipchamp* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
            
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage -AllUsers *Microsoft.549981C3F5F10* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.BingNews* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.BingWeather* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
           
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.GetHelp* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.Getstarted* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.MicrosoftOfficeHub* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.MicrosoftSolitaireCollection* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "cmd.exe";
            string Uninstall = "/C winget uninstall --id=Microsoft.OneDrive --accept-source-agreements";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.OneDriveSync* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.People* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.StorePurchaseApp* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.Todos* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.WindowsCamera* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *microsoft.windowscommunicationsapps* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.WindowsFeedbackHub* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.WindowsMaps* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.WindowsSoundRecorder* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.YourPhone* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.ZuneMusic* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *Microsoft.ZuneVideo* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *MicrosoftCorporationII.QuickAssist* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *MicrosoftTeams* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
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
            string Exe = "powershell.exe";
            string Uninstall = "Get-AppxPackage *MicrosoftWindows.Client.WebExperience* | Remove-AppxPackage";
            Process.Start(Exe, Uninstall);
        }

        #endregion

    }
}
