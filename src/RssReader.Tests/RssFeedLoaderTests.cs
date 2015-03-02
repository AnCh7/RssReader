#region Usings

using System;
using System.Linq;
using Autofac;
using NUnit.Framework;
using RssReader.Common.Models;
using RssReader.Library.Models;
using RssReader.Library.TransportLayer;
using RssReader.UI.DependencyInjection;

#endregion

namespace RssReader.Tests
{
    [TestFixture]
    public class RssFeedLoaderTests
    {
        private readonly IRssFeedLoader _rssFeedLoader;

        public RssFeedLoaderTests()
        {
            _rssFeedLoader = DependencyContainer.Instance.Resolve<IRssFeedLoader>();
        }

        [Test]
        public void Test_DownloadRssData_Invalid_Url()
        {
            //Arrange
            const string rssFeedUrl = "http://citydog.by/rss123";

            // Act
            var result = _rssFeedLoader.DownloadRssData(rssFeedUrl);

            // Assert
            Assert.IsFalse(String.IsNullOrEmpty(result.ErrorMessage));
            Assert.AreEqual("Error during downloading data. Offline sample was used", result.ErrorMessage);
        }

        [Test]
        public void Test_DownloadRssData_Valid_Url()
        {
            //Arrange
            const string rssFeedUrl = "http://citydog.by/rss";

            // Act
            var result = _rssFeedLoader.DownloadRssData(rssFeedUrl);
            var data = ((OperationResult<RssData>) result).Data;

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ErrorMessage));
            Assert.IsTrue(result.Success);
            Assert.IsTrue(data.RssItems.Any());
        }
    }
}