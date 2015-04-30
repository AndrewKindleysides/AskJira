using System.Windows.Forms;
using Domain;

namespace UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {

            var jiraRequest = new JiraRequest("this will be created from the login screen");
            var jiras = jiraRequest.MLCT3AwaitingTriage();
            var str = "";
        }
    }
}
