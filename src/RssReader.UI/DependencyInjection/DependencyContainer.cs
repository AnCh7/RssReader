#region Usings

using Autofac;
using RssReader.Common.Logging;
using RssReader.Library.Net;
using RssReader.Library.TransportLayer;

#endregion

namespace RssReader.UI.DependencyInjection
{
    public sealed class DependencyContainer
    {
        private static readonly DependencyContainer _instance = new DependencyContainer();
        private static volatile IContainer _container;

        /// <summary>
        ///     Prevents a default instance of the <see cref="DependencyContainer" /> class from being created.
        /// </summary>
        private DependencyContainer()
        {
        }

        /// <summary>
        ///     Initializes the <see cref="DependencyContainer" /> class.
        /// </summary>
        static DependencyContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<WebLoader>().As<IWebLoader>().SingleInstance();
            builder.RegisterType<RssFeedLoader>().As<IRssFeedLoader>().SingleInstance();

            _container = builder.Build();
        }

        public static IContainer Instance
        {
            get { return _container; }
        }
    }
}