using Client.Models.Requests;
using Client.Models.Responses;

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

        public async Task<PersonResponse?> CreatePersonAsync(PersonRequest person)
        {
            return await _apiService.PostAsync<PersonRequest, PersonResponse>(person);
        }
    }
}