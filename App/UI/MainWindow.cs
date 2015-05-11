using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;
using Domain;

namespace UI
{
    public partial class MainWindow : Form
    {
        public User AppUser;
        private JiraRequest _jiraRequest;

        public MainWindow()
        {
            AppUser = new User();
            ShowScreen(SplashScreen);
            InitializeComponent();
        }

        private static void ShowScreen(ThreadStart screen)
        {
            var thread = new Thread(screen);
            thread.Start();
            Thread.Sleep(3000);
            thread.Abort();
        }

        private void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            using (var loginScreen = new LoginWindow())
            {
                loginScreen.ShowDialog();
                AppUser.Username = loginScreen.Username;
                AppUser.Password = loginScreen.Password;
            }
            _jiraRequest = new JiraRequest(AppUser.AuthenticationToken());
            PopulateIssueTypesDropdown();
            PopulateComponentDropdown();
            PopulateFixVersionDropdown();
        }

        private void PopulateFixVersionDropdown()
        {
            fixVersionDropdown.DataSource = new BindingSource(_jiraRequest.Versions(), null);
            fixVersionDropdown.DisplayMember = "Value";
            fixVersionDropdown.ValueMember = "Key";
        }

        private void PopulateComponentDropdown()
        {
            componentDropdown.DataSource = new BindingSource(_jiraRequest.Components(), null);
            componentDropdown.DisplayMember = "Value";
            componentDropdown.ValueMember = "Key";
        }

        private void PopulateIssueTypesDropdown()
        {
            var jiraIssueTypes = _jiraRequest.IssueTypes();
            foreach (var issuetype in jiraIssueTypes)
            {
                issueTypes.Items.Add(issuetype);
            }
            issueTypes.SelectedIndex = 0;
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            var mlcJiras = PerformSearchQuery();
            jiraSearchResultTotal.Text = mlcJiras.Total.ToString(CultureInfo.InvariantCulture);
            ClearOutTheTable();
            if (mlcJiras.Total > 0)
            {
                PopulateGridWithResults(mlcJiras.Jiras);
            }
            else
            {
                DisplayNoResultsMessage();
            }
        }

        private void ClearOutTheTable()
        {
            jiraGrid.Rows.Clear();
        }

        private QueryResult PerformSearchQuery()
        {
            return _jiraRequest.SearchMLCJiras(new SearchItem(dateFrom.Value, dateTo.Value)
            {
                Client = clientName.Text,
                Component =  GetIdFromDropdown(componentDropdown.SelectedItem),
                Version = GetIdFromDropdown(fixVersionDropdown.SelectedItem),
                IssueType = issueTypes.SelectedItem.ToString(),
                SearchText = searchBox.Text
            });
        }

        private string GetIdFromDropdown(object dropdown)
        {
            return ((KeyValuePair<int,string>)dropdown).Key.ToString();
        }

        private void DisplayNoResultsMessage()
        {
            noResultsText.Visible = true;
        }

        private void PopulateGridWithResults(IReadOnlyList<Jira> mlcJiras)
        {
            noResultsText.Visible = false;
            for (var index = 0; index < mlcJiras.Count; index++)
            {
                var jira = mlcJiras[index];
                jiraGrid.Rows.Add(index, jira.Name, jira.Summary, jira.DateCreated, jira.Client, jira.Reporter, jira.Assignee);
            }
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            ClearOutTheTable();
        }

        private void jiraGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var fileName = string.Format("https://jira.advancedcsg.com/browse/{0}", jiraGrid.CurrentCell.Value);
                System.Diagnostics.Process.Start(fileName);
            }
        }
    }
}
