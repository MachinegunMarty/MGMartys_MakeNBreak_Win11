using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\SOFTWARE\\Microsoft\\Ease of Access\"";
            string Name = "selfvoice";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToUseDisableAlwaysReadThisSectionAloud)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\SOFTWARE\\Microsoft\\Ease of Access\"";
            string Name = "selfscan";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToUseDisableAlwaysScanThisSection)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\HighContrast\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "4194";
            string Default = "4198";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToSeeTurnOffHighContrast)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\"";
            string Name = "\"Warning Sounds\"";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToSeeDisableDisplayAWarningMessageWhenTurningASettingOn)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\"";
            string Name = "\"Sound on Activation\"";
            string Type = "REG_DWORD";
            string Value = @"0";
            string Default = @"1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToSeeDisableMakeASoundWhenTurningASettingOnOrOff)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Desktop\\WindowMetrics\"";
            string Name = "MinAnimate";
            string Type = "REG_SZ";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheComputerEasierToSeeTurnOffAllUnneccassaryAnimations)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\MouseKeys\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "130";
            string Default = "131";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheKeyboardEasierToUseSetUpMouseKeys)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\StickyKeys\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "2";
            string Default = "3";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheKeyboardEasierToUseSetUpStickyKeys)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\ToggleKeys\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "34";
            string Default = "35";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheKeyboardEasierToUseDisableTurnOnToggleKeysByHoldingDownNumLock)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\StickyKeys\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "102";
            string Default = "103";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMakeTheKeyboardEasierToUseSetUpFilterKeys)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\SoundSentry\"";
            string Name = "Flags";
            string Type = "REG_SZ";
            string Value = "2";
            string Default = "3";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxUseTextOrVisualAlternativesForSoundDisableTurnOnVisualNotificationsForSounds)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\SoundSentry\"";
            string Name = "WindowsEffect";
            string Type = "REG_SZ";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxUseTextOrVisualAlternativesForSoundChooseVisualWarning)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Accessibility\\SlateLaunch\"";
            string Name = "LaunchAT";
            string Name2 = "ATapp";
            string Type = "REG_DWORD";
            string Type2 = "REG_SZ";
            string Value = "0";
            string Default = "1";
            string Value2 = "\" \"";
            string Default2 = "narrator";

           
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsValue2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type2 + " /d " + Value2 + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type2 + " /d " + Default2 + " /f";

            if (ChckbxMakeTouchAndTabletsEasierToUseLaunchingCommonTools)
            {
                Process.Start(Exe, ArgsValue);
                Process.Start(Exe, ArgsValue2);
            }
            else
                Process.Start(Exe, ArgsDefault);
                Process.Start(Exe, ArgsDefault2);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "LaunchTo";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionsGeneralFileExplorerToThisPc)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = "ShowRecent";
            string Type = "REG_DWORD";
            string Value = @"0";
            string Default = @"1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionsGeneralShowRecentlyUsedFiles)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = "ShowFrequent";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionsGeneralShowFrequentlyUsedFolders)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer";
            string Name = "ShowCloudFilesInQuickAccess";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";


            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionsGeneralShowFilesFromOffice)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "Hidden";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "2";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionViewShowHiddenFiles)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string Name = "HideFileExt";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxFolderOptionViewHideFileExtensions)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Search\\Preferences";
            string Name = "WholeFileSystem";
            string Type = "REG_DWORD";
            string Value = "1";
            string Default = "0";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSearchDontUseTheIndexWhenSearchingInFileFoldersForFileSystem)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Mouse\"";
            string Name = "MouseThreshold1";
            string Name2 = "MouseThreshold2";
            string Name3 = "MouseSpeed";
            string Type = "REG_SZ";
            string Value = "0";
            string Default1 = "6";
            string Default2 = "10";
            string Default3 = "1";

            string ArgsValue1 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f" ;
            string ArgsValue2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Value + " /f";
            string ArgsValue3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Value + " /f";
           
            string ArgsDefault1 = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default1 + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type + " /d " + Default2 + " /f";
            string ArgsDefault3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type + " /d " + Default3 + " /f";

            if (ChckbxMouseDisableEnhancedPointerPrecision)
            {
                Process.Start(Exe, ArgsValue1);
                Process.Start(Exe, ArgsValue2);
                Process.Start(Exe, ArgsValue3);
            }

            else
            {
                Process.Start(Exe, ArgsDefault1);
                Process.Start(Exe, ArgsDefault2);
                Process.Start(Exe, ArgsDefault3);
            }
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Mouse\"";
            string Name = "MouseSensitivity";
            string Name2 = "SmoothMouseXCurve";
            string Name3 = "SmoothMouseYCurve";
            string Type = "REG_SZ";
            string Type2 = "REG_BINARY";
            string Value = "10";
            string Value2 = "0000000000000000C0CC0C0000000000809919000000000040662600000000000033330000000000";
            string Value3 = "0000000000000000000038000000000000007000000000000000A800000000000000E00000000000";
            string Default = "10";
            string Default2 = "0000000000000000156e000000000000004001000000000029dc0300000000000000280000000000";
            string Default3 = "0000000000000000fd11010000000000002404000000000000fc12000000000000c0bb0100000000";


            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsValue2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type2 + " /d " + Value2 + " /f";
            string ArgsValue3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type2 + " /d " + Value3 + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath + " /v " + Name2 + " /t " + Type2 + " /d " + Default2 + " /f";
            string ArgsDefault3 = "/C Reg Add " + RegistryPath + " /v " + Name3 + " /t " + Type2 + " /d " + Default3 + " /f";

            if (ChckbxMouseDisableMouseSmoothingAndAccelaration)
            {
                Process.Start(Exe, ArgsValue);
                Process.Start(Exe, ArgsValue2);
                Process.Start(Exe, ArgsValue3);
            }
            else
            {
                Process.Start(Exe, ArgsDefault);
                Process.Start(Exe, ArgsDefault2);
                Process.Start(Exe, ArgsDefault3);
            }
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKCU\\Control Panel\\Mouse\"";
            string Name = "MouseHoverTime";
            string Type = "REG_SZ";
            string Value = "8";
            string Default = "400";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxMouseShowPopupsFasterWhenHoveringOverAnItem)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg  /setactive e9a42b02-d5df-448d-aa00-03f14749eb61";
            string ArgsUnchecked = "/C powercfg  /setactive 381b4222-f694-41f0-9685-ff5bb260df2e";
            
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Power\"";
            string Name = "HiberbootEnabled";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxPowerOptionsDisableFastStartup)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 0";
            string ArgsUnchecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 0012ee47-9041-4b5d-9b77-535fba8b1442 6738e2c4-e8a5-4a42-b16a-e040e769756e 900";
            
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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 0";
            string ArgsUnchecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 238c9fa8-0aad-41ed-83f4-97be242c8f20 29f6c1db-86da-48c5-9fdb-f2b67b1f44da 900";

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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 0";
            string ArgsUnchecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 2a737441-1930-4402-8d77-b2bebba308a3 48e6b7a6-50f5-4782-a5d4-53bb8f07e226 1";

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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 501a4d13-42af-4429-9fd1-a8218c268e20 ee12f906-d277-404b-b6da-e5fa1a576df5 0";
            string ArgsUnchecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 501a4d13-42af-4429-9fd1-a8218c268e20 ee12f906-d277-404b-b6da-e5fa1a576df5 1";

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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 0";
            string ArgsUnchecked = "/C powercfg /SETACVALUEINDEX SCHEME_CURRENT 7516b95f-f776-4464-8c53-06167f40cc99 3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e 900";

            if (ChckbxPowerOptionsTurnDisplayOffAfter)
            {
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
            string Exe = "cmd.exe";
            string RegistryPath = "HKLM\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            string Name = "EnableLUA";
            string Type = "REG_DWORD";
            string Value = "0";
            string Default = "1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSecurityAndMaintenanceSetUACSliderToNeverNotify)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
                SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom();
                

            }
        }


        public void SystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom()
        {
            string Exe = "cmd.exe";
            string RegistryPath = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects";
            string RegistryPath2 = "\"HKCU\\Control Panel\\Desktop\"";
            string RegistryPath3 = "\"HKCU\\Control Panel\\Desktop\\WindowMetrics\"";
            string RegistryPath4 = "HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
            string RegistryPath5 = "HKCU\\Software\\Microsoft\\Windows\\DWM";
            string RegistryPath6 = "HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
            string Name = "VisualFXSetting";
            string Name2 = "UserPreferencesMask";
            string Name3 = "MinAnimate";
            string Name4 = "TaskbarAnimations";
            string Name5 = "EnableAeroPeek";
            string Name6 = "AlwaysHibernateThumbnails";
            string Name7 = "DisableThumbnails";
            string Name8 = "ListviewAlphaSelect";
            string Name9 = "DragFullWindows";
            string Name10 = "FontSmoothing";
            string Name11 = "ListviewShadow";
            string Type = "REG_DWORD";
            string Type2 = "REG_BINARY";
            string Type3 = "REG_SZ";
            string Value = "3";
            string Value2 = "9012038010000000";
            string Value3 = "0";
            string Value4 = "1";
            string Value5 = "2";
            string Default = "0";
            string Default2 = "9e1e078012000000";
            string Default3 = "1";
            string Default4 = "2";
           
            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsValue2 = "/C Reg Add " + RegistryPath2 + " /v " + Name2 + " /t " + Type2 + " /d " + Value2 + " /f";
            string ArgsValue3 = "/C Reg Add " + RegistryPath3 + " /v " + Name3 + " /t " + Type3 + " /d " + Value3 + " /f";
            string ArgsValue4 = "/C Reg Add " + RegistryPath4 + " /v " + Name4 + " /t " + Type + " /d " + Value3 + " /f";
            string ArgsValue5 = "/C Reg Add " + RegistryPath5 + " /v " + Name5 + " /t " + Type + " /d " + Value3 + " /f";
            string ArgsValue6 = "/C Reg Add " + RegistryPath5 + " /v " + Name6 + " /t " + Type + " /d " + Value3 + " /f";
            string ArgsValue7 = "/C Reg Add " + RegistryPath6 + " /v " + Name7 + " /t " + Type + " /d " + Value4 + " /f";
            string ArgsValue8 = "/C Reg Add " + RegistryPath4 + " /v " + Name8 + " /t " + Type + " /d " + Value3 + " /f";
            string ArgsValue9 = "/C Reg Add " + RegistryPath2 + " /v " + Name9 + " /t " + Type3 + " /d " + Value4 + " /f";
            string ArgsValue10 = "/C Reg Add " + RegistryPath2 + " /v " + Name10 + " /t " + Type3 + " /d " + Value5 + " /f";
            string ArgsValue11 = "/C Reg Add " + RegistryPath4 + " /v " + Name11 + " /t " + Type + " /d " + Value3 + " /f";

            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";
            string ArgsDefault2 = "/C Reg Add " + RegistryPath2 + " /v " + Name2 + " /t " + Type2 + " /d " + Default2 + " /f";
            string ArgsDefault3 = "/C Reg Add " + RegistryPath3 + " /v " + Name3 + " /t " + Type3 + " /d " + Default3 + " /f";
            string ArgsDefault4 = "/C Reg Add " + RegistryPath4 + " /v " + Name4 + " /t " + Type + " /d " + Default3 + " /f";
            string ArgsDefault5 = "/C Reg Add " + RegistryPath5 + " /v " + Name5 + " /t " + Type + " /d " + Default3 + " /f";
            string ArgsDefault6 = "/C Reg Add " + RegistryPath5 + " /v " + Name6 + " /t " + Type + " /d " + Default + " /f";
            string ArgsDefault7 = "/C Reg Add " + RegistryPath6 + " /v " + Name7 + " /t " + Type + " /d " + Default3 + " /f";
            string ArgsDefault8 = "/C Reg Add " + RegistryPath4 + " /v " + Name8 + " /t " + Type + " /d " + Default3 + " /f";
            string ArgsDefault9 = "/C Reg Add " + RegistryPath2 + " /v " + Name9 + " /t " + Type3 + " /d " + Default3 + " /f";
            string ArgsDefault10 = "/C Reg Add " + RegistryPath2 + " /v " + Name10 + " /t " + Type3 + " /d " + Default4 + " /f";
            string ArgsDefault11 = "/C Reg Add " + RegistryPath4 + " /v " + Name11 + " /t " + Type + " /d " + Default3 + " /f";

            if (ChckbxSystemAdvancedSystemSettingsAdvancedPerformanceTabVisualCustom)
            {
                Process.Start(Exe, ArgsValue);
                Process.Start(Exe, ArgsValue2);
                Process.Start(Exe, ArgsValue3);
                Process.Start(Exe, ArgsValue4);
                Process.Start(Exe, ArgsValue5);
                Process.Start(Exe, ArgsValue6);
                Process.Start(Exe, ArgsValue7);
                Process.Start(Exe, ArgsValue8);
                Process.Start(Exe, ArgsValue9);
                Process.Start(Exe, ArgsValue10);
                Process.Start(Exe, ArgsValue11);
            }
            else
            {
                Process.Start(Exe, ArgsDefault);
                Process.Start(Exe, ArgsDefault2);
                Process.Start(Exe, ArgsDefault3);
                Process.Start(Exe, ArgsDefault4);
                Process.Start(Exe, ArgsDefault5);
                Process.Start(Exe, ArgsDefault6);
                Process.Start(Exe, ArgsDefault7);
                Process.Start(Exe, ArgsDefault8);
                Process.Start(Exe, ArgsDefault9);
                Process.Start(Exe, ArgsDefault10);
                Process.Start(Exe, ArgsDefault11);
            }
                
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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C bcdedit /timeout 0";
            string ArgsUnchecked = "/C bcdedit /timeout 10";

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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C bcdedit /set {default} bootmenupolicy legacy";
            string ArgsUnchecked = "/C bcdedit /set {default} bootmenupolicy legacy";

            if (ChckbxSystemAdvancedSystemSettingsAdvancedStartupAndRecoveryEnableF8DuringBoot)
            {
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
            string Exe = "cmd.exe";
            string RegistryPath = "\"HKLM\\System\\CurrentControlSet\\Control\\Remote Assistance\"";
            string Name = @"fAllowToGetHelp";
            string Type = @"REG_DWORD";
            string Value = @"0";
            string Default = @"1";

            string ArgsValue = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Value + " /f";
            string ArgsDefault = "/C Reg Add " + RegistryPath + " /v " + Name + " /t " + Type + " /d " + Default + " /f";

            if (ChckbxSystemAdvancedSystemSettingsRemoteRemoteAssistanceDisableAllowRemoteAssistance)
                Process.Start(Exe, ArgsValue);
            else
                Process.Start(Exe, ArgsDefault);
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
            string Exe = "cmd.exe";
            string ArgsChecked = "/C netsh advfirewall set allprofiles state off";
            string ArgsUnchecked = "/C netsh advfirewall set allprofiles state on";

            if (ChckbxWindowsDefenderFirewallTurnOffOnAllProfiles)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion


    }

}
