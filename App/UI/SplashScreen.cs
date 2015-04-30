using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            InitializeComponent();
            progressBarTimer.Start();
        }

        private void progressBarTimer_Tick(object sender, System.EventArgs e)
        {
            progressBar.Increment(1);
            if(progressBar.Value == 100)
                progressBarTimer.Stop();
        }
    }
}
