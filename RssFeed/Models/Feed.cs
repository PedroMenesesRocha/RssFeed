using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RssFeed.Models
{
    public class Feed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string PostedDate { get; set; }
    }
}
