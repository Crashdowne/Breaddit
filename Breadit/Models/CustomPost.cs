using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedditSharp;
using RedditSharp.Things;

namespace Breadit.Models
{
    public class CustomPost : AsyncModelBase
    {
        public bool IsUpVoted
        {
            get
            {
                return Post.Vote == VotableThing.VoteType.Upvote;
            }
        }

        public bool IsDownVoted
        {
            get
            {
                return Post.Vote == VotableThing.VoteType.Downvote;
            }
        }

        public bool IsNoneVote
        {
            get
            {
                return Post.Vote == VotableThing.VoteType.None;
            }
        }

        public CustomPost(Post post)
        {
            Post = post;
        }

        public Post Post { get; set; }

        public async void ChangeVote(VotableThing.VoteType vote)
        {
            await Task.Run(delegate { Post.SetVote(vote); });

            OnPropertyChanged("IsUpVoted");
            OnPropertyChanged("IsDownVoted");
            OnPropertyChanged("IsNoneVote");
        }
    }
}
