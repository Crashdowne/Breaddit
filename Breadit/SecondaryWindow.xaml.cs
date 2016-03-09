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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using RedditSharp;
using RedditSharp.Things;

namespace Breadit
{
    using Models;
    using Converters;
    /// <summary>
    /// Interaction logic for SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        // Takes in the URL from MainWindow
        private string url;

        public SecondaryWindow(string url)
        {
            InitializeComponent();
            this.url = url;
            BrowserActions();
        }

        // Navigates the browser to the URL from MainWIndow
        public void BrowserActions()
        {
            Browser.Navigate(url);
        }

        // Returns you to MainWindow and closes this window
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            mainWindow.Show();
            this.Close();
        }
    }
}
