using Business.DTOs.Requests;
using Core.Entities;
using Core.Interfaces.Repositories;
using Business.Interfaces;
using Business.DTOs.Responses;

namespace Business.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepository _peopleRepository;
        private Person? _person;
        
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
            _person = null;
        }

        public async Task<PersonResponse?> AddPersonAsync(PersonRequest request)
        {
            _person = new Person(request.PersonID, request.FirstName, request.MiddleName, request.LastName);
            _person.PersonID = await _peopleRepository.AddPersonAsync(_person);
            return new PersonResponse(_person.PersonID, _person.FirstName, _person.MiddleName, _person.LastName);
        }
    }
}
