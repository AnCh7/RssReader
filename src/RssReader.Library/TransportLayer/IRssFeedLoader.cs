#region Usings

using RssReader.Common.Models;

#endregion

namespace RssReader.Library.TransportLayer
{
    public interface IRssFeedLoader
    {
        OperationResult DownloadRssData(string rssFeedUrl);
    }
}