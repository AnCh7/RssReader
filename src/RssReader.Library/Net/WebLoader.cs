#region Usings

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using RssReader.Common.Logging;
using RssReader.Common.Models;

#endregion

namespace RssReader.Library.Net
{
    public class WebLoader : IWebLoader
    {
        private readonly ILogger _logger;

        public WebLoader(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     Loads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public OperationResult Load(string url)
        {
            try
            {
                string xml;
                using (var webClient = new WebClient())
                {
                    var rssContent = webClient.DownloadData(url);
                    xml = Encoding.UTF8.GetString(rssContent);
                }

                var bytes = Encoding.UTF8.GetBytes(xml);
                var memoryStream = new MemoryStream(bytes);

                return new OperationResult<MemoryStream>(memoryStream);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new FailedOperationResult(ex.Message);
            }
        }

        /// <summary>
        ///     Gets the image from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public OperationResult GetImageFromUrl(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
                using (var httpWebReponse = (HttpWebResponse) httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebReponse.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            var result = new OperationResult<Image>(Image.FromStream(stream));
                            return result;
                        }

                        return new FailedOperationResult("Can't load image");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return new FailedOperationResult(ex.Message);
            }
        }
    }
}