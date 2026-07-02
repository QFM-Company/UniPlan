using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class StudentTermMapper
    {
        public static StudentTerm ToStudentTerm(this StudentTermRequest request, int regestirationID = 0)
        {
            return new StudentTerm(regestirationID, request.StudentID, new AcademicTerm(request.AcademicTermID));
        }

        public static StudentTermResponse ToResponse(this StudentTerm studentTerm)
        {
            return new StudentTermResponse(studentTerm.RegistrationID, studentTerm.StudentID, studentTerm.AcademicTerm?.ToResponse());
        }

    }
}
