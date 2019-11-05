using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using RssFeed.Models;
using System.ServiceModel.Syndication;
using System.Text;

namespace RssFeed.Controllers
{
    public class FeedInformation : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Feed()
        {

            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("http://feeds.feedburner.com/techulator/articles");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            List<Feed> feedL = new List<Feed>();
            Feed feed = new Feed();
            int count = 0;

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                count++;
                feed.Id = count;

                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                if (rssSubNode != null)
                {
                    feed.Title = rssSubNode.InnerText;
                }

                rssSubNode = rssNode.SelectSingleNode("link");
                if (rssSubNode != null)
                {
                   feed.Link = rssSubNode.InnerText;
                }

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                if (rssSubNode != null)
                {
                    feed.PostedDate = rssSubNode.InnerText;
                }

                feedL.Add(feed);
                feed = new Feed();
            }

            string teste = rssContent.ToString();

            ViewBag.feed = feedL;

            return View();
        }
    }
}
