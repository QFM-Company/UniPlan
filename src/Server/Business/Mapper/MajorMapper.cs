using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class MajorMapper
    {
        public static Major ToMajor(this MajorRequest request)
        {
            return new Major(-1, request.MajorName, request.ParentMajorID);
        }

        public static void UpdateMajor(this Major major, MajorRequest? request)
        {
            if (request == null)
                return;

            major.MajorName = request.MajorName;
        }

        public static MajorResponse ToResponse(this Major major)
        {
            return new MajorResponse(major.MajorID, major.MajorName);
        }
    }
}
