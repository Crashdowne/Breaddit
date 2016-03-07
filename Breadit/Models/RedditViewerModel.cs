using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;

namespace Breadit.Models
{
    public class RedditViewerModel : AsyncModelBase
    {
        private string m_label = "Hello World";
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
            IsLoading = true;
            var list = await GetFrontPagePosts();
            IsLoading = false;

            foreach(var post in list)
            {
                Posts.Add(post);
            }
        }

        // Gets the front page of Reddit, using a hard-coded user
        public Task<List<CustomPost>> GetFrontPagePosts()
        {
            return Task.Run(delegate
            {
                // Creates a new Post object as a list
                List<CustomPost> myPosts = new List<CustomPost>();
                // Creats a new reddit object, with a hard-coded user
                Reddit reddit = new Reddit("Crashmaster69", "maytag1", true);
                // Creates a new fontPage object 
                Subreddit frontPage = reddit.FrontPage;
                // Creates a list of the Hot items in the front page
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
    }
}
