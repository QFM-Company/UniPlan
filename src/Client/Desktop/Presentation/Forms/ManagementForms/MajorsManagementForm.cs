using Client.Models;
using Client.Services;
using Presentation.Forms.OperationsForms;
using System.Data;
using ViewModels;
using ViewModels.Extensions;

namespace Presentation.Forms
{
    public partial class MajorsManagementForm : BaseManagementForm
    {
        public MajorsManagementForm(MajorsViewModel majorsViewModel)
            : base(majorsViewModel, new MajorOperationForm())
        {
            InitializeComponent();
        }

        public override int GetModelId()
        {
            if (_model == null) 
                return 0;

            var major = (MajorModel)_model;
            return major.MajorID;
        }

        public override void UpdateModel(DataRowView selectedRow)
        {
            _model = selectedRow.ToMajor();
        }
    }
}