namespace UI
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.jiraGrid = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SummaryText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noResultsText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jiraGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // jiraGrid
            // 
            this.jiraGrid.AllowUserToAddRows = false;
            this.jiraGrid.AllowUserToDeleteRows = false;
            this.jiraGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.jiraGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jiraGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jiraGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.jiraGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.jiraGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.jiraGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jiraGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.JiraLink,
            this.SummaryText,
            this.DateCreated,
            this.ClientName});
            this.jiraGrid.EnableHeadersVisualStyles = false;
            this.jiraGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.jiraGrid.Location = new System.Drawing.Point(12, 88);
            this.jiraGrid.Name = "jiraGrid";
            this.jiraGrid.ReadOnly = true;
            this.jiraGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.jiraGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.jiraGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.jiraGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.jiraGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.jiraGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.jiraGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jiraGrid.Size = new System.Drawing.Size(965, 537);
            this.jiraGrid.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.searchBox.Location = new System.Drawing.Point(79, 12);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(288, 20);
            this.searchBox.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(373, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(60, 20);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::UI.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(846, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(79, 38);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(84, 20);
            this.dateFrom.TabIndex = 4;
            this.dateFrom.Value = new System.DateTime(2015, 5, 2, 20, 30, 8, 0);
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(79, 62);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(84, 20);
            this.dateTo.TabIndex = 5;
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.ForeColor = System.Drawing.Color.White;
            this.dateFromLabel.Location = new System.Drawing.Point(14, 44);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(59, 13);
            this.dateFromLabel.TabIndex = 6;
            this.dateFromLabel.Text = "Date From:";
            // 
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.ForeColor = System.Drawing.Color.White;
            this.dateToLabel.Location = new System.Drawing.Point(24, 68);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(49, 13);
            this.dateToLabel.TabIndex = 7;
            this.dateToLabel.Text = "Date To:";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.ForeColor = System.Drawing.Color.White;
            this.textLabel.Location = new System.Drawing.Point(5, 16);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(68, 13);
            this.textLabel.TabIndex = 8;
            this.textLabel.Text = "Search Text:";
            // 
            // OrderNumber
            // 
            this.OrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OrderNumber.HeaderText = "Order";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderNumber.Width = 89;
            // 
            // JiraLink
            // 
            this.JiraLink.HeaderText = "Jira";
            this.JiraLink.Name = "JiraLink";
            this.JiraLink.ReadOnly = true;
            // 
            // SummaryText
            // 
            this.SummaryText.HeaderText = "Summary";
            this.SummaryText.Name = "SummaryText";
            this.SummaryText.ReadOnly = true;
            // 
            // DateCreated
            // 
            this.DateCreated.HeaderText = "Date Created";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.HeaderText = "Client";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            // 
            // noResultsText
            // 
            this.noResultsText.AutoSize = true;
            this.noResultsText.BackColor = System.Drawing.Color.Black;
            this.noResultsText.Font = new System.Drawing.Font("monofur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noResultsText.ForeColor = System.Drawing.Color.White;
            this.noResultsText.Location = new System.Drawing.Point(261, 135);
            this.noResultsText.Name = "noResultsText";
            this.noResultsText.Size = new System.Drawing.Size(467, 27);
            this.noResultsText.TabIndex = 9;
            this.noResultsText.Text = "No jiras match your search criteria";
            this.noResultsText.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(989, 635);
            this.Controls.Add(this.noResultsText);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.dateToLabel);
            this.Controls.Add(this.dateFromLabel);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.jiraGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1005, 673);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ask Jira";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jiraGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView jiraGrid;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Label dateToLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaryText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.Label noResultsText;
    }
}

