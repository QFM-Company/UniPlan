using Client.Models;
using Client.Services;
using Presentation.Forms.OperationsForms;
using System.Data;
using ViewModels.Extensions;
using ViewModels.Views;

namespace Presentation.Forms
{
    public partial class MajorsManagementForm : BaseManagementForm
    {
        public MajorsManagementForm(MajorsViewModel majorsViewModel)
            : base(majorsViewModel, new MajorOperationForm())
        {
            InitializeComponent();
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToMajor();
        }
    }
}