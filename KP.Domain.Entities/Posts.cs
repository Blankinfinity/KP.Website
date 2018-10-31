using System;
using System.Collections.Generic;
using System.Text;

namespace KP.Domain.Entities
{
    public class Posts
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCommentsEnabled { get; set; }
        public DateTime PubDate { get; set; }
        public DateTime LastModified { get; set; }
        public int Raters { get; set; }
        public long Rating { get; set; }
        public string Slug { get; set; }
        public IEnumerable<Tags> Tags { get; set; }
        public string Comments { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public string Notifications { get; set; }
    }
}
