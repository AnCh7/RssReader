#region Usings

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace RssReader.Library.Models
{
    public class RssItem : RssFields
    {
        public List<string> Categories { get; set; }

        public string CategoriesToString()
        {
            return String.Join(" | ", Categories.Select(x => x));
        }
    }
}