#region Usings

using System;
using System.Configuration;

#endregion

namespace RssReader.UI.Utility
{
    public static class Settings
    {
        public static string GetRssFeedUrl()
        {
            var defaultValue = "http://citydog.by/rss";

            try
            {
                var url = ConfigurationManager.AppSettings["RssFeedUrl"];
                if (String.IsNullOrWhiteSpace(url))
                {
                    defaultValue = url;
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return defaultValue;
        }

        public static string GetUpdatePeriod()
        {
            var defaultValue = "60";

            try
            {
                var url = ConfigurationManager.AppSettings["UpdatePeriod"];
                if (String.IsNullOrWhiteSpace(url))
                {
                    defaultValue = url;
                }
            }
            catch (Exception ex)
            {
                // ignored
            }

            return defaultValue;
        }
    }
}