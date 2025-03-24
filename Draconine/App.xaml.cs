using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Draconine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            winCurrently currently = new winCurrently();
            win3Day threeDay = new win3Day();
            winAbout about = new winAbout();

            MainWindow = threeDay;
            threeDay.Show();
            /*switch (Draconine.Properties.Settings.Default.ViewSettings)
            {
                case "current":
                    MainWindow = currently;
                    currently.Show();
                    break;
                case "three":
                    MainWindow = threeDay;
                    threeDay.Show();
                    break;
                /*case "eight":
                  eightDay.Show();
                  break;
                default:
                    about.Show();
                    break;
            }*/
        }
    }
}
