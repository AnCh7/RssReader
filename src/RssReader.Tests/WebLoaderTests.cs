#region Usings

using System;
using System.IO;
using Autofac;
using NUnit.Framework;
using RssReader.Common.Models;
using RssReader.Library.Net;
using RssReader.UI.DependencyInjection;

#endregion

namespace RssReader.Tests
{
    [TestFixture]
    public class WebLoaderTests
    {
        private readonly IWebLoader _webLoader;

        public WebLoaderTests()
        {
            _webLoader = DependencyContainer.Instance.Resolve<IWebLoader>();
        }

        [Test]
        public void Test_Load_Invalid_Url()
        {
            //Arrange
            const string rssFeedUrl = "http://citydoggg.by/rss";

            // Act
            var result = _webLoader.Load(rssFeedUrl);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("The remote name could not be resolved: 'citydoggg.by'", result.ErrorMessage);
        }

        [Test]
        public void Test_Load_Valid_Url()
        {
            //Arrange
            const string rssFeedUrl = "http://citydog.by/rss";

            // Act
            var result = _webLoader.Load(rssFeedUrl);
            var data = ((OperationResult<MemoryStream>) result).Data;

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ErrorMessage));
            Assert.IsTrue(result.Success);
            Assert.IsTrue(data != null);
        }

        [Test]
        public void Test_GetImageFromUrl_Invalid_Url()
        {
            //Arrange
            const string url = "http://citydog.by/images/citydog_logo123.png";

            // Act
            var result = _webLoader.Load(url);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("The remote server returned an error: (404) Not Found.", result.ErrorMessage);
        }

        [Test]
        public void Test_GetImageFromUrl_Valid_Url()
        {
            //Arrange
            const string url = "http://citydog.by/images/citydog_logo.png";

            // Act
            var result = _webLoader.Load(url);

            // Assert
            Assert.IsTrue(String.IsNullOrEmpty(result.ErrorMessage));
            Assert.IsTrue(result.Success);
        }
    }
}