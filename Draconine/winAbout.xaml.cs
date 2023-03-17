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
  /// Interaction logic for winAbout.xaml
  /// </summary>
  public partial class winAbout : Window
  {
    public winAbout()
    {
      InitializeComponent();
    }

    private void lblLink_MouseDown(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("http://kruug.org/draconemsoft");
    }

    private void imgLogo_MouseDown(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start("https://openweathermap.org/");
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      Close();
    }
  }
}
