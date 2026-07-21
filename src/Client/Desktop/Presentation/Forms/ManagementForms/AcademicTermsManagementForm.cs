using Presentation.Forms.OperationsForms;
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
using ViewModels.Extensions;

namespace Presentation.Forms.ManagementForms
{
    public partial class AcademicTermsManagementForm : BaseManagementForm
    {
        public AcademicTermsManagementForm(AcademicTermsViewModel academicTermsViewModel)
            : base(academicTermsViewModel, new BaseOperationForm())
        {
            InitializeComponent();
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToAcademicTerm();
        }
    }
}
