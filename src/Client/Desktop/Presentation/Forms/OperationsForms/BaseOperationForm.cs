using Presentation.Forms.Enums;
using Client.Models;

namespace Presentation.Forms.OperationsForms
{
    public partial class BaseOperationForm : Form
    {
        public BaseModel? Model { get; set; }
        public Mode Mode { get; set; }
        public event Func<BaseModel, Mode, Task<bool>>? OnSaveClick;

        public BaseOperationForm()
        {
            InitializeComponent();
        }

        public virtual void UpdateModel()
        {

        }

        public virtual void LoadData()
        {

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            UpdateModel();

            if (OnSaveClick == null || Model == null)
                return;

            bool res = await OnSaveClick.Invoke(Model, Mode);

            if (res)
            {
                MessageBox.Show("تم الحفظ بنجاح", "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void BaseOperationForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}