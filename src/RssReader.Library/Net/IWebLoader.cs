#region Usings

using System.Drawing;
using RssReader.Common.Models;

#endregion

namespace RssReader.Library.Net
{
    public interface IWebLoader
    {
        OperationResult Load(string rssFeedUrl);
        OperationResult GetImageFromUrl(string url);
    }
}