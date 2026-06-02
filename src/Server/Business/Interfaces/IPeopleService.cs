using Business.DTOs.Requests;
using Business.DTOs.Responses;

namespace Business.Interfaces
{
    public interface IPeopleService
    {
        Task<PersonResponse?> AddPersonAsync(PersonRequest request);
    }
}
