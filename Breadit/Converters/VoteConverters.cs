using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

using RedditSharp;
using RedditSharp.Things;

namespace Breadit.Converters
{
    public class UpVoteToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is VotableThing.VoteType)
            {
                VotableThing.VoteType type = (VotableThing.VoteType)value;
                if (type == VotableThing.VoteType.Upvote)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                Visibility type = (Visibility)value;
                if (type == Visibility.Visible)
                {
                    return VotableThing.VoteType.Upvote;
                }
                else
                {
                    return VotableThing.VoteType.None;
                }
            }
            return VotableThing.VoteType.None;
        }
    }

    public class DownVoteToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is VotableThing.VoteType)
            {
                VotableThing.VoteType type = (VotableThing.VoteType)value;
                if (type == VotableThing.VoteType.Downvote)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                Visibility type = (Visibility)value;
                if (type == Visibility.Visible)
                {
                    return VotableThing.VoteType.Downvote;
                }
                else
                {
                    return VotableThing.VoteType.None;
                }
            }
            return VotableThing.VoteType.None;
        }
    }
}
