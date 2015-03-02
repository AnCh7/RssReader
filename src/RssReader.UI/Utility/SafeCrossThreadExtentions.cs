#region Usings

using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using RssReader.Library.Models;

#endregion

namespace RssReader.UI.Utility
{
    public static class SafeCrossThreadExtentions
    {
        public static string SafeRead_Text(this TextBox control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeRead_Text(); }));
            }
            return control.Text;
        }

        public static int SafeRead_Int(this TextBox control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeRead_Int(); }));
            }

            var result = 0;
            var updatePeriodText = control.Text;
            if (!String.IsNullOrEmpty(updatePeriodText))
            {
                int updatePeriod;
                if (Int32.TryParse(updatePeriodText, NumberStyles.Integer, CultureInfo.InvariantCulture,
                    out updatePeriod))
                {
                    result = updatePeriod;
                }
            }

            return result;
        }

        public static void SafeWrite_Text(this TextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeWrite_Text(text); }));
            }
            else
            {
                control.Text = text;
            }
        }

        public static void SafeLog(this RichTextBox control, string text, Color color)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { SafeLog(control, text, color); }));
            }
            else
            {
                control.SelectionStart = control.Text.Length;
                control.SelectionColor = color;

                if (control.Lines.Length == 0)
                {
                    control.AppendText(DateTime.Now.ToString("G") + " - " + text);
                    control.ScrollToCaret();
                    control.AppendText(Environment.NewLine);
                }
                else
                {
                    control.AppendText(DateTime.Now.ToString("G") + " - " + text + Environment.NewLine);
                    control.ScrollToCaret();
                }
            }
        }

        public static void SafePaste(this RichTextBox control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { SafePaste(control); }));
            }
            else
            {
                control.SelectionStart = control.Text.Length;

                if (control.Lines.Length == 0)
                {
                    control.Paste();
                    control.ScrollToCaret();
                    control.AppendText(Environment.NewLine);
                }
                else
                {
                    control.Paste();
                    control.ScrollToCaret();
                    control.AppendText(Environment.NewLine);
                }
            }
        }

        public static bool SafeRead_Checked(this CheckBox control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeRead_Checked(); }));
            }

            return control.Checked;
        }

        public static void SafeUpdate(this DataGridView control, RssItem rssItem)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeUpdate(rssItem); }));
            }
            else
            {
                control.Rows.Add(rssItem.Title, rssItem.PubDate, rssItem.Link, rssItem.Description,
                    rssItem.CategoriesToString());
            }
        }

        public static void SafeInsert(this DataGridView control, RssItem rssItem)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeInsert(rssItem); }));
            }
            else
            {
                control.Rows.Insert(0, rssItem.Title, rssItem.PubDate, rssItem.Link, rssItem.Description,
                    rssItem.CategoriesToString());
            }
        }

        public static DataGridViewRow SafeFirstRow(this DataGridView control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate { control.SafeFirstRow(); }));
            }

            return control.Rows[0];
        }

        public static void SafeRenew(this DataGridView control)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(control.SafeRenew));
            }
            else
            {
                control.Rows.Clear();
                control.Refresh();
            }
        }
    }
}