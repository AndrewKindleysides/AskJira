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
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.SummaryText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RaisedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.noResultsText = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.issueTypes = new System.Windows.Forms.ComboBox();
            this.issueTypeLabel = new System.Windows.Forms.Label();
            this.clientName = new System.Windows.Forms.TextBox();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.componentDropdown = new System.Windows.Forms.ComboBox();
            this.componentLabel = new System.Windows.Forms.Label();
            this.fixVersionLabel = new System.Windows.Forms.Label();
            this.fixVersionDropdown = new System.Windows.Forms.ComboBox();
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ClientNameColumn,
            this.RaisedBy,
            this.AssignedTo});
            this.jiraGrid.EnableHeadersVisualStyles = false;
            this.jiraGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.jiraGrid.Location = new System.Drawing.Point(12, 88);
            this.jiraGrid.Name = "jiraGrid";
            this.jiraGrid.ReadOnly = true;
            this.jiraGrid.RowHeadersVisible = false;
            this.jiraGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.jiraGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.jiraGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.jiraGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.jiraGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.jiraGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.jiraGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.jiraGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jiraGrid.Size = new System.Drawing.Size(965, 500);
            this.jiraGrid.TabIndex = 0;
            this.jiraGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jiraGrid_CellContentClick);
            // 
            // OrderNumber
            // 
            this.OrderNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OrderNumber.HeaderText = "Order";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            this.OrderNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderNumber.Width = 79;
            // 
            // JiraLink
            // 
            this.JiraLink.HeaderText = "Jira";
            this.JiraLink.Name = "JiraLink";
            this.JiraLink.ReadOnly = true;
            this.JiraLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JiraLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // ClientNameColumn
            // 
            this.ClientNameColumn.HeaderText = "Client";
            this.ClientNameColumn.Name = "ClientNameColumn";
            this.ClientNameColumn.ReadOnly = true;
            // 
            // RaisedBy
            // 
            this.RaisedBy.HeaderText = "Raised By";
            this.RaisedBy.Name = "RaisedBy";
            this.RaisedBy.ReadOnly = true;
            // 
            // AssignedTo
            // 
            this.AssignedTo.HeaderText = "Assigned To";
            this.AssignedTo.Name = "AssignedTo";
            this.AssignedTo.ReadOnly = true;
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
            this.dateFrom.Value = new System.DateTime(2005, 5, 2, 0, 0, 0, 0);
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
            this.dateFromLabel.Location = new System.Drawing.Point(14, 43);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(59, 13);
            this.dateFromLabel.TabIndex = 6;
            this.dateFromLabel.Text = "Date From:";
            // 
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.ForeColor = System.Drawing.Color.White;
            this.dateToLabel.Location = new System.Drawing.Point(24, 65);
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
            // noResultsText
            // 
            this.noResultsText.AutoSize = true;
            this.noResultsText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.noResultsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noResultsText.ForeColor = System.Drawing.Color.White;
            this.noResultsText.Location = new System.Drawing.Point(289, 138);
            this.noResultsText.Name = "noResultsText";
            this.noResultsText.Size = new System.Drawing.Size(425, 31);
            this.noResultsText.TabIndex = 9;
            this.noResultsText.Text = "No jiras match your search criteria";
            this.noResultsText.Visible = false;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(892, 595);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(85, 23);
            this.clearButton.TabIndex = 10;
            this.clearButton.Text = "Clear Results";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // issueTypes
            // 
            this.issueTypes.FormattingEnabled = true;
            this.issueTypes.Items.AddRange(new object[] {
            "Any"});
            this.issueTypes.Location = new System.Drawing.Point(525, 37);
            this.issueTypes.Name = "issueTypes";
            this.issueTypes.Size = new System.Drawing.Size(121, 21);
            this.issueTypes.TabIndex = 11;
            // 
            // issueTypeLabel
            // 
            this.issueTypeLabel.AutoSize = true;
            this.issueTypeLabel.ForeColor = System.Drawing.Color.White;
            this.issueTypeLabel.Location = new System.Drawing.Point(457, 41);
            this.issueTypeLabel.Name = "issueTypeLabel";
            this.issueTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.issueTypeLabel.TabIndex = 12;
            this.issueTypeLabel.Text = "Issue Type:";
            // 
            // clientName
            // 
            this.clientName.Location = new System.Drawing.Point(246, 62);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(187, 20);
            this.clientName.TabIndex = 13;
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.ForeColor = System.Drawing.Color.White;
            this.clientNameLabel.Location = new System.Drawing.Point(204, 65);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(36, 13);
            this.clientNameLabel.TabIndex = 14;
            this.clientNameLabel.Text = "Client:";
            // 
            // componentDropdown
            // 
            this.componentDropdown.FormattingEnabled = true;
            this.componentDropdown.Location = new System.Drawing.Point(246, 38);
            this.componentDropdown.Name = "componentDropdown";
            this.componentDropdown.Size = new System.Drawing.Size(187, 21);
            this.componentDropdown.TabIndex = 15;
            // 
            // componentLabel
            // 
            this.componentLabel.AutoSize = true;
            this.componentLabel.ForeColor = System.Drawing.Color.White;
            this.componentLabel.Location = new System.Drawing.Point(176, 41);
            this.componentLabel.Name = "componentLabel";
            this.componentLabel.Size = new System.Drawing.Size(64, 13);
            this.componentLabel.TabIndex = 16;
            this.componentLabel.Text = "Component:";
            // 
            // fixVersionLabel
            // 
            this.fixVersionLabel.AutoSize = true;
            this.fixVersionLabel.ForeColor = System.Drawing.Color.White;
            this.fixVersionLabel.Location = new System.Drawing.Point(457, 65);
            this.fixVersionLabel.Name = "fixVersionLabel";
            this.fixVersionLabel.Size = new System.Drawing.Size(64, 13);
            this.fixVersionLabel.TabIndex = 17;
            this.fixVersionLabel.Text = "Fix Version: ";
            // 
            // fixVersionDropdown
            // 
            this.fixVersionDropdown.FormattingEnabled = true;
            this.fixVersionDropdown.Location = new System.Drawing.Point(525, 60);
            this.fixVersionDropdown.Name = "fixVersionDropdown";
            this.fixVersionDropdown.Size = new System.Drawing.Size(121, 21);
            this.fixVersionDropdown.TabIndex = 18;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(989, 630);
            this.Controls.Add(this.fixVersionDropdown);
            this.Controls.Add(this.fixVersionLabel);
            this.Controls.Add(this.componentLabel);
            this.Controls.Add(this.componentDropdown);
            this.Controls.Add(this.clientNameLabel);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.issueTypeLabel);
            this.Controls.Add(this.issueTypes);
            this.Controls.Add(this.clearButton);
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
            this.MinimumSize = new System.Drawing.Size(1005, 668);
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
        private System.Windows.Forms.Label noResultsText;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ComboBox issueTypes;
        private System.Windows.Forms.Label issueTypeLabel;
        private System.Windows.Forms.TextBox clientName;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewLinkColumn JiraLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn SummaryText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RaisedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedTo;
        private System.Windows.Forms.ComboBox componentDropdown;
        private System.Windows.Forms.Label componentLabel;
        private System.Windows.Forms.Label fixVersionLabel;
        private System.Windows.Forms.ComboBox fixVersionDropdown;
    }
}

