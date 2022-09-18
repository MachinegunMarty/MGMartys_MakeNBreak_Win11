

using Microsoft.Win32;

using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
/// <summary>
/// Model [ "The Content Creator" ]
/// The model class holds the data. The model can be referred to as the data file for the front-end of the application.
/// </summary>

namespace MGMartys_MakeNBreak_Win11.Model
{

    
  

    


        // Main Menu Items
        public class MenuItems
    {
        public string MenuName { get; set; }
        public string MenuImage { get; set; }
    }

    // Control Panel Items
    public class ControlPanelTabs
    {
        public string ControlPanelHeader { get; set; }
        public string ControlPanelImage { get; set; }
        public string ControlPanelContent { get; set; }
    }

    // Programs - Runtimes
    public class ProgramsRuntimesItems
    {
        public string ProgramsRuntimesName { get; set; }
        public string ProgramsRuntimesImage { get; set; }
    }

    // Programs - Browsers
    public class ProgramsBrowsersItems
    {
        public string ProgramsBrowsersName { get; set; }
        public string ProgramsBrowsersImage { get; set; }
    }


    // Home Page
    public class HomeItems
    {
        public string HomeName { get; set; }
        public string HomeImage { get; set; }
    }

   

    // Personalization Page
    public class PersonalizationItems
    {
        public string PersonalizationName { get; set; }
        public string PersonalizationImage { get; set; }
    }

    // Desktop Page
    public class DesktopItems
    {
        public string DesktopName { get; set; }
        public string DesktopImage { get; set; }
    }


   


}
