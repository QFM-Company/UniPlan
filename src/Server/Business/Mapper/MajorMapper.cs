using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.Entities;

namespace Business.Mapper
{
    public static class MajorMapper
    {
        public static Major? RequestToMajor(this MajorRequest? request, int majorID = -1)
        {
            if(request != null)
                return new Major(majorID, request.MajorName);

            return null;
        }

        public static void UpdateMajorFromRequest(this Major major, MajorRequest request)
        {
            major.MajorName = request.MajorName;
        }

        public static  MajorResponse MajorToResponse(this Major major)
        {
            return new MajorResponse(major.MajorID, major.MajorName);
        }
    }
}
