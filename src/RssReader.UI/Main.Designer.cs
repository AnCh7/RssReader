namespace RssReader.UI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.gbRssItems = new System.Windows.Forms.GroupBox();
            this.dgvRssItems = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PubDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Topic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbUpdatePeriod = new System.Windows.Forms.TextBox();
            this.lblUpdatePeriod = new System.Windows.Forms.Label();
            this.gbLog.SuspendLayout();
            this.gbRssItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRssItems)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(6, 19);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1033, 187);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.rtbLog);
            this.gbLog.Location = new System.Drawing.Point(12, 370);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(1045, 212);
            this.gbLog.TabIndex = 1;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log:";
            // 
            // tbUrl
            // 
            this.tbUrl.Location = new System.Drawing.Point(38, 6);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(365, 20);
            this.tbUrl.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(409, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(78, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(9, 9);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 4;
            this.lblUrl.Text = "Url:";
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Location = new System.Drawing.Point(807, 8);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(83, 17);
            this.cbAutoUpdate.TabIndex = 5;
            this.cbAutoUpdate.Text = "AutoUpdate";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            this.cbAutoUpdate.CheckedChanged += new System.EventHandler(this.cbAutoUpdate_CheckedChanged);
            // 
            // gbRssItems
            // 
            this.gbRssItems.Controls.Add(this.dgvRssItems);
            this.gbRssItems.Location = new System.Drawing.Point(12, 32);
            this.gbRssItems.Name = "gbRssItems";
            this.gbRssItems.Size = new System.Drawing.Size(1051, 332);
            this.gbRssItems.TabIndex = 7;
            this.gbRssItems.TabStop = false;
            this.gbRssItems.Text = "Rss Items";
            // 
            // dgvRssItems
            // 
            this.dgvRssItems.AllowUserToAddRows = false;
            this.dgvRssItems.AllowUserToDeleteRows = false;
            this.dgvRssItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRssItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.PubDate,
            this.Link,
            this.Description,
            this.Topic});
            this.dgvRssItems.Location = new System.Drawing.Point(6, 19);
            this.dgvRssItems.Name = "dgvRssItems";
            this.dgvRssItems.ReadOnly = true;
            this.dgvRssItems.Size = new System.Drawing.Size(1039, 307);
            this.dgvRssItems.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 225;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 250;
            // 
            // PubDate
            // 
            this.PubDate.HeaderText = "Date";
            this.PubDate.MinimumWidth = 75;
            this.PubDate.Name = "PubDate";
            this.PubDate.ReadOnly = true;
            this.PubDate.Width = 125;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.MinimumWidth = 175;
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            this.Link.Width = 225;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 225;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 250;
            // 
            // Topic
            // 
            this.Topic.HeaderText = "Topic";
            this.Topic.MinimumWidth = 75;
            this.Topic.Name = "Topic";
            this.Topic.ReadOnly = true;
            this.Topic.Width = 125;
            // 
            // tbUpdatePeriod
            // 
            this.tbUpdatePeriod.Location = new System.Drawing.Point(1035, 6);
            this.tbUpdatePeriod.Name = "tbUpdatePeriod";
            this.tbUpdatePeriod.Size = new System.Drawing.Size(28, 20);
            this.tbUpdatePeriod.TabIndex = 8;
            // 
            // lblUpdatePeriod
            // 
            this.lblUpdatePeriod.AutoSize = true;
            this.lblUpdatePeriod.Location = new System.Drawing.Point(896, 9);
            this.lblUpdatePeriod.Name = "lblUpdatePeriod";
            this.lblUpdatePeriod.Size = new System.Drawing.Size(137, 13);
            this.lblUpdatePeriod.TabIndex = 9;
            this.lblUpdatePeriod.Text = "Update period (in seconds):";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 593);
            this.Controls.Add(this.lblUpdatePeriod);
            this.Controls.Add(this.tbUpdatePeriod);
            this.Controls.Add(this.gbRssItems);
            this.Controls.Add(this.cbAutoUpdate);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.gbLog);
            this.Name = "Main";
            this.Text = "Rss Reader";
            this.Load += new System.EventHandler(this.Main_Load);
            this.gbLog.ResumeLayout(false);
            this.gbRssItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRssItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
        private System.Windows.Forms.GroupBox gbRssItems;
        private System.Windows.Forms.DataGridView dgvRssItems;
        private System.Windows.Forms.TextBox tbUpdatePeriod;
        private System.Windows.Forms.Label lblUpdatePeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn PubDate;
        private System.Windows.Forms.DataGridViewLinkColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Topic;
    }
}

