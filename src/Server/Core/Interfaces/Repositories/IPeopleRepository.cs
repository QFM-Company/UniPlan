using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IPeopleRepository
    {
        Task<int> AddPerson(Person person);
    }
}
