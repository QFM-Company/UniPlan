using Business.DTOs.Requests;
using Core.Entities;
using Core.Interfaces.Repositories;
using Business.Interfaces;
using Business.DTOs.Responses;
using Business.Mapper;

namespace Business.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepository _peopleRepository;
        
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<PersonResponse?> AddPersonAsync(PersonRequest request)
        {
            Person person = request.ToPerson();


            person.PersonID = await _peopleRepository.AddPersonAsync(person);

            if (person.PersonID != -1)
                return person.ToResponse();
            

            return null;
        }
    }
}
