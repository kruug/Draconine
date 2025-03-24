using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Draconine
{
  class Program
  {
        public static void Main()
        {
            System.Diagnostics.Debug.WriteLine("Program Started");
            win3Day day3 = new win3Day();
            day3.Show();
            /*winCurrently currently = new winCurrently();
            currently.Show();*/
        }
    /*private void Application_Startup()
    {
      winCurrently currently = new winCurrently();
      win3Day threeDay = new win3Day();

            currently.Show();

      switch (Properties.Settings.Default.ViewSettings)
      {
        case "current":
          currently.Show();
          break;
        case "three":
          threeDay.Show();
          break;
        case "eight":
          eightDay.Show();
          break;
        default:
          currently.Show();
          break;
      }
    }*/
  }
}
