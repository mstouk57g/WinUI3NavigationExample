using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using WinUI3NavigationExample;

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
            this.Loaded += (s, e) => { this.IsPageLoaded = true; };
            SetOnComboBox();
        }
        public bool IsPageLoaded { get; set; }


        private void Themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem comboBoxItem && comboBoxItem.Content is string LightDarktheme)
            {
                // Save the topics selected by the user to AppData
                ApplicationData.Current.LocalSettings.Values["LightDarktheme"] = LightDarktheme;
            }
        }

        public void SetOnComboBox()
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

            string Background = ApplicationData.Current.LocalSettings.Values["BackgroundMaterial"] as string;
            switch (Background)
            {
                case "Mica":
                    this.BackgroundMode.SelectedIndex = 0;
                    break;
                case "Acrylic":
                    this.BackgroundMode.SelectedIndex = 2;
                    break;
                case "MicaAlt":
                    this.BackgroundMode.SelectedIndex = 1;
                    break;
                default:
                    this.BackgroundMode.SelectedIndex = 0;
                    break;
            }

        }

        private void MaterialsChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem comboBoxItem && comboBoxItem.Content is string BackgroundMaterial)
            {
                ApplicationData.Current.LocalSettings.Values["BackgroundMaterial"] = BackgroundMaterial;

                var app = (App)Application.Current;
                var window = app.m_window;

                if (!this.IsPageLoaded) return;
                {
                    Trace.WriteLine(BackgroundMaterial);

                    switch (BackgroundMaterial)
                    {
                        case "Mica":
                            window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.Base };
                            break;
                        case "Acrylic":
                            window.SystemBackdrop = new DesktopAcrylicBackdrop();
                            break;
                        case "MicaAlt":
                            window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
                            break;
                        default:
                            window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.Base };
                            break;
                    }
                }
            }
        }

    }
}
