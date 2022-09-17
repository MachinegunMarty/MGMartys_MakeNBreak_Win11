using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;
using MGMartys_MakeNBreak_Win11.Model;
using MGMartys_MakeNBreak_Win11.Utilities;
using Microsoft.Win32;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class ControlPanelViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region Ease of Acces Center

        #region Make the computer easier to Use

        // Checkbox - Disable 'Always read this section aloud'  - Command

        private Boolean _chckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud;
        public Boolean ChckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud
        {
            get => _chckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud;
            set
            {
                if (_chckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud == value)
                    return;

                _chckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud));
                MakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud();
            }
        }

        public void MakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Ease of Access";
            string Name = @"selfvoice";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud)
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

        // Checkbox - Disable 'Always scan this section' - Command

        private Boolean _chckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection;
        public Boolean ChckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection
        {
            get => _chckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection;
            set
            {
                if (_chckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection == value)
                    return;

                _chckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection));
                MakeTheComputerEasierToUseDisableAlwaysScanThisSection();
            }
        }

        public void MakeTheComputerEasierToUseDisableAlwaysScanThisSection()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Ease of Access";
            string Name = @"selfscan";
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

            if (ChckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection)
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

        #region Make the computer easier to See

        // Checkbox - Turn Off 'High Contrast when left ALT + left SHIFT + PRINT SCREEN is pressed - Command

        private Boolean _chckbxMakeTheComputerEasierToSeeTurnOffHighContrast;
        public Boolean ChckbxMakeTheComputerEasierToSeeTurnOffHighContrast
        {
            get => _chckbxMakeTheComputerEasierToSeeTurnOffHighContrast;
            set
            {
                if (_chckbxMakeTheComputerEasierToSeeTurnOffHighContrast == value)
                    return;

                _chckbxMakeTheComputerEasierToSeeTurnOffHighContrast = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToSeeTurnOffHighContrast));
                MakeTheComputerEasierToSeeTurnOffHighContrast();
            }
        }

        public void MakeTheComputerEasierToSeeTurnOffHighContrast()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Accessibility\\HighContrast";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"4194";
            string Default = @"4198";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheComputerEasierToSeeTurnOffHighContrast)
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


        // Checkbox - Disable 'Display a Warning Message When Turning A Setting On' - Command

        private Boolean _chckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn;
        public Boolean ChckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn
        {
            get => _chckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn;
            set
            {
                if (_chckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn == value)
                    return;

                _chckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn));
                MakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn();
            }
        }

        public void MakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Accessibility";
            string Name = @"Warning Sounds";
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

            if (ChckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn)
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



        // Checkbox - Disable 'Make A Sound When Turning A Setting On or Off' - Command

        private Boolean _chckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff;
        public Boolean ChckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff
        {
            get => _chckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff;
            set
            {
                if (_chckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff == value)
                    return;

                _chckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff));
                MakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff();
            }
        }

        public void MakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Accessibility";
            string Name = @"Sound on Activation";
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

            if (ChckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff)
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


        // Checkbox - Turn off all unneccassary animations (when possible) - Command

        private Boolean _chckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations;
        public Boolean ChckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations
        {
            get => _chckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations;
            set
            {
                if (_chckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations == value)
                    return;

                _chckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations = value;
                OnPropertyChanged(nameof(ChckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations));
                MakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations();
            }
        }

        public void MakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop\\WindowMetrics";
            string Name = @"MinAnimate";
            string Type = @"String";
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

            if (ChckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations)
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

        #region Make The Keyboard easier to Use



        // Checkbox - Set up mouse keys - Turn All Off - Command

        private Boolean _chckbxMakeTheKeyboardEasierToUseSetUpMouseKeys;
        public Boolean ChckbxMakeTheKeyboardEasierToUseSetUpMouseKeys
        {
            get => _chckbxMakeTheKeyboardEasierToUseSetUpMouseKeys;
            set
            {
                if (_chckbxMakeTheKeyboardEasierToUseSetUpMouseKeys == value)
                    return;

                _chckbxMakeTheKeyboardEasierToUseSetUpMouseKeys = value;
                OnPropertyChanged(nameof(ChckbxMakeTheKeyboardEasierToUseSetUpMouseKeys));
                MakeTheKeyboardEasierToUseSetUpMouseKeys();
            }
        }

        public void MakeTheKeyboardEasierToUseSetUpMouseKeys()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\MouseKeys";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"130";
            string Default = @"131";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheKeyboardEasierToUseSetUpMouseKeys)
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



        // Checkbox - Set up Sticky keys - Turn All Off - Command

        private Boolean _chckbxMakeTheKeyboardEasierToUseSetUpStickyKeys;
        public Boolean ChckbxMakeTheKeyboardEasierToUseSetUpStickyKeys
        {
            get => _chckbxMakeTheKeyboardEasierToUseSetUpStickyKeys;
            set
            {
                if (_chckbxMakeTheKeyboardEasierToUseSetUpStickyKeys == value)
                    return;

                _chckbxMakeTheKeyboardEasierToUseSetUpStickyKeys = value;
                OnPropertyChanged(nameof(ChckbxMakeTheKeyboardEasierToUseSetUpStickyKeys));
                MakeTheKeyboardEasierToUseSetUpStickyKeys();
            }
        }

        public void MakeTheKeyboardEasierToUseSetUpStickyKeys()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\StickyKeys";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"2";
            string Default = @"3";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheKeyboardEasierToUseSetUpStickyKeys)
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



        // Checkbox - Disable 'Turn on Toggle Keys by holding down the NUM-LOCK key for 5 Seconds' - Command

        private Boolean _chckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock;
        public Boolean ChckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock
        {
            get => _chckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock;
            set
            {
                if (_chckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock == value)
                    return;

                _chckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock = value;
                OnPropertyChanged(nameof(ChckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock));
                MakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock();
            }
        }

        public void MakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\ToggleKeys";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"34";
            string Default = @"35";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock)
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



        // Checkbox - Set up Filter keys - Turn All Off - Command

        private Boolean _chckbxMakeTheKeyboardEasierToUseSetUpFilterKeys;
        public Boolean ChckbxMakeTheKeyboardEasierToUseSetUpFilterKeys
        {
            get => _chckbxMakeTheKeyboardEasierToUseSetUpFilterKeys;
            set
            {
                if (_chckbxMakeTheKeyboardEasierToUseSetUpFilterKeys == value)
                    return;

                _chckbxMakeTheKeyboardEasierToUseSetUpFilterKeys = value;
                OnPropertyChanged(nameof(ChckbxMakeTheKeyboardEasierToUseSetUpFilterKeys));
                MakeTheKeyboardEasierToUseSetUpFilterKeys();
            }
        }

        public void MakeTheKeyboardEasierToUseSetUpFilterKeys()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\StickyKeys";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"102";
            string Default = @"103";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTheKeyboardEasierToUseSetUpFilterKeys)
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

        #region Use text or visual alternatives for sound

        // Checkbox - Disable 'Turn on visual notifcations for sounds (Sound Sentry)' - Command

        private Boolean _chckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds;
        public Boolean ChckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds
        {
            get => _chckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds;
            set
            {
                if (_chckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds == value)
                    return;

                _chckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds = value;
                OnPropertyChanged(nameof(ChckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds));
                UseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds();
            }
        }

        public void UseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\SoundSentry";
            string Name = @"Flags";
            string Type = @"String";
            string Value = @"2";
            string Default = @"3";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds)
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



        // Checkbox - Choose visual warning - None - Command

        private Boolean _chckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning;
        public Boolean ChckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning
        {
            get => _chckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning;
            set
            {
                if (_chckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning == value)
                    return;

                _chckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning = value;
                OnPropertyChanged(nameof(ChckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning));
                UseTextOrVisualAlternativesForSoundChooseVisualWarning();
            }
        }

        public void UseTextOrVisualAlternativesForSoundChooseVisualWarning()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Accessibility\\SoundSentry";
            string Name = @"WindowsEffect";
            string Type = @"String";
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

            if (ChckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning)
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

        #region Make Touch and Tablets Easier to Use



        // Checkbox - Launching common tools - None - Command

        private Boolean _chckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools;
        public Boolean ChckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools
        {
            get => _chckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools;
            set
            {
                if (_chckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools == value)
                    return;

                _chckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools = value;
                OnPropertyChanged(nameof(ChckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools));
                MakeTouchAndTabletsEasierToUseLaunchingCommonTools();
            }
        }

        public void MakeTouchAndTabletsEasierToUseLaunchingCommonTools()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Accessibility\SlateLaunch";
            string Name = @"LaunchAT";
            string Name2 = @"ATapp";
            string Type = @"DWord";
            string Type2 = @"String";
            string Value = @"0";
            string Default = @"1";
            string Value2 = @" ";
            string Default2 = @"narrator";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type2 + "' -Value ' ' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type2 + "' -Value '" + Default2 + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools)
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

        #endregion

        #endregion

        #region File Explorer Options

        #region General

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
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
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
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
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
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
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
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = @"ShowCloudFilesInQuickAccess";
            string Checked = @"0";
            string Unchecked = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path " + RegistryHive + RegistryPath + " -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Checked + " -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path " + RegistryHive + RegistryPath + " -Name " + Name + " -Value " + Unchecked + " -Force";
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
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

        #endregion

        #region View

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
            string Type = @"DWord";
            string Value = @"1";
            string Default = @"2";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
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

        #region Search



        // Checkbox - Don't use the index when searching in file folders for system files - Command

        private Boolean _chckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem;
        public Boolean ChckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem
        {
            get => _chckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem;
            set
            {
                if (_chckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem == value)
                    return;

                _chckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem = value;
                OnPropertyChanged(nameof(ChckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem));
                SearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem();
            }
        }

        public void SearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Search\Preferences";
            string Name = @"WholeFileSystem";
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

            if (ChckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem)
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

        #region Mouse


        // Checkbox - Disable 'Enhance Pointer Precision' - Command

        private Boolean _chckbxMouseDisableEnhancedPointerPrecision;
        public Boolean ChckbxMouseDisableEnhancedPointerPrecision
        {
            get => _chckbxMouseDisableEnhancedPointerPrecision;
            set
            {
                if (_chckbxMouseDisableEnhancedPointerPrecision == value)
                    return;

                _chckbxMouseDisableEnhancedPointerPrecision = value;
                OnPropertyChanged(nameof(ChckbxMouseDisableEnhancedPointerPrecision));
                MouseDisableEnhancedPointerPrecision();
            }
        }

        public void MouseDisableEnhancedPointerPrecision()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Mouse";
            string Name = @"MouseThreshold1";
            string Name2 = @"MouseThreshold2";
            string Name3 = @"MouseSpeed";
            string Type = @"String";
            string Value = @"0";
            string Default = @"6";
            string Default2 = @"10";
            string Default3 = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name3 + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default2 + "' -Force";
            string ArgsUnchecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default3 + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMouseDisableEnhancedPointerPrecision)
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



        // Checkbox - Disable 'Mouse Smoothing and Acceleration' - Command

        private Boolean _chckbxMouseDisableMouseSmoothingAndAccelaration;
        public Boolean ChckbxMouseDisableMouseSmoothingAndAccelaration
        {
            get => _chckbxMouseDisableMouseSmoothingAndAccelaration;
            set
            {
                if (_chckbxMouseDisableMouseSmoothingAndAccelaration == value)
                    return;

                _chckbxMouseDisableMouseSmoothingAndAccelaration = value;
                OnPropertyChanged(nameof(ChckbxMouseDisableMouseSmoothingAndAccelaration));
                MouseDisableMouseSmoothingAndAccelaration();
            }
        }

        public void MouseDisableMouseSmoothingAndAccelaration()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Mouse";
            string Name = @"MouseSensitivity";
            string Name2 = @"SmoothMouseXCurve";
            string Name3 = @"SmoothMouseYCurve";
            string Type = @"String";
            string Type2 = @"Binary";
            string Value = @"10";
            string Value2 = "([byte[]](0x00,0x00,0x00,0x00, 0x00,0x00,0x00,0x00,0xC0,0xCC,0x0C,0x00,0x00,0x00,0x00,0x00,0x80,0x99,0x19,0x00,0x00,0x00,0x00,0x00,0x40,0x66,0x26,0x00,0x00,0x00,0x00,0x00,0x00,0x33,0x33,0x00,0x00,0x00,0x00,0x00))";
            string Value3 = "([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x38,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xA8,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xE0,0x00,0x00,0x00,0x00,0x00))";
            string Default = @"10";
            string Default2 = @"([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x15,0x6e,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x40,0x01,0x00,0x00,0x00,0x00,0x00,0x29,0xdc,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x00,0x00))";
            string Default3 = @"([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xfd,0x11,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x24,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0xfc,0x12,0x00,0x00,0x00,0x00,0x00,0x00,0xc0,0xbb,0x01,0x00,0x00,0x00,0x00))";


            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type2 + "' -Value ([byte[]](0x00,0x00,0x00,0x00, 0x00,0x00,0x00,0x00,0xC0,0xCC,0x0C,0x00,0x00,0x00,0x00,0x00,0x80,0x99,0x19,0x00,0x00,0x00,0x00,0x00,0x40,0x66,0x26,0x00,0x00,0x00,0x00,0x00,0x00,0x33,0x33,0x00,0x00,0x00,0x00,0x00)) -Force";
            string ArgsChecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name3 + "' -Type '" + Type2 + "' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x38,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x70,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xA8,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xE0,0x00,0x00,0x00,0x00,0x00)) -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name2 + "' -Type '" + Type2 + "' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x15,0x6e,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x40,0x01,0x00,0x00,0x00,0x00,0x00,0x29,0xdc,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x00,0x00)) -Force";
            string ArgsUnchecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name3 + "' -Type '" + Type2 + "' -Value ([byte[]](0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xfd,0x11,0x01,0x00,0x00,0x00,0x00,0x00,0x00,0x24,0x04,0x00,0x00,0x00,0x00,0x00,0x00,0xfc,0x12,0x00,0x00,0x00,0x00,0x00,0x00,0xc0,0xbb,0x01,0x00,0x00,0x00,0x00)) -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMouseDisableMouseSmoothingAndAccelaration)
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



        // Checkbox - Show popups faster when hovering over an item - Command

        private Boolean _chckbxMouseShowPopupsFasterWhenHoveringOverAnItem;
        public Boolean ChckbxMouseShowPopupsFasterWhenHoveringOverAnItem
        {
            get => _chckbxMouseShowPopupsFasterWhenHoveringOverAnItem;
            set
            {
                if (_chckbxMouseShowPopupsFasterWhenHoveringOverAnItem == value)
                    return;

                _chckbxMouseShowPopupsFasterWhenHoveringOverAnItem = value;
                OnPropertyChanged(nameof(ChckbxMouseShowPopupsFasterWhenHoveringOverAnItem));
                MouseShowPopupsFasterWhenHoveringOverAnItem();
            }
        }

        public void MouseShowPopupsFasterWhenHoveringOverAnItem()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\Mouse";
            string Name = @"MouseHoverTime";
            string Type = @"String";
            string Value = @"8";
            string Default = @"400";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxMouseShowPopupsFasterWhenHoveringOverAnItem)
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

        #region Power Options

        #region Choose a Power Plan


        // Checkbox - Change 'Power Plan' to 'Ultimate Performance' - Command

        private Boolean _chckbxPowerOptionsChangePowerPlanToUltimatePerformance;
        public Boolean ChckbxPowerOptionsChangePowerPlanToUltimatePerformance
        {
            get => _chckbxPowerOptionsChangePowerPlanToUltimatePerformance;
            set
            {
                if (_chckbxPowerOptionsChangePowerPlanToUltimatePerformance == value)
                    return;

                _chckbxPowerOptionsChangePowerPlanToUltimatePerformance = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsChangePowerPlanToUltimatePerformance));
                PowerOptionsChangePowerPlanToUltimatePerformance();
            }
        }

        public void PowerOptionsChangePowerPlanToUltimatePerformance()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg  /setactive 'e9a42b02-d5df-448d-aa00-03f14749eb61'";
            string ArgsUnchecked = @"powershell powercfg  /setactive '381b4222-f694-41f0-9685-ff5bb260df2e'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionsChangePowerPlanToUltimatePerformance)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        #endregion

        #region System Settings

        // Checkbox - Disable 'Fast Startup' - Command

        private Boolean _chckbxPowerOptionsDisableFastStartup;
        public Boolean ChckbxPowerOptionsDisableFastStartup
        {
            get => _chckbxPowerOptionsDisableFastStartup;
            set
            {
                if (_chckbxPowerOptionsDisableFastStartup == value)
                    return;

                _chckbxPowerOptionsDisableFastStartup = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsDisableFastStartup));
                PowerOptionsDisableFastStartup();
            }
        }

        public void PowerOptionsDisableFastStartup()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power";
            string Name = @"HiberbootEnabled";
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

            if (ChckbxPowerOptionsDisableFastStartup)
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

        #region Advanced Power Settings



        // Checkbox - Hard disk - Turn off hard disk after - Never - Command

        private Boolean _chckbxPowerOptionsTurnOffHardDiskAfterNever;
        public Boolean ChckbxPowerOptionsTurnOffHardDiskAfterNever
        {
            get => _chckbxPowerOptionsTurnOffHardDiskAfterNever;
            set
            {
                if (_chckbxPowerOptionsTurnOffHardDiskAfterNever == value)
                    return;

                _chckbxPowerOptionsTurnOffHardDiskAfterNever = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsTurnOffHardDiskAfterNever));
                PowerOptionsTurnOffHardDiskAfterNever();
            }
        }

        public void PowerOptionsTurnOffHardDiskAfterNever()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '0012ee47-9041-4b5d-9b77-535fba8b1442' '6738e2c4-e8a5-4a42-b16a-e040e769756e' '0'";
            string ArgsUnchecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '0012ee47-9041-4b5d-9b77-535fba8b1442' '6738e2c4-e8a5-4a42-b16a-e040e769756e' '900'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionsTurnOffHardDiskAfterNever)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Sleep - Put the computer to sleep after - Never - Command

        private Boolean _chckbxPowerOptionsPutTheComputerToSleepAfterNever;
        public Boolean ChckbxPowerOptionsPutTheComputerToSleepAfterNever
        {
            get => _chckbxPowerOptionsPutTheComputerToSleepAfterNever;
            set
            {
                if (_chckbxPowerOptionsPutTheComputerToSleepAfterNever == value)
                    return;

                _chckbxPowerOptionsPutTheComputerToSleepAfterNever = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsPutTheComputerToSleepAfterNever));
                PowerOptionsPutTheComputerToSleepAfterNever();
            }
        }

        public void PowerOptionsPutTheComputerToSleepAfterNever()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '238c9fa8-0aad-41ed-83f4-97be242c8f20' '29f6c1db-86da-48c5-9fdb-f2b67b1f44da' '0'";
            string ArgsUnchecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '238c9fa8-0aad-41ed-83f4-97be242c8f20' '29f6c1db-86da-48c5-9fdb-f2b67b1f44da' '900'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionsPutTheComputerToSleepAfterNever)
            {
                    Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - USB settings - USB selective suspend settings - Disabled - Command

        private Boolean _chckbxPowerOptionsUSBSelectiveSuspendSettings;
        public Boolean ChckbxPowerOptionsUSBSelectiveSuspendSettings
        {
            get => _chckbxPowerOptionsUSBSelectiveSuspendSettings;
            set
            {
                if (_chckbxPowerOptionsUSBSelectiveSuspendSettings == value)
                    return;

                _chckbxPowerOptionsUSBSelectiveSuspendSettings = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsUSBSelectiveSuspendSettings));
                PowerOptionsUSBSelectiveSuspendSettings();
            }
        }

        public void PowerOptionsUSBSelectiveSuspendSettings()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '2a737441-1930-4402-8d77-b2bebba308a3' '48e6b7a6-50f5-4782-a5d4-53bb8f07e226' '0'";
            string ArgsUnchecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '2a737441-1930-4402-8d77-b2bebba308a3' '48e6b7a6-50f5-4782-a5d4-53bb8f07e226' '1'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionsUSBSelectiveSuspendSettings)
            {
               Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - PCI Express - Link State Power Management - Off - Command

        private Boolean _chckbxPowerOptionLinkStatPowerManagement;
        public Boolean ChckbxPowerOptionLinkStatPowerManagement
        {
            get => _chckbxPowerOptionLinkStatPowerManagement;
            set
            {
                if (_chckbxPowerOptionLinkStatPowerManagement == value)
                    return;

                _chckbxPowerOptionLinkStatPowerManagement = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionLinkStatPowerManagement));
                Template();
            }
        }

        public void Template()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '501a4d13-42af-4429-9fd1-a8218c268e20' 'ee12f906-d277-404b-b6da-e5fa1a576df5' '0'";
            string ArgsUnchecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '501a4d13-42af-4429-9fd1-a8218c268e20' 'ee12f906-d277-404b-b6da-e5fa1a576df5' '1'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionLinkStatPowerManagement)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }



        // Checkbox - Display - Turn off the display after - Never - Command

        private Boolean _chckbxPowerOptionsTurnDisplayOffAfter;
        public Boolean ChckbxPowerOptionsTurnDisplayOffAfter
        {
            get => _chckbxPowerOptionsTurnDisplayOffAfter;
            set
            {
                if (_chckbxPowerOptionsTurnDisplayOffAfter == value)
                    return;

                _chckbxPowerOptionsTurnDisplayOffAfter = value;
                OnPropertyChanged(nameof(ChckbxPowerOptionsTurnDisplayOffAfter));
                PowerOptionsTurnDisplayOffAfter();
            }
        }

        public void PowerOptionsTurnDisplayOffAfter()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '7516b95f-f776-4464-8c53-06167f40cc99' '3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e' '0'";
            string ArgsUnchecked = @"powershell powercfg /SETACVALUEINDEX 'SCHEME_CURRENT' '7516b95f-f776-4464-8c53-06167f40cc99' '3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e' '900'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxPowerOptionsTurnDisplayOffAfter)
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

        #region Security and Maintenance

        #region Change User Account Control Settings


        // Checkbox - Set UAC Slider to "Never Notify" - Command

        private Boolean _chckbxSecurityAndMaintenanceSetUACSliderToNeverNotify;
        public Boolean ChckbxSecurityAndMaintenanceSetUACSliderToNeverNotify
        {
            get => _chckbxSecurityAndMaintenanceSetUACSliderToNeverNotify;
            set
            {
                if (_chckbxSecurityAndMaintenanceSetUACSliderToNeverNotify == value)
                    return;

                _chckbxSecurityAndMaintenanceSetUACSliderToNeverNotify = value;
                OnPropertyChanged(nameof(ChckbxSecurityAndMaintenanceSetUACSliderToNeverNotify));
                SecurityAndMaintenanceSetUACSliderToNeverNotify();
            }
        }

        public void SecurityAndMaintenanceSetUACSliderToNeverNotify()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
            string Name = @"EnableLUA";
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

            if (ChckbxSecurityAndMaintenanceSetUACSliderToNeverNotify)
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

        #region System

        #region Advanced System Settings - Tab: Advanced


        // Checkbox - Performance - Tab: Visual - Command

        private Boolean _chckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom;
        public Boolean ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom
        {
            get => _chckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom;
            set
            {
                if (_chckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom == value)
                    return;

                _chckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom = value;
                OnPropertyChanged(nameof(ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom));
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom1();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom2();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom3();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom4();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom5();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom6();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom7();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom8();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom9();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom10();
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom11();

            }
        }


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom1()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects";
            string Name = @"VisualFXSetting";
            string Type = @"DWord";
            string Value = @"3";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom2()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"UserPreferencesMask";
            string Type = @"Binary";
            string Value = @"([byte[]](0x90,0x12,0x03,0x80,0x10,0x00,0x00,0x00))";
            string Default = @"([byte[]](0x9e,0x1e,0x07,0x80,0x12,0x00,0x00,0x00))";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value ([byte[]](0x90,0x12,0x03,0x80,0x10,0x00,0x00,0x00)) -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value ([byte[]](0x9e,0x1e,0x07,0x80,0x12,0x00,0x00,0x00)) -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom3()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop\\WindowMetrics";
            string Name = @"MinAnimate";
            string Type = @"String";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom4()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"TaskbarAnimations";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom5()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\DWM";
            string Name = @"EnableAeroPeek";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom6()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\DWM";
            string Name = @"AlwaysHibernateThumbnails";
            string Type = @"DWord";
            string Value = @"0";
            string Default = @"0";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom7()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = @"DisableThumbnails";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom8()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"ListviewAlphaSelect";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom9()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"DragFullWindows";
            string Type = @"String";
            string Value = @"1";
            string Default = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom10()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Control Panel\\Desktop";
            string Name = @"FontSmoothing";
            string Type = @"String";
            string Value = @"2";
            string Default = @"2";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom11()
        {
            string RegistryHive = @"HKCU:\\";
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = @"ListviewShadow";
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

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
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


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom()
        {
            string RegistryHive = @"HKCU:\\";
            
            string RegistryPath = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects";
            string RegistryPath2 = @"Control Panel\\Desktop";
            string RegistryPath3 = @"Control Panel\\Desktop\\WindowMetrics";
            string RegistryPath4 = @"Software\\Microsoft\\Windows\\DWM";
            string RegistryPath5 = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string RegistryPath6 = @"Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            
            string Name = @"VisualFXSetting";
            string Name2 = @"UserPreferencesMask";
            string Name3 = @"MinAnimate";
            string Name4 = @"TaskbarAnimations";
            string Name5 = @"EnableAeroPeek";
            string Name6 = @"AlwaysHibernateThumbnails";
            string Name7 = @"DisableThumbnails";
            string Name8 = @"ListviewAlphaSelect";
            string Name9 = @"DragFullWindows";
            string Name10 = @"FontSmoothing";
            string Name11 = @"ListviewShadow";
           
            string Type = @"Dword";
            string Type2 = @"String";
            string Type3 = @"Binary";
            
            string Value = @"3";
            string Value2 = @"([byte[]](0x90,0x12,0x03,0x80,0x10,0x00,0x00,0x00))";
            string Value3 = @"0";
            string Value4 = @"0";
            string Value5 = @"0";
            string Value6 = @"0";
            string Value7 = @"0";
            string Value8 = @"0";
            string Value9 = @"1";
            string Value10 = @"2";
            string Value11 = @"0";
            
            string Default = @"0";
            string Default2 = @"([byte[]](0x9e,0x1e,0x07,0x80,0x12,0x00,0x00,0x00))";
            string Default3 = @"1";
            string Default4 = @"1";
            string Default5 = @"1";
            string Default6 = @"0";
            string Default7 = @"1";
            string Default8 = @"1";
            string Default9 = @"1";
            string Default10 = @"1";
            string Default11 = @"1";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsNoKey2 = @"powershell New-Item -Path '" + RegistryHive + RegistryPath2 + "' -Force";
            string ArgsNoKey3 = @"powershell New-Item -Path '" + RegistryHive + RegistryPath3 + "' -Force";
            string ArgsNoKey4 = @"powershell New-Item -Path '" + RegistryHive + RegistryPath4 + "' -Force";
            string ArgsNoKey5 = @"powershell New-Item -Path '" + RegistryHive + RegistryPath5 + "' -Force";
            string ArgsNoKey6 = @"powershell New-Item -Path '" + RegistryHive + RegistryPath6 + "' -Force";

            string ArgsChecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Value + "' -Force";
            string ArgsChecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name2 + "' -Type '" + Type3 + "' -Value ([byte[]](0x90,0x12,0x03,0x80,0x10,0x00,0x00,0x00)) -Force";
            string ArgsChecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name3 + "' -Type '" + Type2 + "' -Value '" + Value3 + "' -Force";
            string ArgsChecked4 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name4 + "' -Type '" + Type + "' -Value '" + Value4 + "' -Force";
            string ArgsChecked5 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name5 + "' -Type '" + Type + "' -Value '" + Value5 + "' -Force";
            string ArgsChecked6 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name6 + "' -Type '" + Type + "' -Value '" + Value6 + "' -Force";
            string ArgsChecked7 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath5 + "' -Name '" + Name7 + "' -Type '" + Type + "' -Value '" + Value7 + "' -Force";
            string ArgsChecked8 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name8 + "' -Type '" + Type + "' -Value '" + Value8 + "' -Force";
            string ArgsChecked9 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name9 + "' -Type '" + Type2 + "' -Value '" + Value9 + "' -Force";
            string ArgsChecked10 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name10 + "' -Type '" + Type2 + "' -Value '" + Value10 + "' -Force";
            string ArgsChecked11 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name11 + "' -Type '" + Type + "' -Value '" + Value11 + "' -Force";
            
            string ArgsUnchecked = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath + "' -Name '" + Name + "' -Type '" + Type + "' -Value '" + Default + "' -Force";
            string ArgsUnchecked2 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name2 + "' -Type '" + Type3 + "' -Value ([byte[]](0x9e,0x1e,0x07,0x80,0x12,0x00,0x00,0x00)) -Force";
            string ArgsUnchecked3 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath3 + "' -Name '" + Name3 + "' -Type '" + Type2 + "' -Value '" + Default3 + "' -Force";
            string ArgsUnchecked4 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name4 + "' -Type '" + Type + "' -Value '" + Default4 + "' -Force";
            string ArgsUnchecked5 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name5 + "' -Type '" + Type + "' -Value '" + Default5 + "' -Force";
            string ArgsUnchecked6 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath4 + "' -Name '" + Name6 + "' -Type '" + Type + "' -Value '" + Default6 + "' -Force";
            string ArgsUnchecked7 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath5 + "' -Name '" + Name7 + "' -Type '" + Type + "' -Value '" + Default7 + "' -Force";
            string ArgsUnchecked8 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name8 + "' -Type '" + Type + "' -Value '" + Default8 + "' -Force";
            string ArgsUnchecked9 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name9 + "' -Type '" + Type2 + "' -Value '" + Default9 + "' -Force";
            string ArgsUnchecked10 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath2 + "' -Name '" + Name10 + "' -Type '" + Type2 + "' -Value '" + Default10 + "' -Force";
            string ArgsUnchecked11 = @"powershell Set-ItemProperty -Path '" + RegistryHive + RegistryPath6 + "' -Name '" + Name11 + "' -Type '" + Type + "' -Value '" + Default11 + "' -Force";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU2 = RegKeyCU.OpenSubKey(RegistryPath2, true);
            var CheckRegKeyCU3 = RegKeyCU.OpenSubKey(RegistryPath3, true);
            var CheckRegKeyCU4 = RegKeyCU.OpenSubKey(RegistryPath4, true);
            var CheckRegKeyCU5 = RegKeyCU.OpenSubKey(RegistryPath5, true);
            var CheckRegKeyCU6 = RegKeyCU.OpenSubKey(RegistryPath6, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
            {
                if (CheckRegKeyCU == null)
                {
                    Process.Start(Exe, ArgsNoKey);
                    Process.Start(Exe, ArgsChecked);
                }
                else
                    Process.Start(Exe, ArgsChecked);

                if (CheckRegKeyCU2 == null)
                {
                    Process.Start(Exe, ArgsNoKey2);
                    Process.Start(Exe, ArgsChecked2);
                }
                else
                    Process.Start(Exe, ArgsChecked2);

                if (CheckRegKeyCU3 == null)
                {
                    Process.Start(Exe, ArgsNoKey3);
                    Process.Start(Exe, ArgsChecked3);
                }
                else
                    Process.Start(Exe, ArgsChecked3);

                if (CheckRegKeyCU6 == null)
                {
                    Process.Start(Exe, ArgsNoKey6);
                    Process.Start(Exe, ArgsChecked4);
                }
                else
                    Process.Start(Exe, ArgsChecked4);

                if (CheckRegKeyCU4 == null)
                {
                    Process.Start(Exe, ArgsNoKey4);
                    Process.Start(Exe, ArgsChecked5);
                }
                else
                    Process.Start(Exe, ArgsChecked5);

                if (CheckRegKeyCU4 == null)
                {
                    Process.Start(Exe, ArgsNoKey4);
                    Process.Start(Exe, ArgsChecked6);
                }
                else
                    Process.Start(Exe, ArgsChecked6);

                if (CheckRegKeyCU5 == null)
                {
                    Process.Start(Exe, ArgsNoKey5);
                    Process.Start(Exe, ArgsChecked7);
                }
                else
                    Process.Start(Exe, ArgsChecked7);

                if (CheckRegKeyCU6 == null)
                {
                    Process.Start(Exe, ArgsNoKey6);
                    Process.Start(Exe, ArgsChecked8);
                }
                else
                    Process.Start(Exe, ArgsChecked8);

                if (CheckRegKeyCU2 == null)
                {
                    Process.Start(Exe, ArgsNoKey2);
                    Process.Start(Exe, ArgsChecked9);
                }
                else
                    Process.Start(Exe, ArgsChecked9);

                if (CheckRegKeyCU2 == null)
                {
                    Process.Start(Exe, ArgsNoKey2);
                    Process.Start(Exe, ArgsChecked10);
                }
                else
                    Process.Start(Exe, ArgsChecked10);

                if (CheckRegKeyCU6 == null)
                {
                    Process.Start(Exe, ArgsNoKey6);
                    Process.Start(Exe, ArgsChecked11);
                }
                else
                    Process.Start(Exe, ArgsChecked11);

            }
            else
            Process.Start(Exe, ArgsUnchecked);
            Process.Start(Exe, ArgsUnchecked2);
            Process.Start(Exe, ArgsUnchecked3);
            Process.Start(Exe, ArgsUnchecked4);
            Process.Start(Exe, ArgsUnchecked5);
            Process.Start(Exe, ArgsUnchecked6);
            Process.Start(Exe, ArgsUnchecked7);
            Process.Start(Exe, ArgsUnchecked8);
            Process.Start(Exe, ArgsUnchecked9);
            Process.Start(Exe, ArgsUnchecked10);
            Process.Start(Exe, ArgsUnchecked11);
        }


        // Checkbox - Startup and Recovery - Command

        private Boolean _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS;
        public Boolean ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS
        {
            get => _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS;
            set
            {
                if (_chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS == value)
                    return;

                _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS = value;
                OnPropertyChanged(nameof(ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS));
                SystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS();
            }
        }

        public void SystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell bcdedit /timeout 0";
            string ArgsUnchecked = @"powershell bcdedit /timeout 10";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryTimeToDisplayListOfOS)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Enable F8 during Boot - Command

        private Boolean _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot;
        public Boolean ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot
        {
            get => _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot;
            set
            {
                if (_chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot == value)
                    return;

                _chckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot = value;
                OnPropertyChanged(nameof(ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot));
                SystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot();
            }
        }

        public void SystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell bcdedit /set '{default}' 'bootmenupolicy' 'legacy'";
            string ArgsUnchecked = @"powershell bcdedit /set '{default}' 'bootmenupolicy' 'legacy'";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot)
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

        #region Advanced System Settings - Tab: Remote


        // Checkbox - Remote Assistance - Command

        private Boolean _chckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance;
        public Boolean ChckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance
        {
            get => _chckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance;
            set
            {
                if (_chckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance == value)
                    return;

                _chckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance = value;
                OnPropertyChanged(nameof(ChckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance));
                SystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance();
            }
        }

        public void SystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance()
        {
            string RegistryHive = @"HKLM:\\";
            string RegistryPath = @"System\CurrentControlSet\Control\Remote Assistance";
            string Name = @"fAllowToGetHelp";
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

            if (ChckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance)
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

        #region Windows Defender Firewall

        // Checkbox - Turn Off - Windows Defender Firewall - On All Profiles - Command

        private Boolean _chckbxWindowsDefenderFirewallTurnOffOnAllProfiles;
        public Boolean ChckbxWindowsDefenderFirewallTurnOffOnAllProfiles
        {
            get => _chckbxWindowsDefenderFirewallTurnOffOnAllProfiles;
            set
            {
                if (_chckbxWindowsDefenderFirewallTurnOffOnAllProfiles == value)
                    return;

                _chckbxWindowsDefenderFirewallTurnOffOnAllProfiles = value;
                OnPropertyChanged(nameof(ChckbxWindowsDefenderFirewallTurnOffOnAllProfiles));
                WindowsDefenderFirewallTurnOffOnAllProfiles();
            }
        }

        public void WindowsDefenderFirewallTurnOffOnAllProfiles()
        {
            string RegistryHive = @"HK:\\";
            string RegistryPath = @"";
            string Name = @"";
            string Type = @"";
            string Value = @"";
            string Default = @"";

            string Exe = "Wt.exe";
            string ArgsNoKey = @"powershell New-Item -Path '" + RegistryHive + RegistryPath + "' -Force";
            string ArgsChecked = @"powershell netsh advfirewall set allprofiles state off";
            string ArgsUnchecked = @"powershell netsh advfirewall set allprofiles state on";
            RegistryKey RegKeyLM = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey RegKeyCU = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.CurrentUser, RegistryView.Registry64);
            var CheckRegKeyLM = RegKeyLM.OpenSubKey(RegistryPath, true);
            var CheckRegKeyCU = RegKeyCU.OpenSubKey(RegistryPath, true);

            if (ChckbxWindowsDefenderFirewallTurnOffOnAllProfiles)
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


    }

}
