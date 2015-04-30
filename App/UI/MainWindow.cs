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
            var jiraRequest = new JiraRequest(AppUser.AuthenticationToken());
            var jiras = jiraRequest.MLCT3AwaitingTriage();
            var str = "";
        }
    }
}
