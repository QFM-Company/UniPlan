namespace Business.DTOs.Requests.Update
{
    public class SyncStudentPassedCoursesRequest
    {
        public List<int> PassedCourseIds { get; set; }


        public SyncStudentPassedCoursesRequest(List<int> passedCourseIds)
        {
            PassedCourseIds = passedCourseIds;
        }
        public SyncStudentPassedCoursesRequest()
        {
            PassedCourseIds = new List<int>();
        }
    }
}
