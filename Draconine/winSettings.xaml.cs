using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Draconine
{
  /// <summary>
  /// Interaction logic for winSettings.xaml
  /// </summary>
  public partial class winSettings : Window
  {
    public winSettings()
    {
      InitializeComponent();
      switch (Properties.Settings.Default.View)
      {
        case "currently":
          radCurrently.IsChecked = true;
          break;
        case "three":
          rad3Day.IsChecked = true;
          break;
        case "eight":
          rad8Day.IsChecked = true;
          break;
      }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      if (radCurrently.IsChecked.Value)
      {
        Properties.Settings.Default.View = "currently";
      } else if (rad3Day.IsChecked.Value)
      {
        Properties.Settings.Default.View = "three";
      } else if (rad8Day.IsChecked.Value)
      {
        Properties.Settings.Default.View = "eight";
      }

      Properties.Settings.Default.Save();
      this.Close();
    }
  }
}
