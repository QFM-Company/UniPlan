using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Requests.Create;
using Business.DTOs.Requests.Update;
using Business.DTOs.Responses;
using Business.Interfaces;
using Business.Mapper;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
        {
            _studentCourseRepository = studentCourseRepository;
        }

        public async Task<bool> DeleteStudentCourseAsync(int enrolmentD)
        {
            return await _studentCourseRepository.DeleteStudentCourseAsync(enrolmentD);
        }

        public async Task<StudentCourseResponse?> AddStudentCourseAsync(CreateStudentCourseRequest request)
        {
            StudentCourse studentCourse = request.ToStudentCourse();

            studentCourse.EnrolmentID = await _studentCourseRepository.AddStudentCourseAsync(studentCourse);

            if (studentCourse.EnrolmentID > 0)
                return await GetStudentCourseByIDAsync(studentCourse.EnrolmentID);

            return null;
        }

        public async Task<bool> UpdateStudentCourseAsync(UpdateStudentCourseRequest request, int enrolmentD)
        {
            StudentCourse? studentCourse = await _studentCourseRepository.GetStudentCourseByIDAsync(enrolmentD);

            studentCourse?.UpdateStudentCourse(request);

            if (studentCourse != null)
                return await _studentCourseRepository.UpdateStudentCourseAsync(studentCourse);

            return false;
        }

        public async Task<IEnumerable<StudentCourseResponse>?> GetStudentCoursesByStudentIDAsync(int studentID)
        {
            IEnumerable<StudentCourse>? studentCourses = await _studentCourseRepository.GetStudentCoursesByStudentIDAsync(studentID);
            return studentCourses?.Select(m => m.ToResponse());
        }

        public async Task<StudentCourseResponse?> GetStudentCourseByIDAsync(int enrolmentD)
        {
            StudentCourse? studentCourse = await _studentCourseRepository.GetStudentCourseByIDAsync(enrolmentD);
            return studentCourse != null ? studentCourse.ToResponse() : null;
        }
    }
}
