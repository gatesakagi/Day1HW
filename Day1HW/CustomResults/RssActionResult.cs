using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Day1HW.CustomResults
{
    public class RssActionResult : FileResult
    {
        private readonly SyndicationFeed _feed;

        public RssActionResult(SyndicationFeed feed) : base("application/rss+xml")
        {
            _feed = feed;
        }

        public RssActionResult(string title, List<SyndicationItem> feedItems) : base("application/rss+xml")
        {
            _feed = new SyndicationFeed(title, title, HttpContext.Current.Request.Url) { Items = feedItems };
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            using (XmlWriter writer = XmlWriter.Create(response.OutputStream))
            {
                _feed.GetRss20Formatter().WriteTo(writer);
            }
        }
    }
}