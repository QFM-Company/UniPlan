using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using System;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class HallOperationForm : BaseOperationForm
    {
        public HallOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateMode()
        {
            uniPlanTextBox4.Enabled = false;
        }

        public override void AddMode()
        {
            uniPlanTextBox4.Enabled = true;
        }

        public override void UpdateModel()
        {
            HallRequest hall = new HallRequest();

            uniPlanTextBox4.TryGetInt(out int createdByAdminID);
            uniPlanTextBox3.TryGetInt(out int floor);

            hall.Floor = floor;
            hall.CreatedByAdminID = createdByAdminID;

            hall.HallName = uniPlanTextBox1.Text.ToString() ?? string.Empty;
            hall.Building = uniPlanTextBox2.Text.ToString() ?? string.Empty;

            Model = (Person)hall;
        }

        public override void LoadData()
        {
            HallResponse hall = Model.ToHall();

            uniPlanTextBox4.Text = hall?.CreatedByAdminID.ToString();
            uniPlanTextBox3.Text = hall?.Floor.ToString();
            uniPlanTextBox1.Text = hall?.HallName;
            uniPlanTextBox2.Text = hall?.Building;
        }

        public override void InitializeFields()
        {
            uniPlanTextBox4.Text = string.Empty;
            uniPlanTextBox3.Text = string.Empty;
            uniPlanTextBox1.Text = string.Empty;
            uniPlanTextBox2.Text = string.Empty;
        }
    }
}
