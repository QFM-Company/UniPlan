using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class MajorOperationForm : BaseOperationForm
    {
        public MajorOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            txtParentMajorID.TryGetInt(out int parentMajorID);

            MajorRequest major = new MajorRequest
            {
                MajorName = txtMajorName.Text,
                ParentMajorID = parentMajorID
            };

            Model = (Person)major;
        }

        public override void LoadData()
        {
            MajorResponse major = Model.ToMajor();

            txtMajorName.Text = major?.MajorName;
            txtParentMajorID.Text = major?.MajorID.ToString();
        }

        public override void InitializeFields()
        {
            txtMajorName.Text = string.Empty;
            txtParentMajorID.Text = string.Empty;
        }
    }
}
