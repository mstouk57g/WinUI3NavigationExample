using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            SetThemeOnComboBox();
        }

        private void Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem comboBoxItem && comboBoxItem.Content is string themeString)
            {
                // Save the topics selected by the user to AppData
                ApplicationData.Current.LocalSettings.Values["theme"] = themeString;
            }
        }

        public void SetThemeOnComboBox()
        {
            ApplicationTheme currentTheme = Application.Current.RequestedTheme;
            switch (currentTheme)
            {
                case ApplicationTheme.Dark:
                    this.themeMode.SelectedIndex = 1;
                    break;
                case ApplicationTheme.Light:
                    this.themeMode.SelectedIndex = 0;
                    break;
            }
        }
    }
}
