using Client.Models;
using Client.Services;
using Presentation.Forms.Enums;
using Presentation.Forms.OperationsForms;
using System.Configuration;
using System.Data;
using ViewModels;
using ViewModels.Extensions;

namespace Presentation.Forms
{
    public partial class HallsManagementForm : BaseManagementForm
    {       
        public HallsManagementForm(HallsViewModel hallsViewModel)
            : base(hallsViewModel, new HallOperationForm())
        {
            InitializeComponent();
        }

        public override int GetModelId()
        {
            if (_model == null)
                return 0;

            var hall = (HallModel)_model;
            return hall.HallID;
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToHall();
        }

    }
}