using Business.DTOs.Requests;

namespace Business.Interfaces
{
    public interface IPeopleService
    {
        Task<bool> Save(PersonRequest request);
    }
}
