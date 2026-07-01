using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.ExternalServices;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IValidationService _validationService;

        public PeopleService(IPeopleRepository peopleRepository, IValidationService validationService)
        {
            _validationService = validationService;
            _peopleRepository = peopleRepository;
        }

        public async Task<PersonResponse?> AddPersonAsync(PersonRequest request)
        {
            _validationService.Validate(request);

            Person person = request.ToPerson();

            person.PersonID = await _peopleRepository.AddPersonAsync(person);

            if (person.PersonID != -1)
                return person.ToResponse();
            
            return null;
        }
    }
}
