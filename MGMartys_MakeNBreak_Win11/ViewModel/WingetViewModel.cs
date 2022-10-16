using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Xml.Linq;
using MGMartys_MakeNBreak_Win11.Model;
using MGMartys_MakeNBreak_Win11.Utilities;
using Microsoft.Win32;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class WingetViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }



        #region Runtimes

        // Install Microsoft .NET Windows Desktop Runtime 3.1
        private Boolean _chckbxInstallNet31;
        public Boolean ChckbxInstallNet31
        {
            get => _chckbxInstallNet31;
            set
            {
                if (_chckbxInstallNet31 == value)
                    return;

                _chckbxInstallNet31 = value;
                OnPropertyChanged(nameof(ChckbxInstallNet31));
                InstallNet31();
            }
        }
        public void InstallNet31()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.DotNet.DesktopRuntime.3_1 -e";

            if (ChckbxInstallNet31)
                Process.Start(Exe, Arguments);
        }


        // Install .Net 3.5 Framework
        private Boolean _chckbxInstallNet35;
        public Boolean ChckbxInstallNet35
        {
            get => _chckbxInstallNet35;
            set
            {
                if (_chckbxInstallNet35 == value)
                    return;

                _chckbxInstallNet35 = value;
                OnPropertyChanged(nameof(ChckbxInstallNet35));
                InstallNet35();
            }
        }
        public void InstallNet35()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C DISM /Online /Enable-Feature /FeatureName:NetFx3 /All";

            if (ChckbxInstallNet35)
                Process.Start(Exe, Arguments);
        }


        // Install .Net 4.8 Framework
        private Boolean _chckbxInstallNet48;
        public Boolean ChckbxInstallNet48
        {
            get => _chckbxInstallNet48;
            set
            {
                if (_chckbxInstallNet48 == value)
                    return;

                _chckbxInstallNet48 = value;
                OnPropertyChanged(nameof(ChckbxInstallNet48));
                InstallNet48();
            }
        }
        public void InstallNet48()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.dotNetFramework -e";

            if (ChckbxInstallNet48)
                Process.Start(Exe, Arguments);
        }


        // Install Microsoft .NET Windows Desktop Runtime 5.0
        private Boolean _chckbxInstallNet50;
        public Boolean ChckbxInstallNet50
        {
            get => _chckbxInstallNet50;
            set
            {
                if (_chckbxInstallNet50 == value)
                    return;

                _chckbxInstallNet50 = value;
                OnPropertyChanged(nameof(ChckbxInstallNet50));
                InstallNet50();
            }
        }
        public void InstallNet50()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.DotNet.DesktopRuntime.5 -e";

            if (ChckbxInstallNet50)
                Process.Start(Exe, Arguments);
        }


        // Install Microsoft .NET Windows Desktop Runtime 6.0
        private Boolean _chckbxInstallNet60;
        public Boolean ChckbxInstallNet60
        {
            get => _chckbxInstallNet60;
            set
            {
                if (_chckbxInstallNet60 == value)
                    return;

                _chckbxInstallNet60 = value;
                OnPropertyChanged(nameof(ChckbxInstallNet60));
                InstallNet60();
            }
        }
        public void InstallNet60()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.DotNet.DesktopRuntime.6 -e";

            if (ChckbxInstallNet60)
                Process.Start(Exe, Arguments);
        }


        // Install Eclipse Adoptium Temurin JRE 8
        private Boolean _chckbxInstallJava8;
        public Boolean ChckbxInstallJava8
        {
            get => _chckbxInstallJava8;
            set
            {
                if (_chckbxInstallJava8 == value)
                    return;

                _chckbxInstallJava8 = value;
                OnPropertyChanged(nameof(ChckbxInstallJava8));
                InstallJava8();
            }
        }
        public void InstallJava8()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=EclipseAdoptium.Temurin.8.JRE -e";

            if (ChckbxInstallJava8)
                Process.Start(Exe, Arguments);
        }


        // Install Eclipse Adoptium Temurin JRE 11
        private Boolean _chckbxInstallJava11;
        public Boolean ChckbxInstallJava11
        {
            get => _chckbxInstallJava11;
            set
            {
                if (_chckbxInstallJava11 == value)
                    return;

                _chckbxInstallJava11 = value;
                OnPropertyChanged(nameof(ChckbxInstallJava11));
                InstallJava11();
            }
        }
        public void InstallJava11()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=EclipseAdoptium.Temurin.11.JRE -e";

            if (ChckbxInstallJava11)
                Process.Start(Exe, Arguments);
        }


        // Install Eclipse Adoptium Temurin JRE 17
        private Boolean _chckbxInstallJava17;
        public Boolean ChckbxInstallJava17
        {
            get => _chckbxInstallJava17;
            set
            {
                if (_chckbxInstallJava17 == value)
                    return;

                _chckbxInstallJava17 = value;
                OnPropertyChanged(nameof(ChckbxInstallJava17));
                InstallJava17();
            }
        }
        public void InstallJava17()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=EclipseAdoptium.Temurin.17.JRE -e";

            if (ChckbxInstallJava17)
                Process.Start(Exe, Arguments);
        }


        // Install DirectX Web Setup
        private Boolean _chckbxInstallDirectX;
        public Boolean ChckbxInstallDirectX
        {
            get => _chckbxInstallDirectX;
            set
            {
                if (_chckbxInstallDirectX == value)
                    return;

                _chckbxInstallDirectX = value;
                OnPropertyChanged(nameof(ChckbxInstallDirectX));
                InstallDirectX();
            }
        }
        public void InstallDirectX()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.DirectX -e";

            if (ChckbxInstallDirectX)
                Process.Start(Exe, Arguments);
        }


        // Install Visual C++ 2005 (x86 + x64)
        private Boolean _chckbxInstallVisualC2005;
        public Boolean ChckbxInstallVisualC2005
        {
            get => _chckbxInstallVisualC2005;
            set
            {
                if (_chckbxInstallVisualC2005 == value)
                    return;

                _chckbxInstallVisualC2005 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2005));
                InstallVisualC2005();
            }
        }
        public void InstallVisualC2005()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2005.x86 -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2005.x64 -e";

            if (ChckbxInstallVisualC2005)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }


        // Install Visual C++ 2008 (x86 + x64)
        private Boolean _chckbxInstallVisualC2008;
        public Boolean ChckbxInstallVisualC2008
        {
            get => _chckbxInstallVisualC2008;
            set
            {
                if (_chckbxInstallVisualC2008 == value)
                    return;

                _chckbxInstallVisualC2008 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2008));
                InstallVisualC2008();
            }
        }
        public void InstallVisualC2008()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2008.x86 -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2008.x64 -e";

            if (ChckbxInstallVisualC2008)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }


        // Install Visual C++ 2010 (x86 + x64)
        private Boolean _chckbxInstallVisualC2010;
        public Boolean ChckbxInstallVisualC2010
        {
            get => _chckbxInstallVisualC2010;
            set
            {
                if (_chckbxInstallVisualC2010 == value)
                    return;

                _chckbxInstallVisualC2010 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2010));
                InstallVisualC2010();
            }
        }
        public void InstallVisualC2010()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2010.x86  -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2010.x64  -e";

            if (ChckbxInstallVisualC2010)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }


        // Install Visual C++ 2012 (x86 + x64)
        private Boolean _chckbxInstallVisualC2012;
        public Boolean ChckbxInstallVisualC2012
        {
            get => _chckbxInstallVisualC2012;
            set
            {
                if (_chckbxInstallVisualC2012 == value)
                    return;

                _chckbxInstallVisualC2012 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2012));
                InstallVisualC2012();
            }
        }
        public void InstallVisualC2012()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2012.x86 -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2012.x64 -e";

            if (ChckbxInstallVisualC2012)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }


        // Install Visual C++ 2013 (x86 + x64)
        private Boolean _chckbxInstallVisualC2013;
        public Boolean ChckbxInstallVisualC2013
        {
            get => _chckbxInstallVisualC2013;
            set
            {
                if (_chckbxInstallVisualC2013 == value)
                    return;

                _chckbxInstallVisualC2013 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2013));
                InstallVisualC2013();
            }
        }
        public void InstallVisualC2013()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2013.x86 -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2013.x64 -e";

            if (ChckbxInstallVisualC2013)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }


        //  Install Visual C++ 2015, 2017, 2019, 2022 (x86 + x64)
        private Boolean _chckbxInstallVisualC2015171922;
        public Boolean ChckbxInstallVisualC2015171922
        {
            get => _chckbxInstallVisualC2015171922;
            set
            {
                if (_chckbxInstallVisualC2015171922 == value)
                    return;

                _chckbxInstallVisualC2015171922 = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualC2015171922));
                InstallVisualC2015171922();
            }
        }
        public void InstallVisualC2015171922()
        {
            string Exe = "cmd.exe";
            string Argumentsx86 = "/C winget install --id=Microsoft.VCRedist.2015+.x86 -e";
            string Argumentsx64 = "/C winget install --id=Microsoft.VCRedist.2015+.x64 -e";

            if (ChckbxInstallVisualC2015171922)
                Process.Start(Exe, Argumentsx86).WaitForExit(50000);
                Process.Start(Exe, Argumentsx64);
        }



        #endregion



        #region Browsers

       // Install Brave
        private Boolean _chckbxInstallBrave;
        public Boolean ChckbxInstallBrave
        {
            get => _chckbxInstallBrave;
            set
            {
                if (_chckbxInstallBrave == value)
                    return;

                _chckbxInstallBrave = value;
                OnPropertyChanged(nameof(ChckbxInstallBrave));
                InstallBrave();
            }
        }
        public void InstallBrave()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Brave.Brave -e";

            if (ChckbxInstallBrave)
                Process.Start(Exe, Arguments);
        }


        // Install Chrome
        private Boolean _chckbxInstallChrome;
        public Boolean ChckbxInstallChrome
        {
            get => _chckbxInstallChrome;
            set
            {
                if (_chckbxInstallChrome == value)
                    return;

                _chckbxInstallChrome = value;
                OnPropertyChanged(nameof(ChckbxInstallChrome));
                InstallChrome();
            }
        }
        public void InstallChrome()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Google.Chrome -e";

            if (ChckbxInstallChrome)
                Process.Start(Exe, Arguments);
        }


        // Install FireFox
        private Boolean _chckbxInstallFirefox;
        public Boolean ChckbxInstallFirefox
        {
            get => _chckbxInstallFirefox;
            set
            {
                if (_chckbxInstallFirefox == value)
                    return;

                _chckbxInstallFirefox = value;
                OnPropertyChanged(nameof(ChckbxInstallFirefox));
                InstallFirefox();
            }
        }
        public void InstallFirefox()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Mozilla.Firefox -e";
            string Addon1 = "/C \"%PROGRAMFILES%\\Mozilla Firefox\\firefox.exe\" https://addons.mozilla.org/en-US/firefox/addon/ublock-origin/";

            if (ChckbxInstallFirefox)
            {
                Process.Start(Exe, Arguments).WaitForExit(500000);
                Process.Start(Exe, Addon1);
            }
        }


        // Install Opera
        private Boolean _chckbxInstallOpera;
        public Boolean ChckbxInstallOpera
        {
            get => _chckbxInstallOpera;
            set
            {
                if (_chckbxInstallOpera == value)
                    return;

                _chckbxInstallOpera = value;
                OnPropertyChanged(nameof(ChckbxInstallOpera));
                InstallOpera();
            }
        }
        public void InstallOpera()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Opera.Opera -e";

            if (ChckbxInstallOpera)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Compression


        // Install 7 Zip
        private Boolean _chckbxInstall7Zip;
        public Boolean ChckbxInstall7Zip
        {
            get => _chckbxInstall7Zip;
            set
            {
                if (_chckbxInstall7Zip == value)
                    return;

                _chckbxInstall7Zip = value;
                OnPropertyChanged(nameof(ChckbxInstall7Zip));
                Install7Zip();
            }
        }
        public void Install7Zip()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=7zip.7zip -e";

            if (ChckbxInstall7Zip)
                Process.Start(Exe, Arguments);
        }


        // Install WinRAR
        private Boolean _chckbxInstallWinRAR;
        public Boolean ChckbxInstallWinRAR
        {
            get => _chckbxInstallWinRAR;
            set
            {
                if (_chckbxInstallWinRAR == value)
                    return;

                _chckbxInstallWinRAR = value;
                OnPropertyChanged(nameof(ChckbxInstallWinRAR));
                InstallWinRAR();
            }
        }
        public void InstallWinRAR()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=RARLab.WinRAR -e";

            if (ChckbxInstallWinRAR)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Editors



        // Install Notepad++
        private Boolean _chckbxInstallNotepadPlusPlus;
        public Boolean ChckbxInstallNotepadPlusPlus
        {
            get => _chckbxInstallNotepadPlusPlus;
            set
            {
                if (_chckbxInstallNotepadPlusPlus == value)
                    return;

                _chckbxInstallNotepadPlusPlus = value;
                OnPropertyChanged(nameof(ChckbxInstallNotepadPlusPlus));
                InstallNotepadPlusPlus();
            }
        }
        public void InstallNotepadPlusPlus()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Notepad++.Notepad++ -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Notepad++.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallNotepadPlusPlus)
            {
                Process.Start(Exe, Arguments).WaitForExit(50000);
                Process.Start(Exe, Arguments2);
            }
        }



        #endregion

        #region Entertainment



        // Install Dopamine
        private Boolean _chckbxInstallDopamine;
        public Boolean ChckbxInstallDopamine
        {
            get => _chckbxInstallDopamine;
            set
            {
                if (_chckbxInstallDopamine == value)
                    return;

                _chckbxInstallDopamine = value;
                OnPropertyChanged(nameof(ChckbxInstallDopamine));
                InstallDopamine();
            }
        }
        public void InstallDopamine()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Digimezzo.Dopamine -e";

            if (ChckbxInstallDopamine)
                Process.Start(Exe, Arguments);
        }


        // Install VLC
        private Boolean _chckbxInstallVLC;
        public Boolean ChckbxInstallVLC
        {
            get => _chckbxInstallVLC;
            set
            {
                if (_chckbxInstallVLC == value)
                    return;

                _chckbxInstallVLC = value;
                OnPropertyChanged(nameof(ChckbxInstallVLC));
                InstallVLC();
            }
        }
        public void InstallVLC()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=VideoLAN.VLC -e";

            if (ChckbxInstallVLC)
                Process.Start(Exe, Arguments);
        }


        // Install Winamp
        private Boolean _chckbxInstallWinamp;
        public Boolean ChckbxInstallWinamp
        {
            get => _chckbxInstallWinamp;
            set
            {
                if (_chckbxInstallWinamp == value)
                    return;

                _chckbxInstallWinamp = value;
                OnPropertyChanged(nameof(ChckbxInstallWinamp));
                InstallWinamp();
            }
        }
        public void InstallWinamp()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Winamp.Winamp -e";

            if (ChckbxInstallWinamp)
                Process.Start(Exe, Arguments);
        }



        #endregion



        #region Game Clients

                
        // Install EA App
        private Boolean _chckbxInstallEAApp;
        public Boolean ChckbxInstallEAApp
        {
            get => _chckbxInstallEAApp;
            set
            {
                if (_chckbxInstallEAApp == value)
                    return;

                _chckbxInstallEAApp = value;
                OnPropertyChanged(nameof(ChckbxInstallEAApp));
                InstallEAApp();
            }
        }
        public void InstallEAApp()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=ElectronicArts.EADesktop  -e";

            if (ChckbxInstallEAApp)
                Process.Start(Exe, Arguments);
        }


        // Install Epic Game Client
        private Boolean _chckbxInstallEpic;
        public Boolean ChckbxInstallEpic
        {
            get => _chckbxInstallEpic;
            set
            {
                if (_chckbxInstallEpic == value)
                    return;

                _chckbxInstallEpic = value;
                OnPropertyChanged(nameof(ChckbxInstallEpic));
                InstallEpic();
            }
        }
        public void InstallEpic()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=EpicGames.EpicGamesLauncher -e";

            if (ChckbxInstallEpic)
                Process.Start(Exe, Arguments);
        }


        // Install GOG Galaxy
        private Boolean _chckbxInstallGOGGalaxy;
        public Boolean ChckbxInstallGOGGalaxy
        {
            get => _chckbxInstallGOGGalaxy;
            set
            {
                if (_chckbxInstallGOGGalaxy == value)
                    return;

                _chckbxInstallGOGGalaxy = value;
                OnPropertyChanged(nameof(ChckbxInstallGOGGalaxy));
                InstallGOGGalaxy();
            }
        }
        public void InstallGOGGalaxy()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=GOG.Galaxy -e";

            if (ChckbxInstallGOGGalaxy)
                Process.Start(Exe, Arguments);
        }


        // Install Minecraft Launcher
        private Boolean _chckbxInstallMinecraftLauncher;
        public Boolean ChckbxInstallMinecraftLauncher
        {
            get => _chckbxInstallMinecraftLauncher;
            set
            {
                if (_chckbxInstallMinecraftLauncher == value)
                    return;

                _chckbxInstallMinecraftLauncher = value;
                OnPropertyChanged(nameof(ChckbxInstallMinecraftLauncher));
                InstallMinecraftLauncher();
            }
        }
        public void InstallMinecraftLauncher()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Mojang.MinecraftLauncher  -e";

            if (ChckbxInstallMinecraftLauncher)
                Process.Start(Exe, Arguments);
                
        }


        // Install Steam
        private Boolean _chckbxInstallSteam;
        public Boolean ChckbxInstallSteam
        {
            get => _chckbxInstallSteam;
            set
            {
                if (_chckbxInstallSteam == value)
                    return;

                _chckbxInstallSteam = value;
                OnPropertyChanged(nameof(ChckbxInstallSteam));
                InstallSteam();
            }
        }
        public void InstallSteam()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Valve.Steam -e";

            if (ChckbxInstallSteam)
                Process.Start(Exe, Arguments);
        }


        // Install Ubisoft Connect
        private Boolean _chckbxInstallUbisoft;
        public Boolean ChckbxInstallUbisoft
        {
            get => _chckbxInstallUbisoft;
            set
            {
                if (_chckbxInstallUbisoft == value)
                    return;

                _chckbxInstallUbisoft = value;
                OnPropertyChanged(nameof(ChckbxInstallUbisoft));
                InstallUbisoft();
            }
        }
        public void InstallUbisoft()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Ubisoft.Connect -e";

            if (ChckbxInstallUbisoft)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Graphics


        // Install GIMP
        private Boolean _chckbxInstallGIMP;
        public Boolean ChckbxInstallGIMP
        {
            get => _chckbxInstallGIMP;
            set
            {
                if (_chckbxInstallGIMP == value)
                    return;

                _chckbxInstallGIMP = value;
                OnPropertyChanged(nameof(ChckbxInstallGIMP));
                InstallGIMP();
            }
        }
        public void InstallGIMP()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=GIMP.GIMP -e";
            string Arguments2 = "/C copy \"C:\\Users\\%username%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\GIMP 2.10.32.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallGIMP)
                Process.Start(Exe, Arguments).WaitForExit(500000);
                Process.Start(Exe, Arguments2);
        }


        // Install IrfanView
        private Boolean _chckbxInstallIrfanView;
        public Boolean ChckbxInstallIrfanView
        {
            get => _chckbxInstallIrfanView;
            set
            {
                if (_chckbxInstallIrfanView == value)
                    return;

                _chckbxInstallIrfanView = value;
                OnPropertyChanged(nameof(ChckbxInstallIrfanView));
                InstallIrfanView();
            }
        }

        public void InstallIrfanView()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=IrfanSkiljan.IrfanView -e";

            if (ChckbxInstallIrfanView)
                Process.Start(Exe, Arguments);
        }


        #endregion

        #region Imaging


        // Install ImgBurn !

        private Boolean _chckbxInstallImgBurn;
        public Boolean ChckbxInstallImgBurn
        {
            get => _chckbxInstallImgBurn;
            set
            {
                if (_chckbxInstallImgBurn == value)
                    return;

                _chckbxInstallImgBurn = value;
                OnPropertyChanged(nameof(ChckbxInstallImgBurn));
                InstallImgBurn();
            }
        }

        public void InstallImgBurn()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=LIGHTNINGUK.ImgBurn  -e";

            if (ChckbxInstallImgBurn)
                Process.Start(Exe, Arguments);
        }


        // Install Rufus

        private Boolean _chckbxInstallRufus;
        public Boolean ChckbxInstallRufus
        {
            get => _chckbxInstallRufus;
            set
            {
                if (_chckbxInstallRufus == value)
                    return;

                _chckbxInstallRufus = value;
                OnPropertyChanged(nameof(ChckbxInstallRufus));
                InstallRufus();
            }
        }

        public void InstallRufus()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Rufus.Rufus -e";

            Process.Start(Exe, Arguments);
        }


        #endregion  

        #region Office


        // Install Libre Office
        private Boolean _chckbxInstallLibreOffice;
        public Boolean ChckbxInstallLibreOffice
        {
            get => _chckbxInstallLibreOffice;
            set
            {
                if (_chckbxInstallLibreOffice == value)
                    return;

                _chckbxInstallLibreOffice = value;
                OnPropertyChanged(nameof(ChckbxInstallLibreOffice));
                InstallLibreOffice();
            }
        }
        public void InstallLibreOffice()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=TheDocumentFoundation.LibreOffice -e";

            if (ChckbxInstallLibreOffice)
                Process.Start(Exe, Arguments);
        }



        #endregion



        #region Readers


        // Install iNFekt NFO Viewer
        private Boolean _chckbxInstalliNFektNFOViewer;
        public Boolean ChckbxInstalliNFektNFOViewer
        {
            get => _chckbxInstalliNFektNFOViewer;
            set
            {
                if (_chckbxInstalliNFektNFOViewer == value)
                    return;

                _chckbxInstalliNFektNFOViewer = value;
                OnPropertyChanged(nameof(ChckbxInstalliNFektNFOViewer));
                InstalliNFektNFOViewer();
            }
        }
        public void InstalliNFektNFOViewer()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=syndicode.iNFektNFOViewer -e";

            if (ChckbxInstalliNFektNFOViewer)
                Process.Start(Exe, Arguments);
        }


        #endregion

        #region Remote Management


        // Install Putty
        private Boolean _chckbxInstallPutty;
        public Boolean ChckbxInstallPutty
        {
            get => _chckbxInstallPutty;
            set
            {
                if (_chckbxInstallPutty == value)
                    return;

                _chckbxInstallPutty = value;
                OnPropertyChanged(nameof(ChckbxInstallPutty));
                InstallPutty();
            }
        }
        public void InstallPutty()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=PuTTY.PuTTY -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\PuTTY (64-bit)\\PuTTY.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallPutty)
                Process.Start(Exe, Arguments).WaitForExit(50000);
                Process.Start(Exe, Arguments2);
        }


        // Install TeamViewer
        private Boolean _chckbxInstallTeamViewer;
        public Boolean ChckbxInstallTeamViewer
        {
            get => _chckbxInstallTeamViewer;
            set
            {
                if (_chckbxInstallTeamViewer == value)
                    return;

                _chckbxInstallTeamViewer = value;
                OnPropertyChanged(nameof(ChckbxInstallTeamViewer));
                InstallTeamViewer();
            }
        }
        public void InstallTeamViewer()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=TeamViewer.TeamViewer -e";

            if (ChckbxInstallTeamViewer)
                Process.Start(Exe, Arguments);
        }


        // Install WinSCP
        private Boolean _chckbxInstallWinSCP;
        public Boolean ChckbxInstallWinSCP
        {
            get => _chckbxInstallWinSCP;
            set
            {
                if (_chckbxInstallWinSCP == value)
                    return;

                _chckbxInstallWinSCP = value;
                OnPropertyChanged(nameof(ChckbxInstallWinSCP));
                InstallWinSCP();
            }
        }
        public void InstallWinSCP()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=WinSCP.WinSCP -e";

            if (ChckbxInstallWinSCP)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Streaming


        // Install OBS Studio
        private Boolean _chckbxInstallOBSStudio;
        public Boolean ChckbxInstallOBSStudio
        {
            get => _chckbxInstallOBSStudio;
            set
            {
                if (_chckbxInstallOBSStudio == value)
                    return;

                _chckbxInstallOBSStudio = value;
                OnPropertyChanged(nameof(ChckbxInstallOBSStudio));
                InstallOBSStudio();
            }
        }
        public void InstallOBSStudio()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=OBSProject.OBSStudio -e";

            if (ChckbxInstallOBSStudio)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Voice Chat


        // Install Discord
        private Boolean _chckbxInstallDiscord;
        public Boolean ChckbxInstallDiscord
        {
            get => _chckbxInstallDiscord;
            set
            {
                if (_chckbxInstallDiscord == value)
                    return;

                _chckbxInstallDiscord = value;
                OnPropertyChanged(nameof(ChckbxInstallDiscord));
                InstallDiscord();
            }
        }
        public void InstallDiscord()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Discord.Discord -e";

            if (ChckbxInstallDiscord)
                Process.Start(Exe, Arguments);
        }


        // Install Element
        private Boolean _chckbxInstallElement;
        public Boolean ChckbxInstallElement
        {
            get => _chckbxInstallElement;
            set
            {
                if (_chckbxInstallElement == value)
                    return;

                _chckbxInstallElement = value;
                OnPropertyChanged(nameof(ChckbxInstallElement));
                InstallElement();
            }
        }
        public void InstallElement()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Element.Element -e";

            if (ChckbxInstallElement)
                Process.Start(Exe, Arguments);
        }


        // Install Guilded
        private Boolean _chckbxInstallGuilded;
        public Boolean ChckbxInstallGuilded
        {
            get => _chckbxInstallGuilded;
            set
            {
                if (_chckbxInstallGuilded == value)
                    return;

                _chckbxInstallGuilded = value;
                OnPropertyChanged(nameof(ChckbxInstallGuilded));
                InstallGuilded();
            }
        }
        public void InstallGuilded()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Guilded.Guilded -e";

            if (ChckbxInstallGuilded)
                Process.Start(Exe, Arguments);
        }


        // Install Team Speak
        private Boolean _chckbxInstallTeamSpeak;
        public Boolean ChckbxInstallTeamSpeak
        {
            get => _chckbxInstallTeamSpeak;
            set
            {
                if (_chckbxInstallTeamSpeak == value)
                    return;

                _chckbxInstallTeamSpeak = value;
                OnPropertyChanged(nameof(ChckbxInstallTeamSpeak));
                InstallTeamSpeak();
            }
        }
        public void InstallTeamSpeak()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=TeamSpeakSystems.TeamSpeakClient -e";

            if (ChckbxInstallTeamSpeak)
                Process.Start(Exe, Arguments);
        }



        #endregion



        #region Work


        // Install Microsoft Teams
        private Boolean _chckbxInstallMicrosoftTeams;
        public Boolean ChckbxInstallMicrosoftTeams
        {
            get => _chckbxInstallMicrosoftTeams;
            set
            {
                if (_chckbxInstallMicrosoftTeams == value)
                    return;

                _chckbxInstallMicrosoftTeams = value;
                OnPropertyChanged(nameof(ChckbxInstallMicrosoftTeams));
                InstallMicrosoftTeams();
            }
        }

        public void InstallMicrosoftTeams()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.Teams -e";

            if (ChckbxInstallMicrosoftTeams)
                Process.Start(Exe, Arguments);
        }


        // Install Horizon Client
        private Boolean _chckbxInstallHorizonClient;
        public Boolean ChckbxInstallHorizonClient
        {
            get => _chckbxInstallHorizonClient;
            set
            {
                if (_chckbxInstallHorizonClient == value)
                    return;

                _chckbxInstallHorizonClient = value;
                OnPropertyChanged(nameof(ChckbxInstallHorizonClient));
                InstallHorizonClient();
            }
        }
        public void InstallHorizonClient()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=VMware.HorizonClient -e";

            if (ChckbxInstallHorizonClient)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Xtra Audio Tools


        // Install Audacity
        private Boolean _chckbxInstallAudacity;
        public Boolean ChckbxInstallAudacity
        {
            get => _chckbxInstallAudacity;
            set
            {
                if (_chckbxInstallAudacity == value)
                    return;

                _chckbxInstallAudacity = value;
                OnPropertyChanged(nameof(ChckbxInstallAudacity));
                InstallAudacity();
            }
        }
        public void InstallAudacity()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Audacity.Audacity -e";

            if (ChckbxInstallAudacity)
                Process.Start(Exe, Arguments);
        }


        // Install Voicemeeter Potato
        private Boolean _chckbxInstallVoicemeeterPotato;
        public Boolean ChckbxInstallVoicemeeterPotato
        {
            get => _chckbxInstallVoicemeeterPotato;
            set
            {
                if (_chckbxInstallVoicemeeterPotato == value)
                    return;

                _chckbxInstallVoicemeeterPotato = value;
                OnPropertyChanged(nameof(ChckbxInstallVoicemeeterPotato));
                InstallVoicemeeterPotato();
            }
        }
        public void InstallVoicemeeterPotato()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=VB-Audio.Voicemeeter.Potato -e";

            if (ChckbxInstallVoicemeeterPotato)
                Process.Start(Exe, Arguments);
        }



        #endregion

        #region Xtra Video Tools


        // Install FileBot
        private Boolean _chckbxInstallFileBot;
        public Boolean ChckbxInstallFileBot
        {
            get => _chckbxInstallFileBot;
            set
            {
                if (_chckbxInstallFileBot == value)
                    return;

                _chckbxInstallFileBot = value;
                OnPropertyChanged(nameof(ChckbxInstallFileBot));
                InstallFileBot();
            }
        }
        public void InstallFileBot()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=PointPlanck.FileBot -e";

            if (ChckbxInstallFileBot)
                Process.Start(Exe, Arguments);
        }


        // Install Handbrake
        private Boolean _chckbxInstallHandbrake;
        public Boolean ChckbxInstallHandbrake
        {
            get => _chckbxInstallHandbrake;
            set
            {
                if (_chckbxInstallHandbrake == value)
                    return;

                _chckbxInstallHandbrake = value;
                OnPropertyChanged(nameof(ChckbxInstallHandbrake));
                InstallHandbrake();
            }
        }
        public void InstallHandbrake()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=HandBrake.HandBrake -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\HandBrake\\HandBrake.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallHandbrake)
                Process.Start(Exe, Arguments).WaitForExit(50000);
                Process.Start(Exe, Arguments2);
        }


        // Install MKVToolNix
        private Boolean _chckbxInstallMKVToolNix;
        public Boolean ChckbxInstallMKVToolNix
        {
            get => _chckbxInstallMKVToolNix;
            set
            {
                if (_chckbxInstallMKVToolNix == value)
                    return;

                _chckbxInstallMKVToolNix = value;
                OnPropertyChanged(nameof(ChckbxInstallMKVToolNix));
                InstallMKVToolNix();
            }
        }
        public void InstallMKVToolNix()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=MKVToolNix.MKVToolNix -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\MKVToolNix\\MKVToolNix GUI.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallMKVToolNix)
                Process.Start(Exe, Arguments).WaitForExit(50000);
                Process.Start(Exe, Arguments2);
        }


        // Install Rename My TV Series
        private Boolean _chckbxInstallRenameMyTVSeries;
        public Boolean ChckbxInstallRenameMyTVSeries
        {
            get => _chckbxInstallRenameMyTVSeries;
            set
            {
                if (_chckbxInstallRenameMyTVSeries == value)
                    return;

                _chckbxInstallRenameMyTVSeries = value;
                OnPropertyChanged(nameof(ChckbxInstallRenameMyTVSeries));
                InstallRenameMyTVSeries();
            }
        }
        public void InstallRenameMyTVSeries()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Tweaking4All.RenameMyTVSeries -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Rename My TV Series\\Rename My TV Series.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";

            if (ChckbxInstallRenameMyTVSeries)
                Process.Start(Exe, Arguments).WaitForExit(500000);
                Process.Start(Exe, Arguments2);
        }



        #endregion

        #region Xtra Developer Tools


        // Install Oracle VM VirtualBox
        private Boolean _chckbxInstallOracleVMVirtualBox;
        public Boolean ChckbxInstallOracleVMVirtualBox
        {
            get => _chckbxInstallOracleVMVirtualBox;
            set
            {
                if (_chckbxInstallOracleVMVirtualBox == value)
                    return;

                _chckbxInstallOracleVMVirtualBox = value;
                OnPropertyChanged(nameof(ChckbxInstallOracleVMVirtualBox));
                InstallOracleVMVirtualBox();
            }
        }
        public void InstallOracleVMVirtualBox()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Oracle.VirtualBox  -e";

            if (ChckbxInstallOracleVMVirtualBox)
                Process.Start(Exe, Arguments);
        }



        // Install Visual Studio 2022 Community
        private Boolean _chckbxInstallVisualStudio2022Community;
        public Boolean ChckbxInstallVisualStudio2022Community
        {
            get => _chckbxInstallVisualStudio2022Community;
            set
            {
                if (_chckbxInstallVisualStudio2022Community == value)
                    return;

                _chckbxInstallVisualStudio2022Community = value;
                OnPropertyChanged(nameof(ChckbxInstallVisualStudio2022Community));
                InstallVisualStudio2022Community();
            }
        }
        public void InstallVisualStudio2022Community()
        {
            string Exe = "cmd.exe";
            string Arguments = "/C winget install --id=Microsoft.VisualStudio.2022.Community -e";
            string Arguments2 = "/C copy \"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Visual Studio 2022.lnk\" \"C:\\Users\\%username%\\Desktop\\\"";


            if (ChckbxInstallVisualStudio2022Community)
                Process.Start(Exe, Arguments).WaitForExit(500000);
                Process.Start(Exe, Arguments2);
        }



        #endregion

    }
}
