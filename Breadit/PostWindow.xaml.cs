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
    /// Interaction logic for PostWindow.xaml
    /// </summary>
    public partial class PostWindow : Window
    {
        PostDataModel m_model = null;

        public PostWindow(CustomPost openedPost)
        {
            InitializeComponent();
            // m_model = the data model (A big catch-all for all of the data)
            m_model = new PostDataModel(openedPost);
            // Model = Data Model, Just a model for your contained data. Use this Data Model
            DataContext = m_model;

            m_model.Initialize();
            
            BrowserActions();
        }

        // Navigates the browser to the URL from MainWIndow
        public void BrowserActions()
        {
           // Browsing to the URL from the OpenedPost **Don't know how to make it a custom UserAgent so it will pull mobile pages
           Browser.Navigate(m_model.OpenedPost.Post.Url);
        }

        // Returns you to MainWindow and closes this window
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            ReturnToPreviousWindow();
        }

        // Hiding PostWindow works, but Closing it causes the program to crash **Why??
        public void ReturnToPreviousWindow()
        {
            Window main = Application.Current.MainWindow;
            main.Show();
            this.Close();
        }
    }
}
