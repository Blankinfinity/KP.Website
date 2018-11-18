using System;

namespace KP.Domain.Entities.Models
{
    public class SiteDownloads
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public Nullable<bool> isDownloaded { get; set; }
        public Nullable<bool> rssSubscribed { get; set; }
        public Nullable<System.DateTime> dateDownloaded { get; set; }
        public Nullable<System.DateTime> LastVisited { get; set; }
    }
}
