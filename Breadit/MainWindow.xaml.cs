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
        RedditViewerModel m_model = new RedditViewerModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = m_model;
            m_model.Initialize();
        }

        // The random useless button that changes a label to a different string
        private void button_Click(object sender, RoutedEventArgs e)
        {
            m_model.Label = "Butt Secks";
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // If the left mouse button is clicked, do this stuff
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Checks to see if the sending thing is a lable
            if(sender is Label)
            {
                // If it is, create a new lable and get the dara from it
                Label myLabel = (Label)sender;
                object maybeAPost = myLabel.DataContext;

                // If the mabyeAPost is a post, create a new Custom Post, get the URL from it, convert to a string and launch the default browser
                if(maybeAPost is CustomPost)
                {
                    CustomPost myPost = (CustomPost)maybeAPost;
                    string url = myPost.Post.Url.ToString();
                    Process.Start(url);
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
    }
}
