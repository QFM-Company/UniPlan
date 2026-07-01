using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Update
{
    public class UpdateCourseSessionRequest
    {

        [Required<int>("معرف الكورس مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CourseOfferingID { get; set; }
        [Required<int>("معرف القاعة مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int HallID { get; set; }

        [Required<int>("معرف الفترة الزمنية مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int TimeSlotID { get; set; }

        public UpdateCourseSessionRequest(int courseOfferingID, int hallID, int timeSlotID)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            TimeSlotID = timeSlotID;
        }

        public UpdateCourseSessionRequest()
        {
        }

    }
}
