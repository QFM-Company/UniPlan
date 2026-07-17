using Client.Models;
using Client.Services;
using Controls.UserControls;
using Presentation.Forms.Enums;
using Presentation.Forms.OperationsForms;
using System.Data;
using System.Threading.Tasks;
using ViewModels.Interfaces;

namespace Presentation.Forms
{
    public partial class BaseManagementForm : Form
    {
        private readonly IViewModel _viewModel;
        private BaseOperationForm _operationForm;
        protected BaseModel? _model;

        public BaseManagementForm(IViewModel viewModel, BaseOperationForm operationForm) : this()
        {
            _viewModel = viewModel;
            _operationForm = operationForm;

            if (!DesignMode)
            {
                _RegisterEvents();
            }
        }

        protected BaseManagementForm()
        {
            InitializeComponent();
        }

        public void HandleUpdateClick(object sender, DataRowView selectedRow)
        {
            if (DesignMode)
                return;

            UpdateModel(selectedRow);

            _operationForm.Model = _model;
            _operationForm.Mode = Mode.Update;
            _operationForm.ShowDialog();

            Refresh(sender);
        }
        
        public void HandleAddClick(object sender)
        {
            if (DesignMode)
                return;

            _operationForm.Mode = Mode.Add;
            _operationForm.ShowDialog();

            Refresh(sender);
        }

        public async Task<bool> HandleSaveClick(BaseModel model, Mode mode)
        {
            try
            {
                HallModel hall = (HallModel)model;

                if (mode == Mode.Add)
                {
                    return await _viewModel.CreateAsync(hall);
                }
                else
                {
                    return await _viewModel.UpdateAsync(hall);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        public async void HandleDeleteClick(object sender, DataRowView selectedRow)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد أنك تريد الحذف؟", "UniPlan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            try
            {
                UpdateModel(selectedRow);
                int id = GetModelId();
                if (await _viewModel.DeleteAsync(id))
                {
                    MessageBox.Show("تمت العملية بنجاح", "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Refresh(sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UniPlan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public virtual int GetModelId()
        {
            return 0;
        }

        public virtual void UpdateModel(DataRowView selectedRow)
        {

        }


        private void Refresh(object sender)
        {
            DynamicDataGrid dynamic = (DynamicDataGrid)sender;
            dynamic.RefreshData();
        }

        private void _RegisterEvents()
        {
            _operationForm.OnSaveClick += HandleSaveClick;
            dataGrid.OnLoadData += _viewModel.GetDataView;
            dataGrid.OnGetByID += _viewModel.GetDataViewByID;
            dataGrid.OnDeleteRow += HandleDeleteClick;
            dataGrid.OnUpdateRow += HandleUpdateClick;
            dataGrid.OnAddRow += HandleAddClick;
        }
    }
}