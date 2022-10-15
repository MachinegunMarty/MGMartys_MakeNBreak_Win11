using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using MGMartys_MakeNBreak_Win11.Model;
using MGMartys_MakeNBreak_Win11.Utilities;
using Microsoft.Win32;
using ModernDashboard.Properties;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        #region System

        #region Notifications

        // Checkbox - Get 'Notifications' from apps and other senders - Off  - Command

        private Boolean _chckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff;
        public Boolean ChckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff
        {
            get => _chckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff;
            set
            {
                if (_chckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff == value)
                    return;

                _chckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff = value;
                OnPropertyChanged(nameof(ChckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff));
                SystemNotificationsGetNotificationsFromAppsAndOtherSendersOff();
            }
        }

        public void SystemNotificationsGetNotificationsFromAppsAndOtherSendersOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications";
            string Name = "ToastEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Notification - Allow 'Notifcations' to play sounds - Off - Command

        private Boolean _chckbxSystemNotificationsAllowNotificationsToPlaySoundsOff;
        public Boolean ChckbxSystemNotificationsAllowNotificationsToPlaySoundsOff
        {
            get => _chckbxSystemNotificationsAllowNotificationsToPlaySoundsOff;
            set
            {
                if (_chckbxSystemNotificationsAllowNotificationsToPlaySoundsOff == value)
                    return;

                _chckbxSystemNotificationsAllowNotificationsToPlaySoundsOff = value;
                OnPropertyChanged(nameof(ChckbxSystemNotificationsAllowNotificationsToPlaySoundsOff));
                SystemNotificationsAllowNotificationsToPlaySoundsOff();
            }
        }

        public void SystemNotificationsAllowNotificationsToPlaySoundsOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = "NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemNotificationsAllowNotificationsToPlaySoundsOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show 'Notifications' on the lock screen - Off - Command

        private Boolean _chckbxSystemNotificationsShowNotificationsOnTheLockScreenOff;
        public Boolean ChckbxSystemNotificationsShowNotificationsOnTheLockScreenOff
        {
            get => _chckbxSystemNotificationsShowNotificationsOnTheLockScreenOff;
            set
            {
                if (_chckbxSystemNotificationsShowNotificationsOnTheLockScreenOff == value)
                    return;

                _chckbxSystemNotificationsShowNotificationsOnTheLockScreenOff = value;
                OnPropertyChanged(nameof(ChckbxSystemNotificationsShowNotificationsOnTheLockScreenOff));
                SystemNotificationsShowNotificationsOnTheLockScreenOff();
            }
        }

        public void SystemNotificationsShowNotificationsOnTheLockScreenOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = "NOC_GLOBAL_SETTING_ALLOW_TOASTS_ABOVE_LOCK";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemNotificationsShowNotificationsOnTheLockScreenOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show reminders and incoming VOIP calls on the lock screen - Off - Command

        private Boolean _chckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen;
        public Boolean ChckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen
        {
            get => _chckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen;
            set
            {
                if (_chckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen == value)
                    return;

                _chckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen = value;
                OnPropertyChanged(nameof(ChckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen));
                SystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen();
            }
        }

        public void SystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = "NOC_GLOBAL_SETTING_ALLOW_CRITICAL_TOASTS_ABOVE_LOCK";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        #endregion

        #region Power

        // Checkbox - Screen and sleep - On battery power, turn off my screen after - 3 min. - Command

        private Boolean _chckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter;
        public Boolean ChckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter
        {
            get => _chckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter;
            set
            {
                if (_chckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter == value)
                    return;

                _chckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter = value;
                OnPropertyChanged(nameof(ChckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter));
                SystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter();
            }
        }

        public void SystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter()
        {
            string Exe = "cmd.exe";
            string Value = "/C powercfg /SETDCVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0";
            string Default = "/C powercfg /SETDCVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 300";

            if (ChckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter)
                Process.Start(Exe, Value);
            else
                Process.Start(Exe, Default);
        }


        // Checkbox - Screen and sleep - When plugged in, turn off my screen after - Never - Command

        private Boolean _chckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter;
        public Boolean ChckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter
        {
            get => _chckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter;
            set
            {
                if (_chckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter == value)
                    return;

                _chckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter = value;
                OnPropertyChanged(nameof(ChckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter));
                SystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter();
            }
        }

        public void SystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter()
        {
            string Exe = "cmd.exe";
            string Value = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0";
            string Default = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 300";

            if (ChckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter)
                Process.Start(Exe, Value);
            else
                Process.Start(Exe, Default);
        }


        // Checkbox - Screen and sleep - On battery power, put my device to sleep after - 3 Min. - Command

        private Boolean _chckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter;
        public Boolean ChckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter
        {
            get => _chckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter;
            set
            {
                if (_chckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter == value)
                    return;

                _chckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter = value;
                OnPropertyChanged(nameof(ChckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter));
                SystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter();
            }
        }
        public void SystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter()
        {
            string Exe = "cmd.exe";
            string Value = "/C powercfg /SETDCVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 0";
            string Default = "/C powercfg /SETDCVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 300";

            if (ChckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter)
                Process.Start(Exe, Value);
            else
                Process.Start(Exe, Default);
        }

        // Checkbox - Screen and sleep - When plugged in, put my device to sleep after - Never - Command

        private Boolean _chckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter;
        public Boolean ChckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter
        {
            get => _chckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter;
            set
            {
                if (_chckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter == value)
                    return;

                _chckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter = value;
                OnPropertyChanged(nameof(ChckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter));
                SystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter();
            }
        }
        public void SystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter()
        {
            string Exe = "cmd.exe";
            string Value = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 0";
            string Default = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 300";

            if (ChckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter)
                Process.Start(Exe, Value);
            else
                Process.Start(Exe, Default);
        }

        // Checkbox - Power mode - Optimize your device based on power use and performance - High performance - Command

        private Boolean _chckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance;
        public Boolean ChckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance
        {
            get => _chckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance;
            set
            {
                if (_chckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance == value)
                    return;

                _chckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance = value;
                OnPropertyChanged(nameof(ChckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance));
                SystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance();
            }
        }
        public void SystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C powercfg /setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";

            if (ChckbxSystemPowerModeOptimizeYourDeviceBasedOnPowerUseAndPerformance)
                Process.Start(Exe, Arguments);
        }


        #endregion

        #region Storage



        // Checkbox - Storage Sense - Automatically free up space, delete temporary files, and manage locally available cloud content - Off - Command

        private Boolean _chckbxSystemStorageStorageSense;
        public Boolean ChckbxSystemStorageStorageSense
        {
            get => _chckbxSystemStorageStorageSense;
            set
            {
                if (_chckbxSystemStorageStorageSense == value)
                    return;

                _chckbxSystemStorageStorageSense = value;
                OnPropertyChanged(nameof(ChckbxSystemStorageStorageSense));
                SystemStorageStorageSense();
            }
        }

        public void SystemStorageStorageSense()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy";
            string Name = "01";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemStorageStorageSense)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        #endregion

        #region Remote Desktop

        // Checkbox - Remote Desktop - Off - Command

        private Boolean _chckbxSystemRemoteDesktop;
        public Boolean ChckbxSystemRemoteDesktop
        {
            get => _chckbxSystemRemoteDesktop;
            set
            {
                if (_chckbxSystemRemoteDesktop == value)
                    return;

                _chckbxSystemRemoteDesktop = value;
                OnPropertyChanged(nameof(ChckbxSystemRemoteDesktop));
                SystemRemoteDesktop();
            }
        }

        public void SystemRemoteDesktop()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\"";
            string Name = "fDenyTSConnections";
            string Name2 = "updateRDStatus";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsValue2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemRemoteDesktop)
            {
                Process.Start(Exe, ArgsValue);
                Process.Start(Exe, ArgsValue2);
            }
            else
            {
                Process.Start(Exe, ArgsDefault);
                Process.Start(Exe, ArgsDefault2);
            }
        }


        #endregion

        #endregion

        #region Bluetooth & Devices

        #region Autoplay

        // Checkbox - Use AutoPlay for all media and devices - Off - Command

        private Boolean _chckbxBluetoothAndDevicesAutoplay;
        public Boolean ChckbxBluetoothAndDevicesAutoplay
        {
            get => _chckbxBluetoothAndDevicesAutoplay;
            set
            {
                if (_chckbxBluetoothAndDevicesAutoplay == value)
                    return;

                _chckbxBluetoothAndDevicesAutoplay = value;
                OnPropertyChanged(nameof(ChckbxBluetoothAndDevicesAutoplay));
                BluetoothAndDevicesAutoplay();
            }
        }

        public void BluetoothAndDevicesAutoplay()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoplayHandlers";
            string Name = "DisableAutoplay";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxBluetoothAndDevicesAutoplay)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #endregion

        #region Network & Internet

        #region Advanced Sharing Settings



        // Checkbox - Network discovery - Your PC can find and be found by other devices on the network - On - Command

        private Boolean _chckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery;
        public Boolean ChckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery
        {
            get => _chckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery;
            set
            {
                if (_chckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery == value)
                    return;

                _chckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery = value;
                OnPropertyChanged(nameof(ChckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery));
                NetworkAndInternetAdvancedSharingSettingsNetworkDiscovery();
            }
        }

        public void NetworkAndInternetAdvancedSharingSettingsNetworkDiscovery()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C netsh advfirewall firewall set rule group='Network Discovery' new enable=Yes";

            if (ChckbxNetworkAndInternetAdvancedSharingSettingsNetworkDiscovery)
                Process.Start(Exe, Arguments);
        }

        // Checkbox - File and printer sharing - Allow others on the network to acces shared files and printers on this device - On - Command

        private Boolean _chckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing;
        public Boolean ChckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing
        {
            get => _chckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing;
            set
            {
                if (_chckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing == value)
                    return;

                _chckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing = value;
                OnPropertyChanged(nameof(ChckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing));
                NetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing();
            }
        }

        public void NetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C netsh advfirewall firewall set rule group='File and Printer Sharing' new enable=Yes";

            if (ChckbxNetworkAndInternetAdvancedSharingSettingsFileAndPrinterSharing)
                Process.Start(Exe, Arguments);
        }

        #endregion

        #endregion

        #region personalization

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
            string Exe = "cmd.exe";
            string Value = "/C Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 1 /f";
            Process.Start(Exe, Value);
            
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
            string Exe = "cmd.exe";
            string Value = "/C Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v SystemUsesLightTheme /t REG_DWORD /d 0 /f";
            Process.Start(Exe, Value);
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
            string Exe = "cmd.exe";
            string Value = "/C Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 1 /f";
            Process.Start(Exe, Value);
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
            string Exe = "cmd.exe";
            string Value = "/C Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 0 /f";
            Process.Start(Exe, Value);

            //          Process.Start("wt", "Reg Add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize\" /v AppsUseLightTheme /t REG_DWORD /d 0 /f");
            // Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize' -Name AppsUseLightTheme -Value 0");
        }


        // Checkbox - Transparancy Effects - Off - Command

        private Boolean _chckbxPersonalizationColorsTransparancyEffects;
        public Boolean ChckbxPersonalizationColorsTransparancyEffects
        {
            get => _chckbxPersonalizationColorsTransparancyEffects;
            set
            {
                if (_chckbxPersonalizationColorsTransparancyEffects == value)
                    return;

                _chckbxPersonalizationColorsTransparancyEffects = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationColorsTransparancyEffects));
                PersonalizationColorsTransparancyEffects();
            }
        }

        public void PersonalizationColorsTransparancyEffects()
        {
            string Exe = "cmd.exe";
            string RegistryPath ="HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";
            string Name = "EnableTransparency";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationColorsTransparancyEffects)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show accent color on Start and taskbar - On - Command

        private Boolean _chckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar;
        public Boolean ChckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar
        {
            get => _chckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar;
            set
            {
                if (_chckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar == value)
                    return;

                _chckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar));
                PersonalizationColorsShowAccentColorOnStartAndTaskbar();
            }
        }

        public void PersonalizationColorsShowAccentColorOnStartAndTaskbar()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";
            string Name = "ColorPrevalence";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show accent color on title bars and windows borders - On - Command

        private Boolean _chckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders;
        public Boolean ChckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders
        {
            get => _chckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders;
            set
            {
                if (_chckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders == value)
                    return;

                _chckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders));
                PersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders();
            }
        }

        public void PersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\DWM";
            string Name = "ColorPrevalence";
            string Type = "REG_DWORD";
            string Value = @"1";
            string Default = @"0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "powershell.exe";
            string Click = "Rename-Computer -NewName " + ChangedPcName;
            Process.Start(Exe, Click);
            //          MessageBox.Show("Accent Clicked");
            //Process.Start("wt.exe", "powershell Rename-Computer -NewName " + ChangedPcName);

        }

        #endregion

        #region Start

        // Checkbox - Show recently added apps - Off - Command

        private Boolean _chckbxPersonalizationStartShowRecentlyAddedApps;
        public Boolean ChckbxPersonalizationStartShowRecentlyAddedApps
        {
            get => _chckbxPersonalizationStartShowRecentlyAddedApps;
            set
            {
                if (_chckbxPersonalizationStartShowRecentlyAddedApps == value)
                    return;

                _chckbxPersonalizationStartShowRecentlyAddedApps = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationStartShowRecentlyAddedApps));
                PersonalizationStartShowRecentlyAddedApps();
            }
        }

        public void PersonalizationStartShowRecentlyAddedApps()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer";
            string Name = "HideRecentlyAddedApps";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationStartShowRecentlyAddedApps)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show Most Used Apps - Off (and grayed out) - Command

        private Boolean _chckbxPersonalizationStartShowMostUsedApps;
        public Boolean ChckbxPersonalizationStartShowMostUsedApps
        {
            get => _chckbxPersonalizationStartShowMostUsedApps;
            set
            {
                if (_chckbxPersonalizationStartShowMostUsedApps == value)
                    return;

                _chckbxPersonalizationStartShowMostUsedApps = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationStartShowMostUsedApps));
                PersonalizationStartShowMostUsedApps();
            }
        }

        public void PersonalizationStartShowMostUsedApps()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer";
            string Name = "ShowOrHideMostUsedApps";
            string Type = "REG_DWORD";
            string Value = "2";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationStartShowMostUsedApps)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Show recently opened items in jump list on start or the taskbar and in File Explorer Quick Acces - Off - Command

        private Boolean _chckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList;
        public Boolean ChckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList
        {
            get => _chckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList;
            set
            {
                if (_chckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList == value)
                    return;

                _chckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList));
                PersonalizationStartShowRecentlyOpenedItemsInJumpList();
            }
        }

        public void PersonalizationStartShowRecentlyOpenedItemsInJumpList()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "Start_TrackDocs";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - Turn Recommended - Off - Command

        private Boolean _chckbxPersonalizationStartRecommended;
        public Boolean ChckbxPersonalizationStartRecommended
        {
            get => _chckbxPersonalizationStartRecommended;
            set
            {
                if (_chckbxPersonalizationStartRecommended == value)
                    return;

                _chckbxPersonalizationStartRecommended = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationStartRecommended));
                PersonalizationStartRecommended();
            }
        }

        public void PersonalizationStartRecommended()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer";
            string Name = "HideRecommendedSection";
            string Type = "REG_DWORD";
            string Value = "1";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxPersonalizationStartRecommended)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - Remove all pinned Apps and load MG Marty's defaults - Command

        private Boolean _chckbxPersonalizationStartRemoveAllPinnedLoadDefaults;
        public Boolean ChckbxPersonalizationStartRemoveAllPinnedLoadDefaults
        {
            get => _chckbxPersonalizationStartRemoveAllPinnedLoadDefaults;
            set
            {
                if (_chckbxPersonalizationStartRemoveAllPinnedLoadDefaults == value)
                    return;

                _chckbxPersonalizationStartRemoveAllPinnedLoadDefaults = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationStartRemoveAllPinnedLoadDefaults));
                PersonalizationStartRemoveAllPinnedLoadDefaults();
            }
        }


        public void PersonalizationStartRemoveAllPinnedLoadDefaults()
        {
            string Exe = "cmd.exe";
            string Path = "%LocalAppData%\\Packages\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy\\LocalState\\";
            string File = "start2.bin";
            string ArgsValue = "/C DEL /F /S /Q /A \"%LocalAppData%\\Packages\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy\\LocalState\\start2.bin\"";
            string ArgsValue2 = "/C taskkill /im StartMenuExperienceHost.exe /f";
            string ArgsValue3 = "/C start C:\\Windows\\SystemApps\\Microsoft.Windows.StartMenuExperienceHost_cw5n1h2txyewy\\StartMenuExperienceHost.exe";

            if (ChckbxPersonalizationStartRemoveAllPinnedLoadDefaults)
            {
                Process.Start(Exe, ArgsValue);
                Process.Start(Exe, ArgsValue2);
                Process.Start(Exe, ArgsValue3);
            }
        }

        #endregion

        #region Taskbar

        // Checkbox - Hide 'Search' - Command

        private Boolean _chckbxPersonalizationTaskbarHideSearch;
        public Boolean ChckbxPersonalizationTaskbarHideSearch
        {
            get => _chckbxPersonalizationTaskbarHideSearch;
            set
            {
                if (_chckbxPersonalizationTaskbarHideSearch == value)
                    return;

                _chckbxPersonalizationTaskbarHideSearch = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideSearch));
                PersonalizationTaskbarHideSearch();
            }
        }

        public void PersonalizationTaskbarHideSearch()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search";
            string Name = "SearchboxTaskbarMode";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideSearch)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Hide 'Task View' - Command

        private Boolean _chckbxPersonalizationTaskbarHideTaskView;
        public Boolean ChckbxPersonalizationTaskbarHideTaskView
        {
            get => _chckbxPersonalizationTaskbarHideTaskView;
            set
            {
                if (_chckbxPersonalizationTaskbarHideTaskView == value)
                    return;

                _chckbxPersonalizationTaskbarHideTaskView = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideTaskView));
                PersonalizationTaskbarHideTaskView();
            }
        }

        public void PersonalizationTaskbarHideTaskView()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "ShowTaskViewButton";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideTaskView)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Hide 'Widgets' - Command

        private Boolean _chckbxPersonalizationTaskbarHideWidgets;
        public Boolean ChckbxPersonalizationTaskbarHideWidgets
        {
            get => _chckbxPersonalizationTaskbarHideWidgets;
            set
            {
                if (_chckbxPersonalizationTaskbarHideWidgets == value)
                    return;

                _chckbxPersonalizationTaskbarHideWidgets = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideWidgets));
                PersonalizationTaskbarHideWidgets();
            }
        }

        public void PersonalizationTaskbarHideWidgets()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "TaskbarDa";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideWidgets)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Hide 'Chat' - Command

        private Boolean _chckbxPersonalizationTaskbarHideChat;
        public Boolean ChckbxPersonalizationTaskbarHideChat
        {
            get => _chckbxPersonalizationTaskbarHideChat;
            set
            {
                if (_chckbxPersonalizationTaskbarHideChat == value)
                    return;

                _chckbxPersonalizationTaskbarHideChat = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideChat));
                PersonalizationTaskbarHideChat();
            }
        }

        public void PersonalizationTaskbarHideChat()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "TaskbarMn";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideChat)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


       



        // Checkbox - Hide 'Pen Menu' - Command

        private Boolean _chckbxPersonalizationTaskbarHidePenMenu;
        public Boolean ChckbxPersonalizationTaskbarHidePenMenu
        {
            get => _chckbxPersonalizationTaskbarHidePenMenu;
            set
            {
                if (_chckbxPersonalizationTaskbarHidePenMenu == value)
                    return;

                _chckbxPersonalizationTaskbarHidePenMenu = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHidePenMenu));
                PersonalizationTaskbarHidePenMenu();
            }
        }

        public void PersonalizationTaskbarHidePenMenu()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\PenWorkspace";
            string Name = "PenWorkspaceButtonDesiredVisibility";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHidePenMenu)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Hide 'Touch Keyboard' - Command

        private Boolean _chckbxPersonalizationTaskbarHideTouchKeyboard;
        public Boolean ChckbxPersonalizationTaskbarHideTouchKeyboard
        {
            get => _chckbxPersonalizationTaskbarHideTouchKeyboard;
            set
            {
                if (_chckbxPersonalizationTaskbarHideTouchKeyboard == value)
                    return;

                _chckbxPersonalizationTaskbarHideTouchKeyboard = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideTouchKeyboard));
                PersonalizationTaskbarHideTouchKeyboard();
            }
        }

        public void PersonalizationTaskbarHideTouchKeyboard()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\SOFTWARE\\Microsoft\\TabletTip\\1.7\"";
            string Name = "TipbandDesiredVisibility";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideTouchKeyboard)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Hide 'Virtual Touchpad' - Command

        private Boolean _chckbxPersonalizationTaskbarHideVirtualTouchpad;
        public Boolean ChckbxPersonalizationTaskbarHideVirtualTouchpad
        {
            get => _chckbxPersonalizationTaskbarHideVirtualTouchpad;
            set
            {
                if (_chckbxPersonalizationTaskbarHideVirtualTouchpad == value)
                    return;

                _chckbxPersonalizationTaskbarHideVirtualTouchpad = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarHideVirtualTouchpad));
                PersonalizationTaskbarHideVirtualTouchpad();
            }
        }

        public void PersonalizationTaskbarHideVirtualTouchpad()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Touchpad";
            string Name = "TouchpadDesiredVisibility";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarHideVirtualTouchpad)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Taskbar Behaviors

        // Checkbox - Taskbar alignment - Left - Command

        private Boolean _chckbxPersonalizationTaskbarBehaviorsTaskbarAlignment;
        public Boolean ChckbxPersonalizationTaskbarBehaviorsTaskbarAlignment
        {
            get => _chckbxPersonalizationTaskbarBehaviorsTaskbarAlignment;
            set
            {
                if (_chckbxPersonalizationTaskbarBehaviorsTaskbarAlignment == value)
                    return;

                _chckbxPersonalizationTaskbarBehaviorsTaskbarAlignment = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarBehaviorsTaskbarAlignment));
                PersonalizationTaskbarBehaviorsTaskbarAlignment();
            }
        }

        public void PersonalizationTaskbarBehaviorsTaskbarAlignment()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "TaskbarAl";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPersonalizationTaskbarBehaviorsTaskbarAlignment)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - Clear all Taskbar Items - Command

        private Boolean _chckbxPersonalizationTaskbarClearAll;
        public Boolean ChckbxPersonalizationTaskbarClearAll
        {
            get => _chckbxPersonalizationTaskbarClearAll;
            set
            {
                if (_chckbxPersonalizationTaskbarClearAll == value)
                    return;

                _chckbxPersonalizationTaskbarClearAll = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarClearAll));
                PersonalizationTaskbarClearAll();
            }
        }

        public void PersonalizationTaskbarClearAll()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Taskband";
            string Name = "TaskbarMn";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C DEL /F /S /Q /A \"%AppData%\\Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar\\*\"";
            string ArgsValue2 = "/C Reg delete " + RegistryPath + " /f";
            string ArgsValue3 = "/C taskkill /F /IM explorer.exe";
            string ArgsValue4 = "/C start explorer";

            if (ChckbxPersonalizationTaskbarClearAll)
            {
                Process.Start(Exe, ArgsValue).WaitForExit(500000);
                Process.Start(Exe, ArgsValue2).WaitForExit(500000);
                Process.Start(Exe, ArgsValue3).WaitForExit(500000);
                Process.Start(Exe, ArgsValue4);
            }
        }

        // Checkbox - Automatically hide the taskbar - Command

        private Boolean _chckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar;
        public Boolean ChckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar
        {
            get => _chckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar;
            set
            {
                if (_chckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar == value)
                    return;

                _chckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar = value;
                OnPropertyChanged(nameof(ChckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar));
                PersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar();
            }
        }

        private void PersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar()
        {
            if (ChckbxPersonalizationTaskbarBehaviorsAutomaticlyHideTheTaskbar)
            {
                Process.Start("cmd.exe", "/C reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3\" /v \"Settings\" /t REG_BINARY /d 30000000feffffff7af400000300000030000000300000000000000070050000000a0000a00500006000000001000000 /f");
                //Process.Start("wt.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3' -Name Settings -Value ([byte[]](0x30,0x00,0x00,0x00,0xfe,0xff,0xff,0xff,0x7a,0xf4,0x00,0x00,0x03,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0xa0,0x05,0x00,0x00,0x60,0x00,0x00,0x00,0x01,0x00,0x00,0x00))");
                Process.Start("cmd.exe", "/C taskkill /f /im explorer.exe");
                Process.Start("powershell.exe", "Start-Process explorer");

            }
            else
            {
                Process.Start("cmd.exe", "/C reg add \"HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3\" /v \"Settings\" /t REG_BINARY /d 30000000feffffff7bf400000300000030000000300000000000000070050000000a0000a00500006000000001000000 /f");
                //Process.Start("cmd.exe", "powershell Set-ItemProperty -Path 'HKCU:\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StuckRects3' -Name Settings -Value ([byte[]](0x30,0x00,0x00,0x00,0xfe,0xff,0xff,0xff,0x7b,0xf4,0x00,0x00,0x03,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x30,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x05,0x00,0x00,0x00,0x0a,0x00,0x00,0xa0,0x05,0x00,0x00,0x60,0x00,0x00,0x00,0x01,0x00,0x00,0x00))");
                Process.Start("cmd.exe", "/C taskkill /f /im explorer.exe");
                Process.Start("powershell.exe", "Start-Process explorer");
            }
        }

        #endregion

        #endregion

        #region Apps

        #region Offline Maps

        // Checkbox - Update automatically when plugged in and on Wi-Fi - Off - Command

        private Boolean _chckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi;
        public Boolean ChckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi
        {
            get => _chckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi;
            set
            {
                if (_chckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi == value)
                    return;

                _chckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi = value;
                OnPropertyChanged(nameof(ChckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi));
                AppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi();
            }
        }

        public void AppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SYSTEM\\Maps";
            string Name = "AutoUpdateEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #endregion

        #region Gaming

        #region Captures

        // Checkbox - When something cool happened in your game, press Windows logo key + Alt + G to capture the moment - Off - Command

        private Boolean _chckbxGamingCapturesWhenSomethingCoolHappenedInYourGame;
        public Boolean ChckbxGamingCapturesWhenSomethingCoolHappenedInYourGame
        {
            get => _chckbxGamingCapturesWhenSomethingCoolHappenedInYourGame;
            set
            {
                if (_chckbxGamingCapturesWhenSomethingCoolHappenedInYourGame == value)
                    return;

                _chckbxGamingCapturesWhenSomethingCoolHappenedInYourGame = value;
                OnPropertyChanged(nameof(ChckbxGamingCapturesWhenSomethingCoolHappenedInYourGame));
                GamingCapturesWhenSomethingCoolHappenedInYourGame();
            }
        }

        public void GamingCapturesWhenSomethingCoolHappenedInYourGame()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR";
            string Name = "HistoricalCaptureEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxGamingCapturesWhenSomethingCoolHappenedInYourGame)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #endregion

        #region Privacy & Security

        #region For Developers

        // Checkbox - Set 'Terminal' to 'Windows Terminal' - Command

        private Boolean _chckbxPrivacyAndSecurityForDevelopersSetTerminal;
        public Boolean ChckbxPrivacyAndSecurityForDevelopersSetTerminal
        {
            get => _chckbxPrivacyAndSecurityForDevelopersSetTerminal;
            set
            {
                if (_chckbxPrivacyAndSecurityForDevelopersSetTerminal == value)
                    return;

                _chckbxPrivacyAndSecurityForDevelopersSetTerminal = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityForDevelopersSetTerminal));
                PrivacyAndSecurityForDevelopersSetTerminal();
            }
        }

        public void PrivacyAndSecurityForDevelopersSetTerminal()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Console\\%%Startup\\";
            string Name = "DelegationConsole";
            string Name2 = "DelegationTerminal";
            string Type = "REG_SZ";
            string Value = "\"{2EACA947-7F5F-4CFA-BA87-8F7FBEEFBE69}\"";
            string Value2 = "\"{E12CFF52-A866-4C77-9A90-F570A7AA2C6B}\"";
            string Default = "\"{00000000-0000-0000-0000-000000000000}\"";
            

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsValue2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value2 + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecurityForDevelopersSetTerminal)
            {
                Process.Start(Exe, ArgsValue).WaitForExit(50000);
                Process.Start(Exe, ArgsValue2);
            }
            else
            {
                Process.Start(Exe, ArgsDefault).WaitForExit(50000);
                Process.Start(Exe, ArgsDefault2);
            }
        }


        #endregion

        #region General

        // Checkbox - Let websites show me locally relevant content by accessing my language List - Off - Command

        private Boolean _chckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList;
        public Boolean ChckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList
        {
            get => _chckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList;
            set
            {
                if (_chckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList == value)
                    return;

                _chckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList));
                PrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList();
            }
        }

        public void PrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\International\\User Profile\"";
            string Name = "HttpAcceptLanguageOptOut";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Let Windows improve Start and search results by tracking app launches - Off - Command

        private Boolean _chckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches;
        public Boolean ChckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches
        {
            get => _chckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches;
            set
            {
                if (_chckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches == value)
                    return;

                _chckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches));
                PrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches();
            }
        }

        public void PrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "Start_TrackProgs";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - Show me suggested content in the Settings app - Off - Command

        private Boolean _chckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp;
        public Boolean ChckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp
        {
            get => _chckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp;
            set
            {
                if (_chckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp == value)
                    return;

                _chckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp));
                PrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp();
            }
        }

        public void PrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ContentDeliveryManager";
            string Name = "SubscribedContent-338393Enabled";
            string Name2 = "SubscribedContent-353694Enabled";
            string Name3 = "SubscribedContent-353696Enabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsChecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp)
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

        #region Inking & Typing Personalization

        // Checkbox - Personal inking and typing dictionary - Off - Command

        private Boolean _chckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary;
        public Boolean ChckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary
        {
            get => _chckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary;
            set
            {
                if (_chckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary == value)
                    return;

                _chckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary));
                PrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary();
            }
        }

        public void PrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\InkingAndTypingPersonalization";
            string RegistryPath2 = "HKCU\\Software\\Microsoft\\Personalization\\Settings";
            string RegistryPath3 = "HKCU\\Software\\Microsoft\\InputPersonalization";
            string RegistryPath4 = "HKCU\\Software\\Microsoft\\InputPersonalization\\TrainedDataStore";
            string Name = "Value";
            string Name2 = "AcceptedPrivacyPolicy";
            string Name3 = "RestrictImplicitTextCollection";
            string Name4 = "RestrictImplicitInkCollection";
            string Name5 = "HarvestContacts";
            string Type = "REG_DWORD";
            string Value = "0";
            string Value2 = "1";
            string Default = "1";
            string Default2 = "0";

            
            string ArgsChecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked2 = "/C Reg Add " + RegistryPath2 + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsChecked3 = "/C Reg Add " + RegistryPath3 + " /v " + Name3 + " /t " + Type + " /d " + Value2 + " /f";
            string ArgsChecked4 = "/C Reg Add " + RegistryPath3 + " /v " + Name4 + " /t " + Type + " /d " + Value2 + " /f";
            string ArgsChecked5 = "/C Reg Add " + RegistryPath4 + " /v " + Name5 + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked2 = "/C Reg Add " + RegistryPath2 + " /v " + Name2 + " /t " + Type + " /d " + Default + " /f";
            string ArgsUnchecked3 = "/C Reg Add " + RegistryPath3 + " /v " + Name3 + " /t " + Type + " /d " + Default2 + " /f";
            string ArgsUnchecked4 = "/C Reg Add " + RegistryPath3 + " /v " + Name4 + " /t " + Type + " /d " + Default2 + " /f";
            string ArgsUnchecked5 = "/C Reg Add " + RegistryPath4 + " /v " + Name5 + " /t " + Type + " /d " + Default + " /f";
            
            if (ChckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary)
            {
                Process.Start(Exe, ArgsChecked);
                Process.Start(Exe, ArgsChecked2);
                Process.Start(Exe, ArgsChecked3);
                Process.Start(Exe, ArgsChecked4);
                Process.Start(Exe, ArgsChecked5);
            }
            else
            {
                Process.Start(Exe, ArgsUnchecked);
                Process.Start(Exe, ArgsUnchecked2);
                Process.Start(Exe, ArgsUnchecked3);
                Process.Start(Exe, ArgsUnchecked4);
                Process.Start(Exe, ArgsUnchecked5);
            }
                
        }

        #endregion

        #region Diagnostics and Feedback


        // CheckBox - Diagnostic Data - Command
        private Boolean _chckbxDiagnosticsAndFeedbackDiagnosticsData;
        public Boolean ChckbxDiagnosticsAndFeedbackDiagnosticsData
        {
            get => _chckbxDiagnosticsAndFeedbackDiagnosticsData;
            set
            {
                if (_chckbxDiagnosticsAndFeedbackDiagnosticsData == value)
                    return;

                _chckbxDiagnosticsAndFeedbackDiagnosticsData = value;
                OnPropertyChanged(nameof(ChckbxDiagnosticsAndFeedbackDiagnosticsData));
                DiagnosticsAndFeedbackDiagnosticsData();
            }
        }

        private void DiagnosticsAndFeedbackDiagnosticsData()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection";
            string Name = "AllowTelemetry";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxDiagnosticsAndFeedbackDiagnosticsData)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // CheckBox - Feedback Frequency - Command
        private Boolean _chckbxDiagnosticsAndFeedbackFeedbackFrequency;
        public Boolean ChckbxDiagnosticsAndFeedbackFeedbackFrequency
        {
            get => _chckbxDiagnosticsAndFeedbackFeedbackFrequency;
            set
            {
                if (_chckbxDiagnosticsAndFeedbackFeedbackFrequency == value)
                    return;

                _chckbxDiagnosticsAndFeedbackFeedbackFrequency = value;
                OnPropertyChanged(nameof(ChckbxDiagnosticsAndFeedbackFeedbackFrequency));
                DiagnosticsAndFeedbackFeedbackFrequency();
            }
        }

        private void DiagnosticsAndFeedbackFeedbackFrequency()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Siuf\\Rules";
            string Name = "NumberOfSIUFInPeriod";
            string Type = "REG_DWORD";
            string Value = "0";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxDiagnosticsAndFeedbackFeedbackFrequency)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        #endregion

        #region Activity History

        // Checkbox - Store my activity history on this device - Off - Command

        private Boolean _chckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice;
        public Boolean ChckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice
        {
            get => _chckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice;
            set
            {
                if (_chckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice == value)
                    return;

                _chckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice));
                PrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice();
            }
        }

        public void PrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows\\System";
            string Name = "PublishUserActivities";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #region Search Permission

        // Checkbox - Turn 'SafeSearch' - Off - Command

        private Boolean _chckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff;
        public Boolean ChckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff
        {
            get => _chckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff;
            set
            {
                if (_chckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff == value)
                    return;

                _chckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff));
                PrivacyAndSecuritySearchPermissionsSetSafeSearchOff();
            }
        }

        public void PrivacyAndSecuritySearchPermissionsSetSafeSearchOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = "SafeSearchMode";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Cloud Content Search - Microsoft account - Off - Command

        private Boolean _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount;
        public Boolean ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount
        {
            get => _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount;
            set
            {
                if (_chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount == value)
                    return;

                _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount));
                PrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount();
            }
        }

        public void PrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = "IsMSACloudSearchEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - Cloud Content Search - Work or School account - Off - Command

        private Boolean _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount;
        public Boolean ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount
        {
            get => _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount;
            set
            {
                if (_chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount == value)
                    return;

                _chckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount));
                PrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount();
            }
        }

        public void PrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = "IsAADCloudSearchEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - History - Search history on this device - Off - Command

        private Boolean _chckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice;
        public Boolean ChckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice
        {
            get => _chckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice;
            set
            {
                if (_chckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice == value)
                    return;

                _chckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice));
                PrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice();
            }
        }

        public void PrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = "IsDeviceSearchHistoryEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - More Settings - Show search highlights - Off - Command

        private Boolean _chckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights;
        public Boolean ChckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights
        {
            get => _chckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights;
            set
            {
                if (_chckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights == value)
                    return;

                _chckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights = value;
                OnPropertyChanged(nameof(ChckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights));
                PrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights();
            }
        }

        public void PrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = "IsDynamicSearchBoxEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #region App Permissions

        // Checkbox - App permissions - Voice Activation - Let apps acces 'Voice Activation Services' - Off - Command

        private Boolean _chckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff;
        public Boolean ChckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff
        {
            get => _chckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff;
            set
            {
                if (_chckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff == value)
                    return;

                _chckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff));
                AppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff();
            }
        }

        public void AppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps";
            string Name = "AgentActivationEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - App permissions - Voice Activation - Let apps use 'Voice Activation' when device is locked - Off - Command

        private Boolean _chckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff;
        public Boolean ChckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff
        {
            get => _chckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff;
            set
            {
                if (_chckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff == value)
                    return;

                _chckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff));
                AppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff();
            }
        }

        public void AppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps";
            string Name = "AgentActivationOnLockScreenEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - App permissions - Notification - Command

        private Boolean _chckbxAppPermissionsNotificationsLetAppsAccesYourNotifications;
        public Boolean ChckbxAppPermissionsNotificationsLetAppsAccesYourNotifications
        {
            get => _chckbxAppPermissionsNotificationsLetAppsAccesYourNotifications;
            set
            {
                if (_chckbxAppPermissionsNotificationsLetAppsAccesYourNotifications == value)
                    return;

                _chckbxAppPermissionsNotificationsLetAppsAccesYourNotifications = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsNotificationsLetAppsAccesYourNotifications));
                AppPermissionsNotificationsLetAppsAccesYourNotifications();
            }
        }

        public void AppPermissionsNotificationsLetAppsAccesYourNotifications()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsNotificationsLetAppsAccesYourNotifications)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - App permissions - Account Info - Command

        private Boolean _chckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo;
        public Boolean ChckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo
        {
            get => _chckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo;
            set
            {
                if (_chckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo == value)
                    return;

                _chckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo));
                AppPermissionsAccountInfoLetAppsAccesYourAccountInfo();
            }
        }

        public void AppPermissionsAccountInfoLetAppsAccesYourAccountInfo()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - App permissions - Contacts - Command

        private Boolean _chckbxAppPermissionsContactsLetAppsAccesYourContacts;
        public Boolean ChckbxAppPermissionsContactsLetAppsAccesYourContacts
        {
            get => _chckbxAppPermissionsContactsLetAppsAccesYourContacts;
            set
            {
                if (_chckbxAppPermissionsContactsLetAppsAccesYourContacts == value)
                    return;

                _chckbxAppPermissionsContactsLetAppsAccesYourContacts = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsContactsLetAppsAccesYourContacts));
                AppPermissionsContactsLetAppsAccesYourContacts();
            }
        }

        public void AppPermissionsContactsLetAppsAccesYourContacts()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsContactsLetAppsAccesYourContacts)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Calendar - Command

        private Boolean _chckbxAppPermissionsCalendarLetAppsAccesYourCalendar;
        public Boolean ChckbxAppPermissionsCalendarLetAppsAccesYourCalendar
        {
            get => _chckbxAppPermissionsCalendarLetAppsAccesYourCalendar;
            set
            {
                if (_chckbxAppPermissionsCalendarLetAppsAccesYourCalendar == value)
                    return;

                _chckbxAppPermissionsCalendarLetAppsAccesYourCalendar = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsCalendarLetAppsAccesYourCalendar));
                AppPermissionsCalendarLetAppsAccesYourCalendar();
            }
        }

        public void AppPermissionsCalendarLetAppsAccesYourCalendar()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appointments";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsCalendarLetAppsAccesYourCalendar)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Phone Calls - Command

        private Boolean _chckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls;
        public Boolean ChckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls
        {
            get => _chckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls;
            set
            {
                if (_chckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls == value)
                    return;

                _chckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls));
                AppPermissionsPhoneCallsLetAppsMakePhoneCalls();
            }
        }

        public void AppPermissionsPhoneCallsLetAppsMakePhoneCalls()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Call History - Command

        private Boolean _chckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory;
        public Boolean ChckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory
        {
            get => _chckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory;
            set
            {
                if (_chckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory == value)
                    return;

                _chckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory));
                AppPermissionsCallHistoryLetAppsAccesYourCallHistory();
            }
        }

        public void AppPermissionsCallHistoryLetAppsAccesYourCallHistory()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Email - Command

        private Boolean _chckbxAppPermissionsEmailLetAppsAccesYourEmail;
        public Boolean ChckbxAppPermissionsEmailLetAppsAccesYourEmail
        {
            get => _chckbxAppPermissionsEmailLetAppsAccesYourEmail;
            set
            {
                if (_chckbxAppPermissionsEmailLetAppsAccesYourEmail == value)
                    return;

                _chckbxAppPermissionsEmailLetAppsAccesYourEmail = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsEmailLetAppsAccesYourEmail));
                AppPermissionsEmailLetAppsAccesYourEmail();
            }
        }

        public void AppPermissionsEmailLetAppsAccesYourEmail()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\email";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsEmailLetAppsAccesYourEmail)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Tasks - Command

        private Boolean _chckbxAppPermissionsTasksLetAppsAccesYourTasks;
        public Boolean ChckbxAppPermissionsTasksLetAppsAccesYourTasks
        {
            get => _chckbxAppPermissionsTasksLetAppsAccesYourTasks;
            set
            {
                if (_chckbxAppPermissionsTasksLetAppsAccesYourTasks == value)
                    return;

                _chckbxAppPermissionsTasksLetAppsAccesYourTasks = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsTasksLetAppsAccesYourTasks));
                AppPermissionsTasksLetAppsAccesYourTasks();
            }
        }

        public void AppPermissionsTasksLetAppsAccesYourTasks()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsTasksLetAppsAccesYourTasks)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Messaging - Command

        private Boolean _chckbxAppPermissionsMessagingLetAppsReadYourMessages;
        public Boolean ChckbxAppPermissionsMessagingLetAppsReadYourMessages
        {
            get => _chckbxAppPermissionsMessagingLetAppsReadYourMessages;
            set
            {
                if (_chckbxAppPermissionsMessagingLetAppsReadYourMessages == value)
                    return;

                _chckbxAppPermissionsMessagingLetAppsReadYourMessages = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsMessagingLetAppsReadYourMessages));
                AppPermissionsMessagingLetAppsReadYourMessages();
            }
        }

        public void AppPermissionsMessagingLetAppsReadYourMessages()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsMessagingLetAppsReadYourMessages)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Radios - Command

        private Boolean _chckbxAppPermissionsRadiosLetAppsControlDeviceRadios;
        public Boolean ChckbxAppPermissionsRadiosLetAppsControlDeviceRadios
        {
            get => _chckbxAppPermissionsRadiosLetAppsControlDeviceRadios;
            set
            {
                if (_chckbxAppPermissionsRadiosLetAppsControlDeviceRadios == value)
                    return;

                _chckbxAppPermissionsRadiosLetAppsControlDeviceRadios = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsRadiosLetAppsControlDeviceRadios));
                AppPermissionsRadiosLetAppsControlDeviceRadios();
            }
        }

        public void AppPermissionsRadiosLetAppsControlDeviceRadios()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsRadiosLetAppsControlDeviceRadios)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Other Devices - Command

        private Boolean _chckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices;
        public Boolean ChckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices
        {
            get => _chckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices;
            set
            {
                if (_chckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices == value)
                    return;

                _chckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices));
                AppPermissionsOtherDevicesCommunicateWithUnpairedDevices();
            }
        }

        public void AppPermissionsOtherDevicesCommunicateWithUnpairedDevices()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - App Diagnostics - Command

        private Boolean _chckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps;
        public Boolean ChckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps
        {
            get => _chckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps;
            set
            {
                if (_chckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps == value)
                    return;

                _chckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps));
                AppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps();
            }
        }

        public void AppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Documents - Command

        private Boolean _chckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary;
        public Boolean ChckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary
        {
            get => _chckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary;
            set
            {
                if (_chckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary == value)
                    return;

                _chckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary));
                AppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary();
            }
        }

        public void AppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Downloads Folder - Command

        private Boolean _chckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder;
        public Boolean ChckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder
        {
            get => _chckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder;
            set
            {
                if (_chckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder == value)
                    return;

                _chckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder));
                AppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder();
            }
        }

        public void AppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\downloadsFolder";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";
            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Music Library - Command

        private Boolean _chckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary;
        public Boolean ChckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary
        {
            get => _chckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary;
            set
            {
                if (_chckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary == value)
                    return;

                _chckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary));
                AppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary();
            }
        }

        public void AppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\musicLibrary";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Pictures - Command

        private Boolean _chckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary;
        public Boolean ChckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary
        {
            get => _chckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary;
            set
            {
                if (_chckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary == value)
                    return;

                _chckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary));
                AppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary();
            }
        }

        public void AppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\picturesLibrary";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Videos - Command

        private Boolean _chckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary;
        public Boolean ChckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary
        {
            get => _chckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary;
            set
            {
                if (_chckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary == value)
                    return;

                _chckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary));
                AppPermissionsVideosAllowAppsToAccesYourVideosLibrary();
            }
        }

        public void AppPermissionsVideosAllowAppsToAccesYourVideosLibrary()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\videosLibrary";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - File System - Command

        private Boolean _chckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem;
        public Boolean ChckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem
        {
            get => _chckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem;
            set
            {
                if (_chckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem == value)
                    return;

                _chckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem));
                AppPermissionsFileSystemLetAppsAccesYourFileSystem();
            }
        }

        public void AppPermissionsFileSystemLetAppsAccesYourFileSystem()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\broadFileSystemAccess";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        // Checkbox - App permissions - Screenshot Borders - Command

        private Boolean _chckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder;
        public Boolean ChckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder
        {
            get => _chckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder;
            set
            {
                if (_chckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder == value)
                    return;

                _chckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder));
                AppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder();
            }
        }

        public void AppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureWithoutBorder";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Screenshot Borders - Command

        private Boolean _chckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays;
        public Boolean ChckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays
        {
            get => _chckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays;
            set
            {
                if (_chckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays == value)
                    return;

                _chckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays));
                AppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays();
            }
        }

        public void AppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureWithoutBorder\\NonPackaged";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Screenshots And Appss - Command

        private Boolean _chckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays;
        public Boolean ChckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays
        {
            get => _chckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays;
            set
            {
                if (_chckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays == value)
                    return;

                _chckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays));
                AppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays();
            }
        }

        public void AppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureProgrammatic";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        // Checkbox - App permissions - Screenshots And Appss - Command

        private Boolean _chckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays;
        public Boolean ChckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays
        {
            get => _chckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays;
            set
            {
                if (_chckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays == value)
                    return;

                _chckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays = value;
                OnPropertyChanged(nameof(ChckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays));
                AppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays();
            }
        }

        public void AppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureProgrammatic\\NonPackaged";
            string Name = "Value";
            string Type = "REG_SZ";
            string Value = "Deny";
            string Default = "Allow";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxAppPermissionsScreenshotsAndAppsLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }


        #endregion

        #endregion

        #region Windows Update

        // Checkbox - ADVANCED OPTIONS - Receive Updates for other Microsoft products - Command

        private Boolean _chckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts;
        public Boolean ChckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts
        {
            get => _chckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts;
            set
            {
                if (_chckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts == value)
                    return;

                _chckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts = value;
                OnPropertyChanged(nameof(ChckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts));
                WindowsUpdatReceiveUpdatesForOtherMicrosoftProducts();
            }
        }

        public void WindowsUpdatReceiveUpdatesForOtherMicrosoftProducts()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\Services\\7971F918-A847-4430-9279-4A52D1EFE18D";
            string Name = "RegisteredWithAU";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxWindowsUpdateReceiveUpdatesForOtherMicrosoftProducts)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - ADVANCED OPTIONS - Delivery Optimization - Allow downloads from other pc's - Command

        private Boolean _chckbxWindowsUpdateAllowDownloadsFromOtherPCs;
        public Boolean ChckbxWindowsUpdateAllowDownloadsFromOtherPCs
        {
            get => _chckbxWindowsUpdateAllowDownloadsFromOtherPCs;
            set
            {
                if (_chckbxWindowsUpdateAllowDownloadsFromOtherPCs == value)
                    return;

                _chckbxWindowsUpdateAllowDownloadsFromOtherPCs = value;
                OnPropertyChanged(nameof(ChckbxWindowsUpdateAllowDownloadsFromOtherPCs));
                WindowsUpdateAllowDownloadsFromOtherPCs();
            }
        }

        public void WindowsUpdateAllowDownloadsFromOtherPCs()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKU\\S-1-5-20\\Software\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Settings";
            string Name = "DownloadMode";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxWindowsUpdateAllowDownloadsFromOtherPCs)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }
        #endregion



    }
}
