using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

/*
//UNDONE: Mudar tema dinamicamente conforme sistema 

namespace Utils
{
  public static class Ui
  {
    public static bool IsDarkTheme()
    {
      return !IsLightTheme();
    }

    public static bool IsLightTheme()
    {
      using var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
      var value = key?.GetValue("AppsUseLightTheme");
      return value is int i && i > 0;
    }

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
    private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

    private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled = true)
    {
      if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 17763))
      {
        var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
        if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 18985))
        {
          attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
        }

        int useImmersiveDarkMode = enabled ? 1 : 0;
        return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
      }

      return false;
    }
  }
}
*/

namespace DevTools
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private int Selected = -1;
    private string Caption;

    public MainWindow()
    {
      InitializeComponent();

      Caption = Title;
      Top = 0;
      Left = SystemParameters.WorkArea.Width - Width;
      Height = SystemParameters.WorkArea.Height;

      this.Grid.Height = Height - 64;

      lbx1.Visibility = Visibility.Hidden;
      lbx2.Visibility = Visibility.Hidden;

      txtId.Focus();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      //UNDONE: Mudar tema dinamicamente conforme sistema 
      //if (Utils.Ui.IsDarkTheme()) Utils.Ui.ApplyDarkTheme(this, this.Grid.Children);
    }

    private void txtId_Preview(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^0-9]+");
      e.Handled = regex.IsMatch(e.Text);
    }

    private void txtId_TextChanged(object sender, TextChangedEventArgs e)
    {
      txtId.Text = Regex.Replace(txtId.Text, "[^0-9]", "");
      int id = 0;
      btnOk.IsEnabled = int.TryParse(txtId.Text, out id) && id > 0;
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
      int id = 0;
      if (!int.TryParse(txtId.Text, out id))
        return;

      WorkItemType type = (radFeature.IsChecked ?? false) ? WorkItemType.Feature : WorkItemType.Fix;

      GitCommands commands = SvcGit.Run(id, type);

      lbx1.ItemsSource = commands.Commands1;
      lbx1.Visibility = Visibility.Visible;

      lbx2.ItemsSource = commands.Commands2;
      lbx2.Visibility = Visibility.Visible;
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var list = (ListBox)sender;
      var item = list.SelectedItem?.ToString() ?? "";
      if (item.Length == 0)
      {
        list.SelectedItem = null;
        return;
      }

      Title = Caption;
      Title = Caption + " - " + item;
      System.Windows.Clipboard.SetText(item + "\r\n");
    }

  }
}