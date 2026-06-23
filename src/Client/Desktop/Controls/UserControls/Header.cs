using System;
using System.Windows.Forms;
using System.Drawing;

namespace Controls.UserControls
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => lbHeader.Text;
            set => lbHeader.Text = value;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}