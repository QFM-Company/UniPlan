using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class PersonMapper
    {
        public static Person ToPerson(this PersonRequest request)
        {
            return new Person(-1, request.FirstName, request.MiddleName, request.LastName);
        }

        public static void UpdatePerson(this Person person, PersonRequest? request)
        {
            if (request == null)
                return;

            person.FirstName = request.FirstName;
            person.MiddleName = request.MiddleName;
            person.LastName = request.LastName;
        }

        public static PersonResponse ToResponse(this Person person)
        {
            return new PersonResponse(person.PersonID, person.FirstName, person.MiddleName, person.LastName);
        }
    }
}
