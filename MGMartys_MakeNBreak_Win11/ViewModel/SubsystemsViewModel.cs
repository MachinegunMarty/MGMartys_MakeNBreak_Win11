using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGMartys_MakeNBreak_Win11.ViewModel
{
    public class SubsystemsViewModel : INotifyPropertyChanged
    {
        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #region Windows Subsystem for Linux


        // Install WSL: Ubuntu (Default)
        private Boolean _chckbxWSLUbuntuDefault;
        public Boolean ChckbxWSLUbuntuDefault
        {
            get => _chckbxWSLUbuntuDefault;
            set
            {
                if (_chckbxWSLUbuntuDefault == value)
                    return;

                _chckbxWSLUbuntuDefault = value;
                OnPropertyChanged(nameof(ChckbxWSLUbuntuDefault));
                WSLUbuntuDefault();
            }
        }
        public void WSLUbuntuDefault()
        {
            string Exe = "wsl.exe";
            string Arguments = "--install -d Ubuntu";

            if (ChckbxWSLUbuntuDefault)
                Process.Start(Exe, Arguments);
        }


        // Install WSL: Debian
        private Boolean _chckbxWSLDebian;
        public Boolean ChckbxWSLDebian
        {
            get => _chckbxWSLDebian;
            set
            {
                if (_chckbxWSLDebian == value)
                    return;

                _chckbxWSLDebian = value;
                OnPropertyChanged(nameof(ChckbxWSLDebian));
                WSLDebian();
            }
        }
        public void WSLDebian()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d Debian";

            if (ChckbxWSLDebian)
                Process.Start(Exe, Arguments);
        }


        // Install WSL: kali-linux
        private Boolean _chckbxWSLkalilinux;
        public Boolean ChckbxWSLkalilinux
        {
            get => _chckbxWSLkalilinux;
            set
            {
                if (_chckbxWSLkalilinux == value)
                    return;

                _chckbxWSLkalilinux = value;
                OnPropertyChanged(nameof(ChckbxWSLkalilinux));
                WSLkalilinux();
            }
        }
        public void WSLkalilinux()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d kali-linux";

            if (ChckbxWSLkalilinux)
                Process.Start(Exe, Arguments);
        }


        // Install WSL: SLES-12
        private Boolean _chckbxWSLSLES12;
        public Boolean ChckbxWSLSLES12
        {
            get => _chckbxWSLSLES12;
            set
            {
                if (_chckbxWSLSLES12 == value)
                    return;

                _chckbxWSLSLES12 = value;
                OnPropertyChanged(nameof(ChckbxWSLSLES12));
                WSLSLES12();
            }
        }
        public void WSLSLES12()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d SLES-12";

            if (ChckbxWSLSLES12)
                Process.Start(Exe, Arguments);
        }


        // Install WSL: SLES-15
        private Boolean _chckbxWSLSLES15;
        public Boolean ChckbxWSLSLES15
        {
            get => _chckbxWSLSLES15;
            set
            {
                if (_chckbxWSLSLES15 == value)
                    return;

                _chckbxWSLSLES15 = value;
                OnPropertyChanged(nameof(ChckbxWSLSLES15));
                WSLSLES15();
            }
        }
        public void WSLSLES15()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d SLES-15";

            if (ChckbxWSLSLES12)
                Process.Start(Exe, Arguments);
        }


        // Install WSL: Ubuntu-18.04
        private Boolean _chckbxWSLUbuntu1804;
        public Boolean ChckbxWSLUbuntu1804
        {
            get => _chckbxWSLUbuntu1804;
            set
            {
                if (_chckbxWSLUbuntu1804 == value)
                    return;

                _chckbxWSLUbuntu1804 = value;
                OnPropertyChanged(nameof(ChckbxWSLUbuntu1804));
                WSLUbuntu1804();
            }
        }
        public void WSLUbuntu1804()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d Ubuntu-18.04";

            if (ChckbxWSLUbuntu1804)
                Process.Start(Exe, Arguments);
        }



        // Install WSL: Ubuntu-20.04
        private Boolean _chckbxWSLUbuntu2004;
        public Boolean ChckbxWSLUbuntu2004
        {
            get => _chckbxWSLUbuntu2004;
            set
            {
                if (_chckbxWSLUbuntu2004 == value)
                    return;

                _chckbxWSLUbuntu2004 = value;
                OnPropertyChanged(nameof(ChckbxWSLUbuntu2004));
                WSLUbuntu2004();
            }
        }
        public void WSLUbuntu2004()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d Ubuntu-20.04";

            if (ChckbxWSLUbuntu1804)
                Process.Start(Exe, Arguments);
        }



        // Install WSL: OracleLinux_8_5
        private Boolean _chckbxWSLOracleLinux85;
        public Boolean ChckbxWSLOracleLinux85
        {
            get => _chckbxWSLOracleLinux85;
            set
            {
                if (_chckbxWSLOracleLinux85 == value)
                    return;

                _chckbxWSLOracleLinux85 = value;
                OnPropertyChanged(nameof(ChckbxWSLOracleLinux85));
                WSLOracleLinux85();
            }
        }
        public void WSLOracleLinux85()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d OracleLinux_8_5";

            if (ChckbxWSLOracleLinux85)
                Process.Start(Exe, Arguments);
        }



        // Install WSL: OracleLinux_7_9
        private Boolean _chckbxWSLOracleLinux79;
        public Boolean ChckbxWSLOracleLinux79
        {
            get => _chckbxWSLOracleLinux79;
            set
            {
                if (_chckbxWSLOracleLinux79 == value)
                    return;

                _chckbxWSLOracleLinux79 = value;
                OnPropertyChanged(nameof(ChckbxWSLOracleLinux79));
                WSLOracleLinux79();
            }
        }
        public void WSLOracleLinux79()
        {
            string Exe = "wsl.exe";
            string Arguments = @"--install -d OracleLinux_7_9";

            if (ChckbxWSLOracleLinux85)
                Process.Start(Exe, Arguments);
        }


        #endregion


    }
}
