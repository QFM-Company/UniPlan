using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;

namespace Presentation.Forms
{
    public partial class MajorsManagementForm : BaseManagementForm
    {
        public MajorsManagementForm(MajorsViewModel majorsViewModel) : base(majorsViewModel)
        {
        }
    }
}
