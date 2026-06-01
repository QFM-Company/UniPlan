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
        private Mode _mode;
        private Person? _person;
        
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
            _person = null;
            _mode = Mode.Add;
        }

        public async Task<bool> AddNewPerson()
        {
            if(_person != null)
            {
                _person.PersonID = await _peopleRepository.AddPerson(_person);
                return _person?.PersonID != -1;
            }

            return false;
        }

        public async Task<bool> Save(PersonRequest request)
        {
            _person = new Person(request.PersonID, request.FirstName, request.MiddleName, request.LastName);

            switch (_mode)
            {
                case Mode.Add:
                    if (await AddNewPerson())
                    {
                        _mode = Mode.Update;
                        return true;
                    }
                    else
                        return false;

                default: return false;        
            }
        }
    }
}
