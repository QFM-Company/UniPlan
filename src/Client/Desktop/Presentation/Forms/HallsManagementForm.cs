using ViewModels.Interface;

namespace Presentation.Forms
{
    public partial class HallsManagement : Form
    {
        private readonly IHallsViewModel _hallsViewModel;

        public HallsManagement(IHallsViewModel hallsViewModel)
        {
            InitializeComponent();
            _hallsViewModel = hallsViewModel;

            dynamicDataGrid1.OnLoadData += _hallsViewModel.GetDataView;
        }
    }
}
