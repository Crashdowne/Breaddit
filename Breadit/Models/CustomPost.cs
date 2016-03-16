﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RedditSharp;
using RedditSharp.Things;
using System.Windows;

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
            var isSet = await Task<bool>.Run(delegate
            {
                try
                {
                    Post.SetVote(vote);
                    return true;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            });

            if (!isSet)
            {
                MessageBox.Show("Please login to vote");
            }
            OnPropertyChanged("IsUpVoted");
            OnPropertyChanged("IsDownVoted");
            OnPropertyChanged("IsNoneVote");
        }
    }
}
