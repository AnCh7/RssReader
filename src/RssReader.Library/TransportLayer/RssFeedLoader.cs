#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using RssReader.Common.Logging;
using RssReader.Common.Models;
using RssReader.Library.Models;
using RssReader.Library.Net;
using RssReader.Library.Offline;

#endregion

namespace RssReader.Library.TransportLayer
{
    public class RssFeedLoader : IRssFeedLoader
    {
        private readonly ILogger _logger;
        private readonly IWebLoader _webLoader;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RssFeedLoader" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="webLoader">The web loader.</param>
        public RssFeedLoader(ILogger logger, IWebLoader webLoader)
        {
            _logger = logger;
            _webLoader = webLoader;
        }

        /// <summary>
        ///     Downloads the RSS data.
        /// </summary>
        /// <param name="rssFeedUrl">The RSS feed URL.</param>
        /// <returns></returns>
        public OperationResult DownloadRssData(string rssFeedUrl)
        {
            try
            {
                var result = _webLoader.Load(rssFeedUrl);
                if (!result.Success)
                {
                    // Switching to offline sample data
                    return DownloadRssOfflineSample();
                }

                var data = ((OperationResult<MemoryStream>) result).Data;
                using (var reader = XmlReader.Create(data))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);

                    var rssChannel = ParseRssContent(xmlDoc);
                    return new OperationResult<RssData>(rssChannel);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new FailedOperationResult(ex.Message);
            }
        }

        /// <summary>
        ///     Downloads the RSS offline sample.
        /// </summary>
        /// <returns></returns>
        private OperationResult DownloadRssOfflineSample()
        {
            _logger.Info("Using offline sample");

            var bytes = Encoding.UTF8.GetBytes(OfflineSample.CitydogRssData);
            using (var memoryStream = new MemoryStream(bytes))
            {
                using (var reader = XmlReader.Create(memoryStream))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(reader);

                    var rssChannel = ParseRssContent(xmlDoc);
                    return new OperationResult<RssData>(rssChannel)
                    {
                        ErrorMessage = "Error during downloading data. Offline sample was used"
                    };
                }
            }
        }

        /// <summary>
        ///     Parses the content of the RSS.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns></returns>
        private RssData ParseRssContent(XmlDocument xmlDoc)
        {
            var rssItems = ParseRssItems(xmlDoc);

            var rssDetails = new RssDetails
            {
                Title = ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "title"),
                Description = ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "description"),
                Link = ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "link"),
                PubDate = ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "pubDate"),
                ImageUrl = ParseDocElements(xmlDoc.SelectSingleNode("//channel//image"), "url")
            };

            return new RssData {Details = rssDetails, RssItems = rssItems};
        }

        /// <summary>
        ///     Parses the xml document in order to retrieve the RSS items.
        /// </summary>
        private List<RssItem> ParseRssItems(XmlDocument xmlDoc)
        {
            var rssItems = new List<RssItem>();

            var nodes = xmlDoc.SelectNodes("rss/channel/item");
            if (nodes != null)
            {
                rssItems.AddRange(from XmlNode node in nodes
                    select new RssItem
                    {
                        Title = ParseDocElements(node, "title"),
                        Link = ParseDocElements(node, "link"),
                        Description = ParseDocElements(node, "description"),
                        PubDate = ParseDocElements(node, "pubDate"),
                        Categories = new List<string>
                        {
                            ParseDocElements(node, "category")
                        }
                    });
            }

            return rssItems;
        }

        /// <summary>
        ///     Parses the XmlNode with the specified XPath query
        ///     and assigns the value to the property parameter.
        /// </summary>
        private string ParseDocElements(XmlNode parent, string xPath)
        {
            var node = parent.SelectSingleNode(xPath);
            return node != null ? node.InnerText : "Unresolvable";
        }
    }
}