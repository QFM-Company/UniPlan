using Presentation.Forms.OperationsForms;
using System.Data;
using ViewModels;
using ViewModels.Extensions;

namespace Presentation.Forms.ManagementForms
{
    public partial class StudentsManagementForm : BaseManagementForm
    {
        public StudentsManagementForm(StudentsViewModel studentsViewModel)
            : base(studentsViewModel, new BaseOperationForm())
        {
            InitializeComponent();
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToStudent();
        }
    }
}
