#region Usings

using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;

#endregion

namespace RssReader.Common.Logging.Targets
{
    public class TargetFile
    {
        public void Setup()
        {
            var hierarchy = (Hierarchy) LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();

            var fileAppender = new FileAppender
            {
                AppendToFile = true,
                LockingModel = new FileAppender.MinimalLock(),
                File = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "log.txt"
            };

            var pl = new PatternLayout
            {
                ConversionPattern = "%d [%2%t] %-5p [%-10c]   %m%n%n"
            };

            pl.ActivateOptions();
            fileAppender.Layout = pl;
            fileAppender.ActivateOptions();

            BasicConfigurator.Configure(fileAppender);
        }
    }
}