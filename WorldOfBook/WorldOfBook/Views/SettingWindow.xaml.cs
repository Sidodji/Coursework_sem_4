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

namespace WorldOfBook
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : UserControl
    {

        public SolidColorBrush color1 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#111111"));
        public SolidColorBrush color2 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EF5350"));
        public SolidColorBrush color3 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37474F"));

        public SolidColorBrush color11 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#555555"));
        public SolidColorBrush color22 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEBEE"));
        public SolidColorBrush color33 = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECEFF1"));


        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.TopTopGrid.Background = color11;
            MainWindow.mainWindow.GridMenu.Background = color11;
            MainWindow.mainWindow.FirstLetterCircle.Background = color11;
            MainWindow.mainWindow.ContentGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#999999"));
            MainWindow.mainWindow.TopInfoGrid.Background = color1;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.TopTopGrid.Background = color2;
            MainWindow.mainWindow.GridMenu.Background = color2;
            MainWindow.mainWindow.ContentGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECEFF1"));
            MainWindow.mainWindow.FirstLetterCircle.Background = color2;
            MainWindow.mainWindow.TopInfoGrid.Background = color22;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.TopTopGrid.Background = color3;
            MainWindow.mainWindow.GridMenu.Background = color3;
            MainWindow.mainWindow.ContentGrid.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECEFF1"));
            MainWindow.mainWindow.FirstLetterCircle.Background = color2;
            MainWindow.mainWindow.TopInfoGrid.Background = color33;
        }


    }
}


