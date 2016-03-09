using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;
using System.Windows;

namespace Breadit.Models
{
    public class RedditViewerModel : AsyncModelBase
    {
        // Not sure what this does...
        private string m_label;
        public string Label
        {
            get
            {
                return m_label;
            }

            set
            {
                m_label = value;
                OnPropertyChanged("Label");
            }
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        // Checks to see if the UI is loading and tells xaml to display a loading packman
        private bool m_isLoading = false;
        public bool IsLoading
        {
            get
            {
                return m_isLoading;
            }

            set
            {
                m_isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public readonly ObservableCollection<CustomPost> m_posts = new ObservableCollection<CustomPost>();
        public ObservableCollection<CustomPost> Posts
        {
            get { return m_posts; }
        }

        // Kind of like the main method
        public async void Initialize()
        {
            try
            {
                // If there is no UserName entered (ie. when the program starts), get the default front page
                if (UserName == null)
                {
                    IsLoading = true;
                    var list = await GetFrontPagePostsDefault();
                    IsLoading = false;

                    foreach (var post in list)
                    {
                        Posts.Add(post);
                    }
                }

                else
                {
                    // If there is a UserName (a password is assumed) login and display the user's front page
                    IsLoading = true;
                    var list = await GetFrontPagePosts();
                    IsLoading = false;

                    foreach (var post in list)
                    {
                        Posts.Add(post);
                    }
                }
            }

            // Catch an invalid login error so the program doesn't explode
            catch(System.Security.Authentication.AuthenticationException)
            {
                MessageBox.Show("Invalid User Name or Password, Please try again. \n (Also the program didn't crash and burn, yay!)");
            }
        }

        // Gets the defualt front page of Reddit
        public Task<List<CustomPost>> GetFrontPagePostsDefault()
        {
            return Task.Run(delegate
            {        
                List<CustomPost> myPosts = new List<CustomPost>();
                Reddit reddit = new Reddit();
                Subreddit frontPage = reddit.FrontPage;
                Listing<Post> postList = frontPage.Hot;

                // Gets the first 25 items on the front page and adds them to the myPosts lists
                foreach (Post post in postList.Take(25))
                {
                    myPosts.Add(new CustomPost(post));
                }

                // Returns the list of posts
                return myPosts;
            });
        }

        // Logs the user in and gets their Front Page
        public Task<List<CustomPost>> GetFrontPagePosts()
        {
            return Task.Run(delegate
            {
                List<CustomPost> myPosts = new List<CustomPost>();
                Reddit reddit = new Reddit(UserName, Password, true);
                Subreddit frontPage = reddit.FrontPage;
                Listing<Post> postList = frontPage.Hot;

                // Gets the first 25 items on the front page and adds them to the myPosts lists
                foreach (Post post in postList.Take(25))
                {
                    myPosts.Add(new CustomPost(post));
                }

                // Returns the list of posts
                return myPosts;
            });
        }

        // Clear all of the items in the list and goes through the Initialize method to repopulate
        public void Refresh()
        {
            Posts.Clear();
            Initialize();
        }
    }
}
