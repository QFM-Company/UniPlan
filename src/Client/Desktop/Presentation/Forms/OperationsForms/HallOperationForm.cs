using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
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
            txtCreatedByAdminID.Enabled = false;
        }

        public override void AddMode()
        {
            txtCreatedByAdminID.Enabled = true;
        }

        public override void UpdateModel()
        {
            HallRequest hall = new HallRequest();

            txtCreatedByAdminID.TryGetInt(out int createdByAdminID);
            txtFloor.TryGetInt(out int floor);

            hall.Floor = floor;
            hall.CreatedByAdminID = createdByAdminID;

            hall.HallName = txtHallName.Text ?? string.Empty;
            hall.Building = txtBuilding.Text ?? string.Empty;

            Model = (Person)hall;
        }

        public override void LoadData()
        {
            HallResponse hall = Model.ToHall();

            txtCreatedByAdminID.Text = hall?.CreatedByAdminID.ToString();
            txtFloor.Text = hall?.Floor.ToString();
            txtHallName.Text = hall?.HallName;
            txtBuilding.Text = hall?.Building;
        }

        public override void InitializeFields()
        {
            txtCreatedByAdminID.Text = string.Empty;
            txtFloor.Text = string.Empty;
            txtHallName.Text = string.Empty;
            txtBuilding.Text = string.Empty;
        }
    }
}
