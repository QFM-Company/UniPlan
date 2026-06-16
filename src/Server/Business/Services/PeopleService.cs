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
        private Person? _person;
        
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
            _person = null;
        }

        public async Task<PersonResponse?> AddPersonAsync(PersonRequest request)
        {
            _person = new Person();
            _person = _person.RequestToPerson(request);

            if(_person != null)
            {
                _person.PersonID = await _peopleRepository.AddPersonAsync(_person);

                if (_person.PersonID != -1)
                    return _person.PersonToResponse();
            }

            return null;
        }
    }
}
