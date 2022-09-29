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
    public class GamingViewModel
    {

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region System Responsiveness

        // Checkbox - Change System Responsiveness - Command

        private Boolean _chckbxSystemResponsivenessChangeSystemResponsiveness;
        public Boolean ChckbxSystemResponsivenessChangeSystemResponsiveness
        {
            get => _chckbxSystemResponsivenessChangeSystemResponsiveness;
            set
            {
                if (_chckbxSystemResponsivenessChangeSystemResponsiveness == value)
                    return;

                _chckbxSystemResponsivenessChangeSystemResponsiveness = value;
                OnPropertyChanged(nameof(ChckbxSystemResponsivenessChangeSystemResponsiveness));
                SystemResponsivenessSearchOnInternetContextMenu();
            }
        }

        public void SystemResponsivenessSearchOnInternetContextMenu()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\"";
            string Name = "SystemResponsiveness";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "20";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemResponsivenessChangeSystemResponsiveness)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Disable 'Network Throttling' - Command

        private Boolean _chckbxSystemResponsivenessDisableNetworkThrottling;
        public Boolean ChckbxSystemResponsivenessDisableNetworkThrottling
        {
            get => _chckbxSystemResponsivenessDisableNetworkThrottling;
            set
            {
                if (_chckbxSystemResponsivenessDisableNetworkThrottling == value)
                    return;

                _chckbxSystemResponsivenessDisableNetworkThrottling = value;
                OnPropertyChanged(nameof(ChckbxSystemResponsivenessDisableNetworkThrottling));
                SystemResponsivenessDisableNetworkThrottling();
            }
        }

        public void SystemResponsivenessDisableNetworkThrottling()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\"";
            string Name = "NetworkThrottlingIndex";
            string Type = "REG_DWORD";
            string Value = "4294967295";
            string Default = "10";

            string ArgsChecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemResponsivenessDisableNetworkThrottling)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Disable 'Power Throttling' - Command

        private Boolean _chckbxSystemResponsivenessDisablePowerThrottling;
        public Boolean ChckbxSystemResponsivenessDisablePowerThrottling
        {
            get => _chckbxSystemResponsivenessDisablePowerThrottling;
            set
            {
                if (_chckbxSystemResponsivenessDisablePowerThrottling == value)
                    return;

                _chckbxSystemResponsivenessDisablePowerThrottling = value;
                OnPropertyChanged(nameof(ChckbxSystemResponsivenessDisablePowerThrottling));
                SystemResponsivenessDisablePowerThrottling();
            }
        }

        public void SystemResponsivenessDisablePowerThrottling()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\System\\CurrentControlSet\\Control\\Power\\PowerThrottling";
            string Name = "PowerThrottlingOff";
            string Type = "REG_DWORD";
            string Value = "1";


            string ArgsChecked = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsUnchecked = "/C Reg delete " + RegistryPath + " /f";

            if (ChckbxSystemResponsivenessDisablePowerThrottling)
                Process.Start(Exe, ArgsChecked);
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Default Graphics Settings



        // Checkbox - Turn On - 'Variable Refresh Rate' - Command

        private Boolean _chckbxDefaultGraphicsSettingsVariableRefreshRate;
        public Boolean ChckbxDefaultGraphicsSettingsVariableRefreshRate
        {
            get => _chckbxDefaultGraphicsSettingsVariableRefreshRate;
            set
            {
                if (_chckbxDefaultGraphicsSettingsVariableRefreshRate == value)
                    return;

                _chckbxDefaultGraphicsSettingsVariableRefreshRate = value;
                OnPropertyChanged(nameof(ChckbxDefaultGraphicsSettingsVariableRefreshRate));
                DefaultGraphicsSettingsVariableRefreshRate();
            }
        }

        public void DefaultGraphicsSettingsVariableRefreshRate()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences";
            string Name = "DirectXUserGlobalSettings";
            string Type = "REG_SZ";
            string Value = "VRROptimizeEnable=1;";
            string Default = "VRROptimizeEnable=0;";
            string Value2 = "SwapEffectUpgradeEnable=1;";
            string Default2 = "SwapEffectUpgradeEnable=0;";

            string ArgsValueValue2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + Value2 + " /f";
            string ArgsValueDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + Default2 + " /f";
            string ArgsDefaultValue2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + Value2 + " /f";
            string ArgsDefaultDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + Default2 + " /f";

            if (ChckbxDefaultGraphicsSettingsVariableRefreshRate)
            {
                    if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == true)
                    {
                        Process.Start(Exe, ArgsValueValue2);
                    }
                    else
                        Process.Start(Exe, ArgsValueDefault2);
            }
            else
                if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == true)
                {
                Process.Start(Exe, ArgsDefaultValue2);
                }
                else
                Process.Start(Exe, ArgsDefaultDefault2);
        }


       



        // Checkbox - Turn On - 'Optimizations for windowed games' - Command

        private Boolean _chckbxDefaultGraphicsSettingsOptimizationsForWindowedGames;
        public Boolean ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames
        {
            get => _chckbxDefaultGraphicsSettingsOptimizationsForWindowedGames;
            set
            {
                if (_chckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == value)
                    return;

                _chckbxDefaultGraphicsSettingsOptimizationsForWindowedGames = value;
                OnPropertyChanged(nameof(ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames));
                DefaultGraphicsSettingsOptimizationsForWindowedGames();
            }
        }

        public void DefaultGraphicsSettingsOptimizationsForWindowedGames()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences";
            string Name = "DirectXUserGlobalSettings";
            string Type = "REG_SZ";
            string Value = "SwapEffectUpgradeEnable=1;";
            string Default = "SwapEffectUpgradeEnable=0;";
            string Value2 = "VRROptimizeEnable=1;";
            string Default2 = "VRROptimizeEnable=0;";

            string ArgsValueValue2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + Value2 + " /f";
            string ArgsValueDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + Default2 + " /f";
            string ArgsDefaultValue2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + Value2 + " /f";
            string ArgsDefaultDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + Default2 + " /f";

            if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames)
            {
                if (ChckbxDefaultGraphicsSettingsVariableRefreshRate == true)
                {
                    Process.Start(Exe, ArgsValueValue2);
                }
                else
                    Process.Start(Exe, ArgsValueDefault2);
            }
            else
                if (ChckbxDefaultGraphicsSettingsVariableRefreshRate == true)
            {
                Process.Start(Exe, ArgsDefaultValue2);
            }
            else
                Process.Start(Exe, ArgsDefaultDefault2);
        }





        // Checkbox - Turn On - 'Hardware-accelerated GPU scheduling' - Command

        private Boolean _chckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling;
        public Boolean ChckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling
        {
            get => _chckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling;
            set
            {
                if (_chckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling == value)
                    return;

                _chckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling = value;
                OnPropertyChanged(nameof(ChckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling));
                DefaultGraphicsSettingsHardwareAcceleratedGPUScheduling();
            }
        }

        public void DefaultGraphicsSettingsHardwareAcceleratedGPUScheduling()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers";
            string Name = "HwSchMode";
            string Type = "REG_DWORD";
            string Value = "2";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling)
            {
                Process.Start(Exe, ArgsValue);
            }
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion

        #region Prioritize Gaming Tasks



        // Checkbox - Set 'GPU Priority' - Command

        private Boolean _chckbxPrioritizeGamingTasksGPUPriority;
        public Boolean ChckbxPrioritizeGamingTasksGPUPriority
        {
            get => _chckbxPrioritizeGamingTasksGPUPriority;
            set
            {
                if (_chckbxPrioritizeGamingTasksGPUPriority == value)
                    return;

                _chckbxPrioritizeGamingTasksGPUPriority = value;
                OnPropertyChanged(nameof(ChckbxPrioritizeGamingTasksGPUPriority));
                PrioritizeGamingTasksGPUPriority();
            }
        }

        public void PrioritizeGamingTasksGPUPriority()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\"";
            string Name = "\"GPU Priority\"";
            string Type = "REG_DWORD";
            string Value = "8";
            string Default = "8";

            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrioritizeGamingTasksGPUPriority)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Set 'Games Priority' - Command

        private Boolean _chckbxPrioritizeGamingTasksGamesPriority;
        public Boolean ChckbxPrioritizeGamingTasksGamesPriority
        {
            get => _chckbxPrioritizeGamingTasksGamesPriority;
            set
            {
                if (_chckbxPrioritizeGamingTasksGamesPriority == value)
                    return;

                _chckbxPrioritizeGamingTasksGamesPriority = value;
                OnPropertyChanged(nameof(ChckbxPrioritizeGamingTasksGamesPriority));
                PrioritizeGamingTasksGamesPriority();
            }
        }

        public void PrioritizeGamingTasksGamesPriority()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\"";
            string Name = "Priority";
            string Type = "REG_DWORD";
            string Value = "6";
            string Default = "2";
            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrioritizeGamingTasksGamesPriority)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Set 'Scheduling Category' - Command

        private Boolean _chckbxPrioritizeGamingTasksSchedulingCategory;
        public Boolean ChckbxPrioritizeGamingTasksSchedulingCategory
        {
            get => _chckbxPrioritizeGamingTasksSchedulingCategory;
            set
            {
                if (_chckbxPrioritizeGamingTasksSchedulingCategory == value)
                    return;

                _chckbxPrioritizeGamingTasksSchedulingCategory = value;
                OnPropertyChanged(nameof(ChckbxPrioritizeGamingTasksSchedulingCategory));
                PrioritizeGamingTasksSchedulingCategory();
            }
        }

        public void PrioritizeGamingTasksSchedulingCategory()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\"";
            string Name = "\"Scheduling Category\"";
            string Type = "REG_SZ";
            string Value = "High";
            string Default = "Medium";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrioritizeGamingTasksSchedulingCategory)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Set 'SFIO Priority' - Command

        private Boolean _chckbxPrioritizeGamingTasksSFIOPriority;
        public Boolean ChckbxPrioritizeGamingTasksSFIOPriority
        {
            get => _chckbxPrioritizeGamingTasksSFIOPriority;
            set
            {
                if (_chckbxPrioritizeGamingTasksSFIOPriority == value)
                    return;

                _chckbxPrioritizeGamingTasksSFIOPriority = value;
                OnPropertyChanged(nameof(ChckbxPrioritizeGamingTasksSFIOPriority));
                PrioritizeGamingTasksSFIOPriority();
            }
        }

        public void PrioritizeGamingTasksSFIOPriority()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games\"";
            string Name = "\"SFIO Priority\"";
            string Type = "REG_SZ";
            string Value = "High";
            string Default = "Normal";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPrioritizeGamingTasksSFIOPriority)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        #endregion

        #region Nagle's Alogrithm



        // Checkbox - Disable 'Nagle-Algorithm' - Command

        private Boolean _chckbxNaglesAlogrithmDisableNagleAlgorithm;
        public Boolean ChckbxNaglesAlogrithmDisableNagleAlgorithm
        {
            get => _chckbxNaglesAlogrithmDisableNagleAlgorithm;
            set
            {
                if (_chckbxNaglesAlogrithmDisableNagleAlgorithm == value)
                    return;

                _chckbxNaglesAlogrithmDisableNagleAlgorithm = value;
                OnPropertyChanged(nameof(ChckbxNaglesAlogrithmDisableNagleAlgorithm));
                NaglesAlogrithmDisableNagleAlgorithm();
            }
        }

        public void NaglesAlogrithmDisableNagleAlgorithm()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces";
            string Name = "TCPNoDelay";
            string Type = "REG_DWORD";
            string Value = "1";

            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxNaglesAlogrithmDisableNagleAlgorithm)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Send out packets immediatly - Command

        private Boolean _chckbxNaglesAlogrithmSendOutPacketsImmediatly;
        public Boolean ChckbxNaglesAlogrithmSendOutPacketsImmediatly
        {
            get => _chckbxNaglesAlogrithmSendOutPacketsImmediatly;
            set
            {
                if (_chckbxNaglesAlogrithmSendOutPacketsImmediatly == value)
                    return;

                _chckbxNaglesAlogrithmSendOutPacketsImmediatly = value;
                OnPropertyChanged(nameof(ChckbxNaglesAlogrithmSendOutPacketsImmediatly));
                NaglesAlogrithmSendOutPacketsImmediatly();
            }
        }

        public void NaglesAlogrithmSendOutPacketsImmediatly()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces";
            string Name = @"TcpAckFrequency";
            string Type = @"REG_DWORD";
            string Value = @"1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg delete " + RegistryPath + " /v " + Name + " /f";

            if (ChckbxNaglesAlogrithmSendOutPacketsImmediatly)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }



        // Checkbox - Disable Packet Ticks - Command

        private Boolean _chckbxNaglesAlogrithmDisablePacketTicks;
        public Boolean ChckbxNaglesAlogrithmDisablePacketTicks
        {
            get => _chckbxNaglesAlogrithmDisablePacketTicks;
            set
            {
                if (_chckbxNaglesAlogrithmDisablePacketTicks == value)
                    return;

                _chckbxNaglesAlogrithmDisablePacketTicks = value;
                OnPropertyChanged(nameof(ChckbxNaglesAlogrithmDisablePacketTicks));
                NaglesAlogrithmDisablePacketTicks();
            }
        }

        public void NaglesAlogrithmDisablePacketTicks()
        {
            string Exe = "cmd.exe";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxNaglesAlogrithmDisablePacketTicks)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
        }

        #endregion


    }
}
