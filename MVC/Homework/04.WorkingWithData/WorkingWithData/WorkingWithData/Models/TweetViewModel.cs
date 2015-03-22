using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WorkingWithData.Models
{
    public class TweetViewModel
    {
        public static Expression<Func<Tweet, TweetViewModel>> FromTweet
        {
            get
            {
                return tweet => new TweetViewModel
                {
                    Text = tweet.Text,
                    Tags = tweet.Tags
                };
            }
        }

        public string Text { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}