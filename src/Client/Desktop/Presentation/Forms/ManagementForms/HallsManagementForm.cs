using Presentation.Forms.OperationsForms;
using System.Data;
using ViewModels.Extensions;
using ViewModels.Views;

namespace Presentation.Forms
{
    public partial class HallsManagementForm : BaseManagementForm
    {       
        public HallsManagementForm(HallsViewModel hallsViewModel)
            : base(hallsViewModel, new HallOperationForm())
        {
            InitializeComponent();
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToHall();
        }

    }
}