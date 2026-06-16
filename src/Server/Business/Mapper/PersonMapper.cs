using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class PersonMapper
    {
        public static Person? RequestToPerson(this Person person, PersonRequest? request)
        {
            if(request != null)
                return new Person(request.PersonID, request.FirstName, request.MiddleName, request.LastName);

            return null;
        }

        public static PersonResponse PersonToResponse(this Person person)
        {
            return new PersonResponse(person.PersonID, person.FirstName, person.MiddleName, person.LastName);
        }
    }
}
