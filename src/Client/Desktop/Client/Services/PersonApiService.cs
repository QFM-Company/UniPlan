using Client.Models.Requests;

namespace Client.Services
{
    public class PersonApiService
    {
        private readonly ApiService _apiService;

        public PersonApiService(ApiService apiService)
        {
            _apiService = apiService;
            _apiService.SubUri = "api/persons";
        }

        public async Task<PersonRequest?> PostPersonAsync(PersonRequest model)
        {
            return await _apiService.PostAsync(model);
        }
    }
}