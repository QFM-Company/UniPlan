using Client.Models;
using System;

namespace Presentation.Forms.OperationsForms
{
    public partial class HallOperationForm : BaseOperationForm
    {
        public HallOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            HallModel hall = (HallModel)Model ?? new HallModel();

            uniPlanTextBox4.TryGetInt(out int createdByAdminID);
            uniPlanTextBox3.TryGetInt(out int floor);

            hall.Floor = floor;
            hall.CreatedByAdminID = createdByAdminID;

            hall.HallName = uniPlanTextBox1.Text.ToString() ?? string.Empty;
            hall.Building = uniPlanTextBox2.Text.ToString() ?? string.Empty;

            Model = (BaseModel)hall;
        }

        public override void LoadData()
        {
            HallModel hall = (HallModel)Model ?? new HallModel();

            uniPlanTextBox4.Text = hall?.CreatedByAdminID.ToString();
            uniPlanTextBox3.Text = hall?.Floor.ToString();
            uniPlanTextBox1.Text = hall?.HallName;
            uniPlanTextBox2.Text = hall?.Building;
        }
    }
}
