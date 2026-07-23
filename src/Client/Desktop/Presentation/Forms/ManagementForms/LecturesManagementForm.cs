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
using ViewModels.Extensions;
using ViewModels.Views;

namespace Presentation.Forms.ManagementForms
{
    public partial class LecturesManagementForm : BaseManagementForm
    {
        public LecturesManagementForm(LecturesViewModel lecturesViewModel)
            : base(lecturesViewModel, new LectureOperationForm())
        {
            InitializeComponent();
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToLecture();
        }
    }
}
