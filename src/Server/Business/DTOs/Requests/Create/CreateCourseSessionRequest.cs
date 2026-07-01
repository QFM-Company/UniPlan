using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Responses;
using Core.Entities;
using Infrastructure.ExternalServices.Validation.Attributes;

namespace Business.DTOs.Requests.Create
{
    public class CreateCourseSessionRequest
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

        [Required<int>("معرف الادمن مطلوب")]
        [Range<int>("يجب ان يكون المعرف اكبر تماما من 0", 1, int.MaxValue)]
        public int CreatedByAdminID { get; set; }

        public CreateCourseSessionRequest(int courseOfferingID, int hallID, int timeSlotID, int createdByAdminID)
        {
            CourseOfferingID = courseOfferingID;
            HallID = hallID;
            TimeSlotID = timeSlotID;
            CreatedByAdminID = createdByAdminID;
        }

        public CreateCourseSessionRequest()
        {
        }
    }
}
