using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class PeriodOperationForm : BaseOperationForm
    {
        public PeriodOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            TimeSpan.TryParse(txtStartTime.Text, out TimeSpan startTime);
            TimeSpan.TryParse(txtEndTime.Text, out TimeSpan endTime);

            PeriodRequest period = new PeriodRequest
            {
                StartTime = startTime,
                EndTime = endTime
            };

            Model = (Person)period;
        }

        public override void LoadData()
        {
            PeriodResponse period = Model.ToPeriod();

            txtStartTime.Text = period?.StartTime.ToString();
            txtEndTime.Text = period?.EndTime.ToString();
        }

        public override void InitializeFields()
        {
            txtStartTime.Text = string.Empty;
            txtEndTime.Text = string.Empty;
        }
    }
}
