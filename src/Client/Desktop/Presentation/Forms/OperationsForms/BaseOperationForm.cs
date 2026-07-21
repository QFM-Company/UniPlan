using Presentation.Forms.Enums;
using Client.Models;

namespace Presentation.Forms.OperationsForms
{
    public partial class BaseOperationForm : Form
    {
        public BaseModel? Model { get; set; }
        public Mode Mode { get; set; }

        public event Func<BaseModel, Mode, Task<bool>>? OnSaveClick;

        public int Id { get; set; }

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

        public virtual void UpdateMode()
        {

        }

        public virtual void AddMode()
        {

        }

        public virtual void InitializeFields()
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
            InitializeFields();

            if (Mode == Mode.Update)
            {
                lblFormName.Text = $"واجهة التعديل";
                UpdateMode();
                LoadData();
            }
            else
            {
                lblFormName.Text = "واجهة الأضافة";
                AddMode();
            }
        }
    }
}