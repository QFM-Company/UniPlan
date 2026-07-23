using Client.Models;
using Client.Models.Requests;
using Client.Models.Responses;
using ViewModels.Extensions;

namespace Presentation.Forms.OperationsForms
{
    public partial class AcademicTermOperationForm : BaseOperationForm
    {
        public AcademicTermOperationForm()
        {
            InitializeComponent();
        }

        public override void UpdateModel()
        {
            txtTermType.TryGetInt(out int termType);
            txtTermYear.TryGetInt(out int termYear);

            AcademicTermRequest term = new AcademicTermRequest
            {
                TermType = termType,
                TermYear = termYear
            };

            Model = (Person)term;
        }

        public override void LoadData()
        {
            AcademicTermResponse term = Model.ToAcademicTerm();

            txtTermType.Text = term?.TermType;
            txtTermYear.Text = term?.TermYear.ToString();
        }

        public override void InitializeFields()
        {
            txtTermType.Text = string.Empty;
            txtTermYear.Text = string.Empty;
        }
    }
}
