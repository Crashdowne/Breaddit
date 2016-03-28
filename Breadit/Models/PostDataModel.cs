using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedditSharp;
using RedditSharp.Things;
using System.Windows;

namespace Breadit.Models
{
    public class PostDataModel : AsyncModelBase
    {
        // m_ means member variable
        // model means this is where all the data will be stored (data model)
        private CustomPost m_openedPost = null;

        public CustomPost OpenedPost
        {
            get
            {
                return m_openedPost;
            }

            set
            {
                m_openedPost = value;
                OnPropertyChanged("IsLoading");
            }
        }

        private readonly ObservableCollection<CustomComment> m_comments = new ObservableCollection<CustomComment>();
        public ObservableCollection<CustomComment> Comments
        {
            get { return m_comments; }
        }

        // Init this data model
        public PostDataModel(CustomPost openedPost)
        {
            OpenedPost = openedPost;
        }

        // Kind of like the main method
        public async void Initialize()
        {
            var commentList = await GetComments();

            foreach (var comment in commentList)
            {
                Comments.Add(new CustomComment(comment));
            }
        }

        public Task<List<Comment>> GetComments()
        {
            return Task.Run(delegate
            {
                var list = new List<Comment>();
                foreach(Comment comment in OpenedPost.Post.Comments.Take(20))
                {
                    list.Add(comment);
                }
                return list;
            });
        }
    }
}
