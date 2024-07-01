using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            // Read the user's selected theme from App setting Data
            string themeString = ApplicationData.Current.LocalSettings.Values["LightDarktheme"] as string;
            ApplicationTheme theme = themeString switch
            {
                "Light" => ApplicationTheme.Light,
                "Dark" => ApplicationTheme.Dark,
                _ => Application.Current.RequestedTheme, // Use the currently applied theme as the default
            };
            Application.Current.RequestedTheme = theme;
        }

        public void setBackground()
        {
            string Background = ApplicationData.Current.LocalSettings.Values["BackgroundMaterial"] as string;

            switch (Background)
            {
                case "Mica":
                    m_window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.Base };
                    break;
                case "Acrylic":
                    m_window.SystemBackdrop = new DesktopAcrylicBackdrop();
                    break;
                case "MicaAlt":
                    m_window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
                    break;
                default:
                    m_window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.Base };
                    break;
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            setBackground();
            m_window.Activate();
        }

        public Window m_window;
    }
}
