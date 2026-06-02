using Business.DTOs.Requests;
using Core.Entities;
using Core.Enums;
using Core.Interfaces.Repositories;
using Business.Interfaces;

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

        public async Task<bool> AddPersonAsync(PersonRequest request)
        {
            _person = new Person(request.PersonID, request.FirstName, request.MiddleName, request.LastName);

            if (_person != null)
            {
                _person.PersonID = await _peopleRepository.AddPersonAsync(_person);
                return _person?.PersonID != -1;
            }

            return false;
        }
    }
}
