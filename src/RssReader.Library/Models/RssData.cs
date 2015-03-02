#region Usings

using System.Collections.Generic;

#endregion

namespace RssReader.Library.Models
{
    public class RssData
    {
        public RssDetails Details { get; set; }
        public List<RssItem> RssItems { get; set; }
    }
}