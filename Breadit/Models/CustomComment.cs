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
        private string m_age = "";
        public string Age
        {
            get
            {
                return m_age;
            }

            set
            {
                m_age = value;
                OnPropertyChanged("Age");
            }
        }
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
            TimeSpan diff = DateTime.Now - comment.Created;
            Age = simpleTimeSpan(diff);
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

        // Displays the timespan in a simple format
        private string simpleTimeSpan(TimeSpan diff)
        {
            // display minutes if timespan is < 1hr
            if (diff < TimeSpan.FromHours(1))
            {
                return diff.ToString("%m") + " minutes old";
            }
            // display hours if timespan < 1 day
            else if (diff < TimeSpan.FromDays(1))
            {
                return diff.ToString("%h") + " hours old";
            }
            // display number of days if 1+ days
            else if (diff > TimeSpan.FromDays(1))
            {
                return diff.ToString("%d") + " days old";
            }
            return "";
        }
    }
}
