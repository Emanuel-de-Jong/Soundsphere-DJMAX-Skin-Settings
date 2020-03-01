using System.Windows;
using elements;
using logger;
using System.Windows.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

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

            //InitializeImages();
        }

        //public void InitializeImages()
        //{
        //    Logger.Add(eMessageType.process, "Initializing images");
        //    imgBg.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["bg"], UriKind.Absolute));
        //    imgFX1.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["fx1right"], UriKind.Absolute));
        //    imgFX2.Source = new BitmapImage(new Uri(Info.absolutePath + "\\" + Info.files["fx2right"], UriKind.Absolute));
        //    Logger.Add(eMessageType.completion, "Initializing images complete");
        //}

        public void ComponentsPressed(object sender, RoutedEventArgs e)
        {
            Components.GenerateJSONs(GetComponentsSettings());
        }

        public Dictionary<string, bool> GetComponentsSettings()
        {
            Logger.Add(eMessageType.process, "Getting components settings");
            Dictionary<string, bool> componentsSettings = new Dictionary<string, bool>
            {
                ["novidbg"] = (bool)novidbg.IsChecked,
                ["combobg"] = (bool)combobg.IsChecked,
                ["beam"] = (bool)beam.IsChecked,
                ["combo"] = (bool)combo.IsChecked,
                ["progressbar"] = (bool)progressbar.IsChecked,
                ["accuracy"] = (bool)accuracy.IsChecked,
                ["timegate"] = (bool)timegate.IsChecked,
                ["keypressed"] = (bool)keypressed.IsChecked,
                ["particles"] = (bool)particles.IsChecked
            };

            return componentsSettings;
        }
        private void ComponentsPositionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            double cs = 0;
            double csMiddle = 0.5;

            double left = -0.320;
            double right = 0.325;

            string position = (e.AddedItems[0] as ComboBoxItem).Content as string;

            switch (position)
            {
                case "Left":
                    Info.cs[0] = cs + left;
                    Info.csMiddle[0] = csMiddle + left;
                    imgPosition.Source = new BitmapImage(new Uri("Images/Components/positionLeft.png", UriKind.Relative));
                    break;
                case "Middle":
                    Info.cs[0] = cs;
                    Info.csMiddle[0] = csMiddle;
                    imgPosition.Source = new BitmapImage(new Uri("Images/Components/positionMiddle.png", UriKind.Relative));
                    break;
                case "Right":
                    Info.cs[0] = cs + right;
                    Info.csMiddle[0] = csMiddle + right;
                    imgPosition.Source = new BitmapImage(new Uri("Images/Components/positionRight.png", UriKind.Relative));
                    break;
            }
        }
    }
}
