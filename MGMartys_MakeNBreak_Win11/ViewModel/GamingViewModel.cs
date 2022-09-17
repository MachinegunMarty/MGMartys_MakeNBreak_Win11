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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile";
            string Name = @"SystemResponsiveness";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"20";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            

            if (ChckbxSystemResponsivenessChangeSystemResponsiveness)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile";
            string Name = @"NetworkThrottlingIndex";
            string Type = @"DWord";
            string Value = @"4294967295";
            string Default = @"10";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemResponsivenessDisableNetworkThrottling)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"System\\CurrentControlSet\\Control\\Power\\PowerThrottling";
            string Name = @"PowerThrottlingOff";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-Item -Path '" + RegistryPath + "' -Recurse";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemResponsivenessDisablePowerThrottling)
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
            string RegistryHive = @"HKCU:\\";
            string RegistryHiveReg = @"HKCU\\";
            string RegistryPath = @"Software\\Microsoft\\DirectX\\UserGpuPreferences";
            string Name = "DirectXUserGlobalSettings";
            string Type = "String";
            string TypeReg = "REG_SZ";
            string Value = "'VRROptimizeEnable=1;'"; 
            string Default = "'VRROptimizeEnable=0;'";
            string Value2 = "'SwapEffectUpgradeEnable=1'";
            string Default2 = "'SwapEffectUpgradeEnable=0'"; 


            string Exe = "wt.exe";
            string Cmd = "cmd.exe";
            string ArgsNoKey = "powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            //string ArgsValueValue2 = "powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + Value2 + "' -Force";
            //string ArgsValueDefault2 = "powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + Default2 + "' -Force";
            //string ArgsDefaultValue2 = "powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + Value2 + "' -Force";
            //string ArgsDefaultDefault2 = "powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + Default2 + "' -Force";
            // string ArgsValueValue2 = "Reg Add " + RegistryHiveReg + RegistryPath + " /v " + Name + " /t " + TypeReg + " /d " + Value + Value2 + " /f";
            // string ArgsValueDefault2 = "Reg Add " + RegistryHiveReg + RegistryPath + " /v " + Name + " /t " + TypeReg + " /d " + Value + Default2 + " /f";
            // string ArgsDefaultValue2 = "Reg Add " + RegistryHiveReg + RegistryPath + " /v " + Name + " /t " + TypeReg + " /d " + Default + Value2 + " /f";
            // string ArgsDefaultDefault2 = "Reg Add " + RegistryHiveReg + RegistryPath + " /v " + Name + " /t " + TypeReg + " /d " + Default + Default2 + " /f";
            string ArgsValueValue2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d VRROptimizeEnable=1;SwapEffectUpgradeEnable=1; /f";
            string ArgsValueDefault2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d VRROptimizeEnable=1;SwapEffectUpgradeEnable=0; /f";
            string ArgsDefaultValue2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d VRROptimizeEnable=0;SwapEffectUpgradeEnable=1; /f";
            string ArgsDefaultDefault2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d VRROptimizeEnable=0;SwapEffectUpgradeEnable=0; /f";
            //string RegTest = @"/C Reg Add " + RegistryHiveReg + RegistryPath + " /v " + Name + " /t " + TypeReg + " /d " + Value + Value2 + " /f";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);


            if (ChckbxDefaultGraphicsSettingsVariableRefreshRate)
            {
                if (CheckRegKeyCU == null)
                {
                    if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == true)
                    {
                        Process.Start(Exe, ArgsNoKey);
                        Process.Start(Cmd, ArgsValueValue2);
                    }
                    else
                        Process.Start(Exe, ArgsNoKey);
                        Process.Start(Cmd, ArgsValueDefault2);
                }
                else
                    if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == true)
                    {
                        Process.Start(Cmd, ArgsValueValue2);
                    }
                    else
                        Process.Start(Cmd, ArgsValueDefault2);
            }
            else
                if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames == true)
                {
                Process.Start(Cmd, ArgsDefaultValue2);
                }
                else
                Process.Start(Cmd, ArgsDefaultDefault2);
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
            string RegistryHive = "HKCU:\\";
            string RegistryPath = "Software\\Microsoft\\DirectX\\UserGpuPreferences";
            string Name = @"DirectXUserGlobalSettings";
            string Type = @"String";
            string Value = @"SwapEffectUpgradeEnable=1;";
            string Default = @"SwapEffectUpgradeEnable=0;";
            string Value2 = @"VRROptimizeEnable=1;";
            string Default2 = @"VRROptimizeEnable=0;";
            string ValueValue2 = @"SwapEffectUpgradeEnable=1`;VRROptimizeEnable=1";
            string ValueDefault2 = @"SwapEffectUpgradeEnable=1`;VRROptimizeEnable=0";
            string DefaultValue2 = @"SwapEffectUpgradeEnable=0`;VRROptimizeEnable=1";
            string DefaultDefault2 = @"SwapEffectUpgradeEnable=0`;VRROptimizeEnable=0";


            string Exe = "Wt.exe";
            string Cmd = "cmd.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            //string ArgsValueValue2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + ValueValue2 + "' -Force";
            //string ArgsValueDefault2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + ValueDefault2 + "' -Force";
            //string ArgsDefaultValue2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + DefaultValue2 + "' -Force";
            //string ArgsDefaultDefault2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + DefaultDefault2 + "' -Force";
            string ArgsValueValue2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d SwapEffectUpgradeEnable=1;VRROptimizeEnable=1; /f";
            string ArgsValueDefault2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d SwapEffectUpgradeEnable=1;VRROptimizeEnable=0; /f";
            string ArgsDefaultValue2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d SwapEffectUpgradeEnable=0;VRROptimizeEnable=1; /f";
            string ArgsDefaultDefault2 = "/C Reg Add HKCU\\Software\\Microsoft\\DirectX\\UserGpuPreferences /v DirectXUserGlobalSettings /t REG_SZ /d SwapEffectUpgradeEnable=0;VRROptimizeEnable=0; /f";
            //string RegTest = @"/C Reg Add " + RegistryHive + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + Value2 + "/f";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxDefaultGraphicsSettingsOptimizationsForWindowedGames)
            {
                if (CheckRegKeyCU == null)
                {
                    if (ChckbxDefaultGraphicsSettingsVariableRefreshRate == true)
                    {
                        Process.Start(Exe, ArgsNoKey);
                        Process.Start(Cmd, ArgsValueValue2);
                    }
                    else
                        Process.Start(Exe, ArgsNoKey);
                    Process.Start(Cmd, ArgsValueDefault2);
                }
                else
                    if (ChckbxDefaultGraphicsSettingsVariableRefreshRate == true)
                {
                    Process.Start(Cmd, ArgsValueValue2);
                }
                else
                    Process.Start(Cmd, ArgsValueDefault2);
            }
            else
                if (ChckbxDefaultGraphicsSettingsVariableRefreshRate == true)
            {
                Process.Start(Cmd, ArgsDefaultValue2);
            }
            else
                Process.Start(Cmd, ArgsDefaultDefault2);
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers";
            string Name = @"HwSchMode";
            string Type = @"DWord";
            string Value = @"2";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxDefaultGraphicsSettingsHardwareAcceleratedGPUScheduling)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games";
            string Name = @"GPU Priority";
            string Type = @"DWord";
            string Value = @"8";
            string Default = @"8";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxPrioritizeGamingTasksGPUPriority)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games";
            string Name = @"Priority";
            string Type = @"DWord";
            string Value = @"6";
            string Default = @"2";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxPrioritizeGamingTasksGamesPriority)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games";
            string Name = @"Scheduling Category";
            string Type = @"String";
            string Value = @"High";
            string Default = @"Medium";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxPrioritizeGamingTasksSchedulingCategory)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\Multimedia\\SystemProfile\\Tasks\\Games";
            string Name = @"SFIO Priority";
            string Type = @"String";
            string Value = @"High";
            string Default = @"Normal";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            

            if (ChckbxPrioritizeGamingTasksSFIOPriority)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces";
            string Name = @"TCPNoDelay";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxNaglesAlogrithmDisableNagleAlgorithm)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces";
            string Name = @"TcpAckFrequency";
            string Type = @"DWord";
            string Value = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxNaglesAlogrithmSendOutPacketsImmediatly)
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
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Remove-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);

            if (ChckbxNaglesAlogrithmDisablePacketTicks)
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
