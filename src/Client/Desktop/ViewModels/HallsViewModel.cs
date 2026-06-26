using Business.DTOs.Responses;
using System.Data;
using Core.Interfaces.Repositories;

namespace ViewModels
{
    public class HallsViewModel
    {

        private readonly IHallRepository _hallRepository;
        public List<HallResponse> HallsList { get; set; }

        public HallsViewModel(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;
            HallsList = new List<HallResponse>();
        }

        public DataView GetDataView()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Hall ID");
            table.Columns.Add("Hall Name");
            table.Columns.Add("Building");
            table.Columns.Add("Floor");

            foreach (var hall in HallsList)
            {
                table.Rows.Add(
                    hall.HallID,
                    hall.HallName,
                    hall.Building,
                    hall.Floor
                );
            }

            return table.DefaultView;
        }


        public async Task LoadHallsAsync()
        {
            var halls = await _hallRepository.GetPagedHallsAsync();

            HallsList.Clear();

            if (halls == null)
                return;

            foreach (var hall in halls)
            {
                HallsList.Add(new HallResponse(
                    hall.HallID,
                    hall.HallName,
                    hall.Building,
                    hall.Floor,
                    hall.CreatedByAdminID
                ));
            }
        }
    }
}