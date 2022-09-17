using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PushNotifications";
            string Name = @"ToastEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemNotificationsGetNotificationsFromAppsAndOtherSendersOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = @"NOC_GLOBAL_SETTING_ALLOW_NOTIFICATION_SOUND";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemNotificationsAllowNotificationsToPlaySoundsOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = @"NOC_GLOBAL_SETTING_ALLOW_TOASTS_ABOVE_LOCK";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemNotificationsShowNotificationsOnTheLockScreenOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Notifications\\Settings";
            string Name = @"NOC_GLOBAL_SETTING_ALLOW_CRITICAL_TOASTS_ABOVE_LOCK";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemNotificationsShowRemindersAndIncomingVOIPCallsOnTheLockScreen)
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
            string Exe = "wt.exe";
            string Arguments = @"powershell powercfg /SETDCVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 180";

            if (ChckbxSystemPowerScreenAndSleepOnBatteryPowerTurnOffScreenAfter)
                Process.Start(Exe, Arguments);
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
            string Exe = "wt.exe";
            string Arguments = @"powershell powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0";

            if (ChckbxSystemPowerScreenAndSleepWhenPluggedInTurnOffMyScreenAfter)
                Process.Start(Exe, Arguments);
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
            string Exe = "wt.exe";
            string Arguments = @"powershell powercfg /SETDCVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 180";

            if (ChckbxSystemPowerScreenAndSleepOnBatteryPowerPutMyDeviceToSleepAfter)
                Process.Start(Exe, Arguments);
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
            string Exe = "wt.exe";
            string Arguments = @"powershell powercfg /SETACVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 0";

            if (ChckbxSystemPowerScreenAndSleepWhenPluggedInPutMyDeviceToSleepAfter)
                Process.Start(Exe, Arguments);
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
            string Exe = "wt.exe";
            string Arguments = @"powershell powercfg /setactive 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";

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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\StorageSense\\Parameters\\StoragePolicy";
            string Name = @"01";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemStorageStorageSense)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Control\\Terminal Server";
            string Name = @"fDenyTSConnections";
            string Name2 = @"updateRDStatus";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemRemoteDesktop)
            {
                if (CheckRegKeyLM == null)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\AutoplayHandlers";
            string Name = @"DisableAutoplay";
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxBluetoothAndDevicesAutoplay)
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
            string Exe = "wt.exe";
            string Arguments = @"powershell netsh advfirewall firewall set rule group='Network Discovery' new enable=Yes";

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
            string Exe = "wt.exe";
            string Arguments = @"powershell netsh advfirewall firewall set rule group='File and Printer Sharing' new enable=Yes";

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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string Name = @"EnableTransparency";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationColorsTransparancyEffects)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
            string Name = @"ColorPrevalence";
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationColorsShowAccentColorOnStartAndTaskbar)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\DWM";
            string Name = @"ColorPrevalence";
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationsColorsShowAccentColorOnTitleBarsAndWindowsBorders)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Policies\\Microsoft\\Windows\\Explorer";
            string Name = @"HideRecentlyAddedApps";
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationStartShowRecentlyAddedApps)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
            string Name = @"ShowOrHideMostUsedApps";
            string Type = @"DWord";
            string Value = @"2";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationStartShowMostUsedApps)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"Start_TrackDocs";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationStartShowRecentlyOpenedItemsInJumpList)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search";
            string Name = @"SearchboxTaskbarMode";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideSearch)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            string Name = @"ShowTaskViewButton";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideTaskView)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"TaskbarDa";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideWidgets)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"TaskbarMn";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideChat)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\PenWorkspace";
            string Name = @"PenWorkspaceButtonDesiredVisibility";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHidePenMenu)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\TabletTip\1.7";
            string Name = @"TipbandDesiredVisibility";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideTouchKeyboard)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Touchpad";
            string Name = @"TouchpadDesiredVisibility";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarHideVirtualTouchpad)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
            string Name = @"TaskbarAl";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPersonalizationTaskbarBehaviorsTaskbarAlignment)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\Maps";
            string Name = @"AutoUpdateEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppsOfflineMapsUpdateAutomaticallyWhenPluggedInAndOnWifi)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\GameDVR";
            string Name = @"HistoricalCaptureEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxGamingCapturesWhenSomethingCoolHappenedInYourGame)
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

        #endregion

        #region Privacy & Security

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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\International\\User Profile";
            string Name = @"HttpAcceptLanguageOptOut";
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecurityGeneralLetWebsitesShowMeLocallyRelevantContentByAccessingMyLanguageList)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"Start_TrackProgs";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecurityGeneralLetWindowsImproveStartAndSearchResultsByTrackingAppLaunches)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager";
            string Name = @"SubscribedContent-338393Enabled";
            string Name2 = @"SubscribedContent-353694Enabled";
            string Name3 = @"SubscribedContent-353696Enabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name3 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name3 + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecurityGeneralShowMeSuggestedContentInTheSettingsApp)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                    Process.Start(Exe, ArgsChecked2);
                    Process.Start(Exe, ArgsChecked3);
                }
                else
                    Process.Start(Exe, ArgsChecked);
                Process.Start(Exe, ArgsChecked2);
                Process.Start(Exe, ArgsChecked3);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
            Process.Start(Exe, ArgsUnchecked2);
            Process.Start(Exe, ArgsUnchecked3);
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CPSS\\Store\\InkingAndTypingPersonalization";
            string RegistryPath2 = @"Software\\Microsoft\\Personalization\\Settings";
            string RegistryPath3 = @"Software\\Microsoft\\InputPersonalization";
            string RegistryPath4 = @"Software\\Microsoft\\InputPersonalization\\TrainedDataStore";
            string Name = @"Value";
            string Name2 = @"AcceptedPrivacyPolicy";
            string Name3 = @"RestrictImplicitTextCollection";
            string Name4 = @"RestrictImplicitInkCollection";
            string Name5 = @"HarvestContacts";
            string Type = @"DWord";
            string Value = @"0";
            string Value2 = @"1";
            string Default = @"1";
            string Default2 = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name3 + "' -Type '" + Type + "' -Value '" + Value2 + "' -Force";
            string ArgsChecked4 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name4 + "' -Type '" + Type + "' -Value '" + Value2 + "' -Force";
            string ArgsChecked5 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name5 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name3 + "' -Type '" + Type + "' -Value '" + Default2 + "' -Force";
            string ArgsUnchecked4 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name4 + "' -Type '" + Type + "' -Value '" + Default2 + "' -Force";
            string ArgsUnchecked5 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name5 + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecurityInkingAndTypeingPersonalizationPersonalInkingAndTypingDictionary)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Policies\\Microsoft\\Windows\\System";
            string Name = @"PublishUserActivities";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecurityActivityHistoryStoreMyActivationHistoryOnThisDevice)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = @"SafeSearchMode";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecuritySearchPermissionsTurnSafeSearchOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = @"IsMSACloudSearchEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchMicrosoftAccount)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = @"IsAADCloudSearchEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecuritySearchPermissionsCloudContentSearchWorkOrSchoolAccount)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\SearchSettings";
            string Name = @"IsDeviceSearchHistoryEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecuritySearchPermissionsHistorySearchHistoryOnThisDevice)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings";
            string Name = @"IsDynamicSearchBoxEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPrivacyAndSecuritySearchPermissionsMoreSettingsShowSearchHighlights)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps";
            string Name = @"AgentActivationEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsVoiceActivationLetAppsAccesVoiceActivationServicesOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Speech_OneCore\\Settings\\VoiceActivation\\UserPreferenceForAllApps";
            string Name = @"AgentActivationOnLockScreenEnabled";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsVoiceActivationLetAppsUseVoiceActivationWhenDeviceIsLockedOff)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userNotificationListener";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsNotificationsLetAppsAccesYourNotifications)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userAccountInformation";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsAccountInfoLetAppsAccesYourAccountInfo)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\contacts";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsContactsLetAppsAccesYourContacts)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appointments";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsCalendarLetAppsAccesYourCalendar)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCall";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsPhoneCallsLetAppsMakePhoneCalls)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\phoneCallHistory";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsCallHistoryLetAppsAccesYourCallHistory)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\email";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsEmailLetAppsAccesYourEmail)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\userDataTasks";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsTasksLetAppsAccesYourTasks)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\chat";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsMessagingLetAppsReadYourMessages)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\radios";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsRadiosLetAppsControlDeviceRadios)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\bluetoothSync";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsOtherDevicesCommunicateWithUnpairedDevices)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsAppDiagnosticsAllowAppsToAccesDiagnosticsInfoAboutYourOtherApps)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\documentsLibrary";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsDocumentsAllowAppsToAccesYourDocumentsLibrary)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\downloadsFolder";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsDownloadsFolderAllowAppsToAccesYourDownloadsFolder)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\musicLibrary";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsMusicLibraryAllowAppsToAccesYourMusicLibrary)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\picturesLibrary";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsPicturesAllowAppsToAccesYourPicturesLibrary)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\videosLibrary";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsVideosAllowAppsToAccesYourVideosLibrary)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\broadFileSystemAccess";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsFileSystemLetAppsAccesYourFileSystem)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureWithoutBorder";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsScreenshotBordersLetAppsTurnOffTheScreenshotBorder)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureWithoutBorder\\NonPackaged";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsScreenshotBordersLetDesktopAppsTakeScreenshotsOfVariousWindowsAndDisplays)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureProgrammatic";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\graphicsCaptureProgrammatic\\NonPackaged";
            string Name = @"Value";
            string Type = @"String";
            string Value = @"Deny";
            string Default = @"Allow";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxAppPermissionsScreenshotsAndAppsLetAppsTakeScreenshotsOfVariousWindowsAndDisplays)
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

        #endregion

        #region Windows Update

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
            string RegistryHive = @"HKU:\\";
            string RegistryPath = @"S-1-5-20\\Software\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Settings";
            string Name = @"DownloadMode";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"reg add HKU\S-1-5-20\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Settings /v DownloadMode /t REG_DWORD /d 0 /f";
            string ArgsUnchecked = @"reg add HKU\S-1-5-20\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Settings /v DownloadMode /t REG_DWORD /d 1 /f";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            RegistryKey RegKeyU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.Users, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);
            var CheckRegKeyU = RegKeyU.OpenSubKey(RegistryPath, true);


            if (ChckbxWindowsUpdateAllowDownloadsFromOtherPCs)
            {
                if (CheckRegKeyU == null)
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
