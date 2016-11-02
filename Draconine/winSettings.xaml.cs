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
      switch (Properties.Settings.Default.ViewSettings)
      {
        case "current":
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
        Properties.Settings.Default.ViewSettings = "current";
      } else if (rad3Day.IsChecked.Value)
      {
        Properties.Settings.Default.ViewSettings = "three";
      } else if (rad8Day.IsChecked.Value)
      {
        Properties.Settings.Default.ViewSettings = "eight";
      }

      Properties.Settings.Default.Save();
      
      MessageBox.Show("Your settings have been saved." + Environment.NewLine + "Changes will be applied upon restart.", "Settings Saved", MessageBoxButton.OK, MessageBoxImage.Information);

      this.Close();
    }
  }
}
