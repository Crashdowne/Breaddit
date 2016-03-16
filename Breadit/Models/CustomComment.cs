using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedditSharp;
using RedditSharp.Things;
using System.Windows;

namespace Breadit.Models
{
    public class CustomComment : AsyncModelBase
    {
        public bool IsUpVoted
        {
            get
            {
                return Comment.Vote == VotableThing.VoteType.Upvote;
            }
        }

        public bool IsDownVoted
        {
            get
            {
                return Comment.Vote == VotableThing.VoteType.Downvote;
            }
        }

        public bool IsNoneVote
        {
            get
            {
                return Comment.Vote == VotableThing.VoteType.None;
            }
        }

        public CustomComment(Comment comment)
        {
            Comment = comment;
        }

        public Comment Comment { get; set; }

        public async void ChangeVote(VotableThing.VoteType vote)
        {
            var isSet = await Task<bool>.Run(delegate
            {
                try
                {
                    Comment.SetVote(vote);
                    return true;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            });

            if (!isSet)
            {
                MessageBox.Show("Please Return and login to vote.");
            }
            OnPropertyChanged("IsUpVoted");
            OnPropertyChanged("IsDownVoted");
            OnPropertyChanged("IsNoneVote");
        }

        //try
        //{
        //    await Task.Run(delegate { Comment.SetVote(vote); });

        //    OnPropertyChanged("IsUpVoted");
        //    OnPropertyChanged("IsDownVoted");
        //    OnPropertyChanged("IsNoneVote");
        //}

        //catch (AggregateException e)
        //{
        //    MessageBox.Show("You must be logged in to vote");
        //}

    }
}
