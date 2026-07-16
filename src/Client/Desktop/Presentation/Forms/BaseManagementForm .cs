using ViewModels.Interfaces;

namespace Presentation.Forms
{
    public partial class BaseManagementForm : Form
    {
        private readonly IViewModel _viewModel;

        public BaseManagementForm(IViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            _RegisterEvents();
        }

        private void _RegisterEvents()
        {
            dataGrid.OnLoadData += _viewModel.GetDataView;
            dataGrid.OnGetByID += _viewModel.GetDataViewByID;
        }
    }
}
