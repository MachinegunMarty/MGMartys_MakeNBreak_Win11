using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Win32;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class ServicesViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region Applications

        // Checkbox - Application Layer Gateway Service - Command

        private Boolean _chckbxServicesApplicationLayerGatewayService;
        public Boolean ChckbxServicesApplicationLayerGatewayService
        {
            get => _chckbxServicesApplicationLayerGatewayService;
            set
            {
                if (_chckbxServicesApplicationLayerGatewayService == value)
                    return;

                _chckbxServicesApplicationLayerGatewayService = value;
                OnPropertyChanged(nameof(ChckbxServicesApplicationLayerGatewayService));
                ServicesApplicationLayerGatewayService();
            }
        }

        public void ServicesApplicationLayerGatewayService()
        {
            string Name = "ALG";
            string StartupType1 = "disabled";
            string StartupType2 = "demand";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesApplicationLayerGatewayService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - application Management - Command

        private Boolean _chckbxServicesApplicationManagement;
        public Boolean ChckbxServicesApplicationManagement
        {
            get => _chckbxServicesApplicationManagement;
            set
            {
                if (_chckbxServicesApplicationManagement == value)
                    return;

                _chckbxServicesApplicationManagement = value;
                OnPropertyChanged(nameof(ChckbxServicesApplicationManagement));
                ServicesApplicationManagement();
            }
        }

        public void ServicesApplicationManagement()
        {
            string Name = "AppMgmt";
            string StartupType1 = "disabled";
            string StartupType2 = "demand";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesApplicationManagement)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Program Compatibility Assistant Service - Command

        private Boolean _chckbxServicesProgramCompatibilityAssistantService;
        public Boolean ChckbxServicesProgramCompatibilityAssistantService
        {
            get => _chckbxServicesProgramCompatibilityAssistantService;
            set
            {
                if (_chckbxServicesProgramCompatibilityAssistantService == value)
                    return;

                _chckbxServicesProgramCompatibilityAssistantService = value;
                OnPropertyChanged(nameof(ChckbxServicesProgramCompatibilityAssistantService));
                ServicesProgramCompatibilityAssistantService();
            }
        }

        public void ServicesProgramCompatibilityAssistantService()
        {
            string Name = "PcaSvc";
            string StartupType1 = "disabled";
            string StartupType2 = "delayed-auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesProgramCompatibilityAssistantService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        #endregion

        #region Demo


        // Checkbox - Retail Demo Service - Command

        private Boolean _chckbxServicesRetailDemoService;
        public Boolean ChckbxServicesRetailDemoService
        {
            get => _chckbxServicesRetailDemoService;
            set
            {
                if (_chckbxServicesRetailDemoService == value)
                    return;

                _chckbxServicesRetailDemoService = value;
                OnPropertyChanged(nameof(ChckbxServicesRetailDemoService));
                ServicesRetailDemoService();
            }
        }

        public void ServicesRetailDemoService()
        {
            string Name = "RetailDemo";
            string StartupType1 = "disabled";
            string StartupType2 = "demand";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesRetailDemoService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        #endregion

        #region Locations

        // Checkbox - Geolocation Service - Command

        private Boolean _chckbxServicesGeolocationService;
        public Boolean ChckbxServicesGeolocationService
        {
            get => _chckbxServicesGeolocationService;
            set
            {
                if (_chckbxServicesGeolocationService == value)
                    return;

                _chckbxServicesGeolocationService = value;
                OnPropertyChanged(nameof(ChckbxServicesGeolocationService));
                ServicesGeolocationService();
            }
        }

        public void ServicesGeolocationService()
        {
            string Name = "lfsvc";
            string StartupType1 = "disabled";
            string StartupType2 = "demand";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesGeolocationService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Maps

        // Checkbox - Downloaded Maps Manager - Command

        private Boolean _chckbxServicesDownloadedMapsManager;
        public Boolean ChckbxServicesDownloadedMapsManager
        {
            get => _chckbxServicesDownloadedMapsManager;
            set
            {
                if (_chckbxServicesDownloadedMapsManager == value)
                    return;

                _chckbxServicesDownloadedMapsManager = value;
                OnPropertyChanged(nameof(ChckbxServicesDownloadedMapsManager));
                ServicesDownloadedMapsManager();
            }
        }

        public void ServicesDownloadedMapsManager()
        {
            string Name = "MapsBroker";
            string StartupType1 = "disabled";
            string StartupType2 = "delayed-auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesApplicationLayerGatewayService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Printer

        // Checkbox - Downloaded Maps Manager - Command

        private Boolean _chckbxServicesPrintSpooler;
        public Boolean ChckbxServicesPrintSpooler
        {
            get => _chckbxServicesPrintSpooler;
            set
            {
                if (_chckbxServicesPrintSpooler == value)
                    return;

                _chckbxServicesPrintSpooler = value;
                OnPropertyChanged(nameof(ChckbxServicesPrintSpooler));
                ServicesPrintSpooler();
            }
        }

        public void ServicesPrintSpooler()
        {
            string Name = "Spooler";
            string StartupType1 = "disabled";
            string StartupType2 = "auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesPrintSpooler)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Privacy

        // Checkbox - Connected User Experiences and Telemetry - Command

        private Boolean _chckbxServicesConnectedUserExperiencesAndTelemetry;
        public Boolean ChckbxServicesConnectedUserExperiencesAndTelemetry
        {
            get => _chckbxServicesConnectedUserExperiencesAndTelemetry;
            set
            {
                if (_chckbxServicesConnectedUserExperiencesAndTelemetry == value)
                    return;

                _chckbxServicesConnectedUserExperiencesAndTelemetry = value;
                OnPropertyChanged(nameof(ChckbxServicesConnectedUserExperiencesAndTelemetry));
                ServicesConnectedUserExperiencesAndTelemetry();
            }
        }

        public void ServicesConnectedUserExperiencesAndTelemetry()
        {
            string Name = "DiagTrack";
            string StartupType1 = "disabled";
            string StartupType2 = "delayed-auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesConnectedUserExperiencesAndTelemetry)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }


        // Checkbox - Device Management Wireless Application Protocol (WAP) Push message Routing Service - Command

        private Boolean _chckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService;
        public Boolean ChckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService
        {
            get => _chckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService;
            set
            {
                if (_chckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService == value)
                    return;

                _chckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService = value;
                OnPropertyChanged(nameof(ChckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService));
                ServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService();
            }
        }

        public void ServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService()
        {
            string Name = "dmwappushservice";
            string StartupType1 = "disabled";
            string StartupType2 = "demand";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesDeviceManagementWirelessApplicationProtocolWAPPushMessageRoutingService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Search

        // Checkbox - Windows Search - Command

        private Boolean _chckbxServicesWindowsSearch;
        public Boolean ChckbxServicesWindowsSearch
        {
            get => _chckbxServicesWindowsSearch;
            set
            {
                if (_chckbxServicesWindowsSearch == value)
                    return;

                _chckbxServicesWindowsSearch = value;
                OnPropertyChanged(nameof(ChckbxServicesWindowsSearch));
                ServicesWindowsSearch();
            }
        }

        public void ServicesWindowsSearch()
        {
            string Name = "WSearch";
            string StartupType1 = "disabled";
            string StartupType2 = "auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesWindowsSearch)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Sysmain

        // Checkbox - Template - Command

        private Boolean _chckbxServicesSysMain;
        public Boolean ChckbxServicesSysMain
        {
            get => _chckbxServicesSysMain;
            set
            {
                if (_chckbxServicesSysMain == value)
                    return;

                _chckbxServicesSysMain = value;
                OnPropertyChanged(nameof(ChckbxServicesSysMain));
                ServicesSysMain();
            }
        }

        public void ServicesSysMain()
        {
            string Name = "SysMain";
            string StartupType1 = "disabled";
            string StartupType2 = "delayed-auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesSysMain)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

        #region Text Input Management Service

        // Checkbox - Text Input Management Service - Command

        private Boolean _chckbxServicesTextInputManagementService;
        public Boolean ChckbxServicesTextInputManagementService
        {
            get => _chckbxServicesTextInputManagementService;
            set
            {
                if (_chckbxServicesTextInputManagementService == value)
                    return;

                _chckbxServicesTextInputManagementService = value;
                OnPropertyChanged(nameof(ChckbxServicesTextInputManagementService));
                ServicesTextInputManagementService();
            }
        }

        public void ServicesTextInputManagementService()
        {
            string Name = "TextInputManagementService";
            string StartupType1 = "disabled";
            string StartupType2 = "auto";

            string Exe = "cmd.exe";
            string ArgsChecked = "/C sc config " + Name + " \"start=\" " + StartupType1;
            string ArgsUnchecked = "/C sc config " + Name + " \"start=\" " + StartupType2;


            if (ChckbxServicesTextInputManagementService)
            {
                Process.Start(Exe, ArgsChecked);
            }
            else
                Process.Start(Exe, ArgsUnchecked);
        }

        #endregion

    }
}
