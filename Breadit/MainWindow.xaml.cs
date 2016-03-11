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
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        // Creates a new RedditViewerModel object named m_model
        RedditViewerModel m_model = new RedditViewerModel();

        // Create a window and go through the initialization steps
        public MainWindow()
        {
            InitializeComponent();
            // DataContext??
            DataContext = m_model;
            m_model.Initialize();
        }

        // Gets the UserName and Password fron the UI (on button press), 
        // sends them to m_model and refreshes to pull the User's Front Page
        public void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string myPasswod = passwordBox.Password;
            string userName = userNameBox.Text;
            m_model.UserName = userName;
            m_model.Password = myPasswod;
            m_model.Refresh();
        }

        // Not sure why this is here
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // If the left mouse button is clicked, do this stuff
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Checks to see if the sending thing is a lable
            if(sender is Label)
            {
                // Ceates a Label object myLabel
                Label myLabel = (Label)sender;
                // Gets us the post object we just clicked on
                object selectedPost = myLabel.DataContext;

                // If the mabyeAPost is a post, create a new Custom Post, get the URL from it, convert to a string and launch the default browser
                if(selectedPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)selectedPost;

                    string url = myPost.Post.Url.ToString();
                    //Process.Start(url);

                    // Hides MainWindow
                    
                    SecondaryWindow win = new SecondaryWindow(url);
                    win.Show();
                    this.Hide();
                    // Closes MainWindow so SecondaryWindow can close the program when exited
                    //this.Close();
                }
            }
        }

        // Behaviour if the up arrow HAS been clicked and this click removes the vote (Sets it to None Vote)
        private void redditUpArrow_Click(object sender, RoutedEventArgs e)
        {
            // Is it a button that is sent to me?
            if (sender is Button)
            {
                Button myButton = (Button)sender;
                object maybeAPost = myButton.DataContext;

                if (maybeAPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)maybeAPost;
                    myPost.ChangeVote(VotableThing.VoteType.None);
                }
            }
        }

        private void redditNakedUpArrow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button myButton = (Button)sender;
                object maybeAPost = myButton.DataContext;

                if (maybeAPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)maybeAPost;
                    myPost.ChangeVote(VotableThing.VoteType.Upvote);
                }
            }
        }

        private void redditNakedDownArrow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button myButton = (Button)sender;
                object maybeAPost = myButton.DataContext;

                if (maybeAPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)maybeAPost;
                    myPost.ChangeVote(VotableThing.VoteType.Downvote);
                }
            }
        }

        private void redditDownArrow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button myButton = (Button)sender;
                object maybeAPost = myButton.DataContext;

                if (maybeAPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)maybeAPost;
                    myPost.ChangeVote(VotableThing.VoteType.None);
                }
            }
        }

        // Calls the Refresh method, which gets the Front Page again
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            m_model.Refresh();
        }

        private void newWindowButton_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://www.google.ca";
            // Hides MainWindow
            // this.Hide();
            SecondaryWindow win = new SecondaryWindow(url);
            win.Show();
            // Closes MainWindow so SecondaryWindow can close the program when exited
            this.Close();
        }
    }
}
