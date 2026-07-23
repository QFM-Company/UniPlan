using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class TimeSlotOperationForm : BaseOperationForm
    {
        public TimeSlotOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            txtDay.TryGetInt(out int day);
            txtPeriodID.TryGetInt(out int periodID);

            TimeSlotRequest timeSlot = new TimeSlotRequest
            {
                Day = day,
                PeriodID = periodID
            };

            Model = (Person)timeSlot;
        }

        public override void LoadData()
        {
            TimeSlotResponse timeSlot = Model.ToTimeSlot();

            txtDay.Text = timeSlot?.Day;
            txtPeriodID.Text = timeSlot?.Period?.PeriodID.ToString();
        }

        public override void InitializeFields()
        {
            txtDay.Text = string.Empty;
            txtPeriodID.Text = string.Empty;
        }
    }
}
