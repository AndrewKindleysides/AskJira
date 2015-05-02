using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using Domain;

namespace UI
{
    public partial class MainWindow : Form
    {
        public User AppUser;
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
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            var mlcJiras = PerformSearchQuery();
            
            ClearOutTheTable();
            if (mlcJiras.Count > 0)
            {
                PopulateGridWithResults(mlcJiras);
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

        private List<Jira> PerformSearchQuery()
        {
            var jiraRequest = new JiraRequest(AppUser.AuthenticationToken());
            var mlcJiras = jiraRequest.SearchMLCJiras(searchBox.Text, dateFrom.Value, dateTo.Value);
            return mlcJiras;
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
                jiraGrid.Rows.Add(index, jira.Name, jira.Summary, jira.DateCreated, jira.Client);
            }
        }

        private void clearButton_Click(object sender, System.EventArgs e)
        {
            ClearOutTheTable();
        }
    }
}
