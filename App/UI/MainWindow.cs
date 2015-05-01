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

        private void ShowScreen(ThreadStart screen)
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
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
            var jiraRequest = new JiraRequest(AppUser.AuthenticationToken());
            var mlcJiras = jiraRequest.SearchMLCJiras(searchBox.Text);

            jiraGrid.Rows.Clear();
            
            for (var index = 0; index < mlcJiras.Count; index++)
            {
                var jira = mlcJiras[index];
                jiraGrid.Rows.Add(index,jira.Name, jira.Summary, jira.DateCreated, jira.Client);
            }
        }
    }
}
