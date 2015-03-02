#region Usings

using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Autofac;
using RssReader.Common.Logging;
using RssReader.Common.Models;
using RssReader.Library.Models;
using RssReader.Library.Net;
using RssReader.Library.TransportLayer;
using RssReader.UI.DependencyInjection;
using RssReader.UI.Utility;
using Timer = System.Threading.Timer;

#endregion

namespace RssReader.UI
{
    public partial class Main : Form
    {
        private IRssFeedLoader _rssFeedLoader;
        private Timer _updateTimer;
        private IWebLoader _webLoader;
        private ILogger _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Main" /> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Handles the Load event of the Main control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            InitDefaultValues();

            _logger = DependencyContainer.Instance.Resolve<ILogger>();
            _rssFeedLoader = DependencyContainer.Instance.Resolve<IRssFeedLoader>();
            _webLoader = DependencyContainer.Instance.Resolve<IWebLoader>();
        }

        /// <summary>
        ///     Handles the Click event of the btnLoad control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                rtbLog.SafeLog("Downloading RSS", Color.Black);

                var result = DownloadRssData();
                if (result.Success)
                {
                    var data = ((OperationResult<RssData>) result).Data;
                    FillDataGridView(data);

                    if (!String.IsNullOrEmpty(result.ErrorMessage))
                    {
                        rtbLog.SafeLog(result.ErrorMessage, Color.Red);
                    }
                    else
                    {
                        rtbLog.SafeLog("Finished. Rss data feed - " + data.Details, Color.Black);
                        // Not working on mac
                        //LoadRssFeedImage(data, result);
                    }
                }
                else
                {
                    rtbLog.SafeLog(result.ErrorMessage, Color.Red);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                rtbLog.SafeLog(ex.Message, Color.Red);
            }
        }

        /// <summary>
        ///     Loads the image from the internet.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="result">The result.</param>
        private void LoadRssFeedImage(RssData data, OperationResult result)
        {
            var imageResult = _webLoader.GetImageFromUrl(data.Details.ImageUrl);
            if (imageResult.Success)
            {
                var image = ((OperationResult<Image>) imageResult).Data;
                Clipboard.SetImage(image);
                rtbLog.SafePaste();
            }
            else
            {
                rtbLog.SafeLog(result.ErrorMessage, Color.Red);
            }
        }

        /// <summary>
        ///     Handles the CheckedChanged event of the cbAutoUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var checkBox = sender as CheckBox;
                if (checkBox != null)
                {
                    if (checkBox.SafeRead_Checked())
                    {
                        _updateTimer = new Timer(DownloadRssCallback, null, tbUpdatePeriod.SafeRead_Int()*1000,
                            Timeout.Infinite);
                        rtbLog.SafeLog("Subscribed to RSS updates", Color.Black);
                        DisableControls();
                    }
                    else
                    {
                        rtbLog.SafeLog("Unsubscribed from RSS updates", Color.Black);
                        StopTimer();
                        EnableControls();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                rtbLog.SafeLog(ex.Message, Color.Red);
            }
        }

        /// <summary>
        ///     Initializes the default values.
        /// </summary>
        private void InitDefaultValues()
        {
            var rssFeedUrl = Settings.GetRssFeedUrl();
            tbUrl.SafeWrite_Text(rssFeedUrl);

            var updatePeriod = Settings.GetUpdatePeriod();
            tbUpdatePeriod.SafeWrite_Text(updatePeriod);
        }

        /// <summary>
        ///     Callback for timer.
        /// </summary>
        /// <param name="state">The state.</param>
        private void DownloadRssCallback(object state)
        {
            var result = DownloadRssData();
            if (result.Success)
            {
                var data = ((OperationResult<RssData>) result).Data;
                UpdateDataGridView(data);

                if (!String.IsNullOrEmpty(result.ErrorMessage))
                {
                    rtbLog.SafeLog(result.ErrorMessage, Color.Red);
                }
                else
                {
                    rtbLog.SafeLog("Listening for updates...", Color.Black);
                }

                if (_updateTimer != null)
                {
                    _updateTimer.Change(tbUpdatePeriod.SafeRead_Int()*1000, Timeout.Infinite);
                }
            }
            else
            {
                rtbLog.SafeLog(result.ErrorMessage, Color.Red);
            }
        }

        /// <summary>
        ///     Downloads the RSS data.
        /// </summary>
        /// <returns></returns>
        private OperationResult DownloadRssData()
        {
            var rssFeedUrl = tbUrl.SafeRead_Text();
            if (String.IsNullOrEmpty(rssFeedUrl))
            {
                return new FailedOperationResult("Url address is empty");
            }

            return _rssFeedLoader.DownloadRssData(rssFeedUrl);
        }

        /// <summary>
        ///     Enables the controls.
        /// </summary>
        private void EnableControls()
        {
            tbUpdatePeriod.Enabled = true;
            tbUrl.Enabled = true;
            btnLoad.Enabled = true;
        }

        /// <summary>
        ///     Disables the controls.
        /// </summary>
        private void DisableControls()
        {
            tbUpdatePeriod.Enabled = false;
            tbUrl.Enabled = false;
            btnLoad.Enabled = false;
        }

        /// <summary>
        ///     Fills the data grid view.
        /// </summary>
        /// <param name="rssData">The RSS data.</param>
        private void FillDataGridView(RssData rssData)
        {
            dgvRssItems.SafeRenew();

            foreach (var rssItems in rssData.RssItems)
            {
                var items = rssItems;
                dgvRssItems.SafeUpdate(items);
            }
        }

        /// <summary>
        ///     Updates the data grid view.
        /// </summary>
        /// <param name="rssData">The RSS data.</param>
        private void UpdateDataGridView(RssData rssData)
        {
            try
            {
                var linkCell = dgvRssItems.SafeFirstRow().Cells[2].Value.ToString();
                var newItem = rssData.RssItems.First();

                if (!String.Equals(linkCell, newItem.Link))
                {
                    dgvRssItems.SafeInsert(newItem);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                rtbLog.SafeLog(ex.Message, Color.Red);
            }
        }

        /// <summary>
        ///     Stops the timer.
        /// </summary>
        private void StopTimer()
        {
            if (_updateTimer != null)
            {
                _updateTimer.Dispose();
                _updateTimer = null;
            }
        }
    }
}