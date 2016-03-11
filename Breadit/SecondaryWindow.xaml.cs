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
        WebViewerModel m_model = null;
        private string url;
        private SecondaryWindow win;

        public SecondaryWindow(string url)
        {
            InitializeComponent();
            // m_model = the data model (A big catch-all for all of the data)
            m_model = new WebViewerModel(url);
            // Model = Data Model, Just a model for your contained data. Use this Data Model
            DataContext = m_model;

            BrowserActions();
        }

        public SecondaryWindow(string url, SecondaryWindow win)
        {
            this.url = url;
            this.win = win;
        }

        // Navigates the browser to the URL from MainWIndow
        public void BrowserActions()
        {
            // Browsing with a custom UserAgent (trying to pull mobile sites) **Not sure if it is working**
           // Browser.Navigate(new Uri(url), string.Empty, null, string.Format("User-Agent: {0}", "Mozilla/5.0 (Linux; U; Android 4.0.3; ko-kr; LG-L160L Build/IML74K) AppleWebkit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30"));
            Browser.Navigate(m_model.Url);
        }

        // Returns you to MainWindow and closes this window
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            ReturnToPreviousWindow();
        }

        // Hiding SecondaryWindow works, but Closing it causes the program to crash **Why??
        public void ReturnToPreviousWindow()
        {
            Window main = Application.Current.MainWindow;
            main.Show();
            this.Close();
        }
    }
}
