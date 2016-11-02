using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draconine
{
  class clsStartup
  {
    private void Application_Startup()
    {
      winCurrently currently = new winCurrently();
      win3Day threeDay = new win3Day();
      winAbout about = new winAbout();

      switch (Properties.Settings.Default.ViewSettings)
      {
        case "current":
          currently.Show();
          break;
        case "three":
          threeDay.Show();
          break;
        /*case "eight":
          eightDay.Show();
          break;*/
        default:
          about.Show();
          break;
      }
    }
  }
}
