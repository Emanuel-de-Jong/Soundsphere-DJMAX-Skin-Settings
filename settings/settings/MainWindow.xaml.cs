using System.Windows;
using elements;
using logger;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;

namespace settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Logger.RefreshFile();

            Logger.Add(eMessageType.process, "Initializing components");
            InitializeComponent();
            Logger.Add(eMessageType.completion, "Initialization complete");

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeImages();
        }



        public void InitializeImages()
        {
            Logger.Add(eMessageType.process, "Initializing images");
            imgBg.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["bg"], UriKind.Absolute));
            imgFX1.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["fx1right"], UriKind.Absolute));
            imgFX2.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["fx2right"], UriKind.Absolute));
            Logger.Add(eMessageType.completion, "Initializing images complete");
        }



        public void ComponentsPressed(object sender, RoutedEventArgs e)
        {
            Components.GenerateJSONs(GetComponentsSettings());
        }
        public Dictionary<string, bool> GetComponentsSettings()
        {
            Logger.Add(eMessageType.process, "Getting components settings");
            Dictionary<string, bool> componentsSettings = new Dictionary<string, bool>();

            componentsSettings["vidbg"] = (bool)vidbg.IsChecked;
            componentsSettings["combobg"] = (bool)combobg.IsChecked;
            componentsSettings["beam"] = (bool)beam.IsChecked;
            componentsSettings["combo"] = (bool)combo.IsChecked;
            componentsSettings["progressbar"] = (bool)progressbar.IsChecked;
            componentsSettings["accuracy"] = (bool)accuracy.IsChecked;
            componentsSettings["timegate"] = (bool)timegate.IsChecked;
            componentsSettings["keypressed"] = (bool)keypressed.IsChecked;
            componentsSettings["particles"] = (bool)particles.IsChecked;

            return componentsSettings;
        }
    }
}
