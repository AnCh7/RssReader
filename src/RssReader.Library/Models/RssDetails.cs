#region Usings

using System;

#endregion

namespace RssReader.Library.Models
{
    public class RssDetails : RssFields
    {
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return String.Join(" | ", Title, Link, Description, PubDate);
        }
    }
}