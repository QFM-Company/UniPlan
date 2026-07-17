using Controls.Customs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Controls.UserControls
{
    public partial class SearchControl : UserControl
    {
        public UniPlanTextBox TextBox
        {
            get => txtSearch;
        }


        public SearchControl()
        {
            InitializeComponent();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "بحث حسب المعرف")
            {
                txtSearch.Text = "";
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "بحث حسب المعرف";
            }
        }
    }
}
