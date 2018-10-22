using System.Windows.Forms;


namespace MtX.Nro2Nsp
{
    public partial class PleaseWait : Form
    {
        public PleaseWait()
        {
            InitializeComponent();
            progressBar.Style = ProgressBarStyle.Marquee;
        }
    }
}
