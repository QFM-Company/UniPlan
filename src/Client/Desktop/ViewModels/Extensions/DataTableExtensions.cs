using System.Data;

namespace ViewModels.Extensions
{
    public static class DataTableExtensions
    {
        public static void AddTermColumns(this DataTable table)
        {
            table.Columns.Add("معرف الفصل", typeof(int)).SetHidden(true);
            table.Columns.Add("نوع الفصل", typeof(string)).SetHidden(false);
            table.Columns.Add("السنة", typeof(int)).SetHidden(false);
        }

        public static void AddPeriodColumns(this DataTable table)
        {
            table.Columns.Add("معرف الفترة", typeof(int)).SetHidden(true);
            table.Columns.Add("وقت البداية", typeof(string)).SetHidden(false);
            table.Columns.Add("وقت النهاية", typeof(string)).SetHidden(false);
        }

        public static void AddTimeSlotColumns(this DataTable table)
        {
            table.Columns.Add("معرف القطعة الزمنية", typeof(int)).SetHidden(true);
            table.Columns.Add("اليوم", typeof(string)).SetHidden(false);

            table.AddPeriodColumns();
        }

        public static void AddPersonColumns(this DataTable table)
        {
            table.Columns.Add("معرف الشخص", typeof(int)).SetHidden(true);
            table.Columns.Add("الاسم الأول", typeof(string)).SetHidden(true);
            table.Columns.Add("الاسم الأوسط", typeof(string)).SetHidden(true);
            table.Columns.Add("الاسم الأخير", typeof(string)).SetHidden(true);

            var fullNameCol = table.Columns.Add("الاسم الكامل", typeof(string));

            fullNameCol.SetHidden(false);

            fullNameCol.Expression = "[الاسم الأول] + ' ' + [الاسم الأوسط] + ' ' + [الاسم الأخير]";
        }

        public static void AddAccountColumns(this DataTable table)
        {
            table.Columns.Add("معرف الحساب", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم الحساب", typeof(string)).SetHidden(false);
            table.Columns.Add("البريد الإلكتروني", typeof(string)).SetHidden(false);
        }

        public static void AddMajorColumns(this DataTable table)
        {
            table.Columns.Add("معرف التخصص", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم التخصص", typeof(string)).SetHidden(false);
        }

        public static void AddCourseColumns(this DataTable table)
        {
            table.Columns.Add("معرف المقرر", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم المقرر", typeof(string)).SetHidden(false);
            table.Columns.Add("عدد الساعات", typeof(int)).SetHidden(true);
            table.Columns.Add("رمز المقرر", typeof(string)).SetHidden(false);
        }

        public static void AddLectureColumns(this DataTable table)
        {
            table.Columns.Add("معرف المحاضرة", typeof(int)).SetHidden(true);
            table.Columns.Add("نوع المحاضرة", typeof(string)).SetHidden(false);
            table.Columns.Add("المدة", typeof(int)).SetHidden(true);
            table.AddCourseColumns();
        }

        public static void AddAcademicTermColumns(this DataTable table)
        {
            table.Columns.Add("معرف الفصل الدراسي", typeof(int)).SetHidden(true);
            table.Columns.Add("نوع الفصل", typeof(string)).SetHidden(false);
            table.Columns.Add("السنة", typeof(int)).SetHidden(false);
        }

        public static void AddHallColumns(this DataTable table)
        {
            table.Columns.Add("معرف القاعة", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم القاعة", typeof(string)).SetHidden(false);
            table.Columns.Add("المبنى", typeof(string)).SetHidden(false);
            table.Columns.Add("الطابق", typeof(int)).SetHidden(true);
            table.Columns.Add("معرف المدير المنشئ (القاعة)", typeof(int)).SetHidden(true);
        }

        public static void AddPeriodColumnsTyped(this DataTable table)
        {
            table.Columns.Add("معرف الفترة", typeof(int)).SetHidden(true);
            table.Columns.Add("وقت البداية", typeof(TimeSpan)).SetHidden(false);
            table.Columns.Add("وقت النهاية", typeof(TimeSpan)).SetHidden(false);
        }

        public static void AddTimeSlotColumnsTyped(this DataTable table)
        {
            table.Columns.Add("معرف القطعة الزمنية", typeof(int)).SetHidden(true);
            table.Columns.Add("اليوم", typeof(string)).SetHidden(false);
            table.AddPeriodColumnsTyped();
        }

        public static void AddAdministratorColumns(this DataTable table)
        {
            table.Columns.Add("معرف المدير", typeof(int)).SetHidden(true);
            table.Columns.Add("نشط", typeof(string)).SetHidden(false);

            table.AddPersonColumns();
            table.AddAccountColumns();
        }

        public static void AddStudentColumns(this DataTable table)
        {
            table.Columns.Add("معرف الطالب", typeof(int)).SetHidden(true);

            table.AddPersonColumns();
            table.AddAccountColumns();
            table.AddMajorColumns();
        }

        public static void AddCourseOfferingColumns(this DataTable table)
        {
            table.Columns.Add("معرف الشعبة", typeof(int)).SetHidden(true);
            table.Columns.Add("رقم الشعبة", typeof(int)).SetHidden(true);
            table.Columns.Add("معرف المدير المنشئ (العرض)", typeof(int)).SetHidden(true);

            table.AddAcademicTermColumns();
            table.AddLectureColumns();
        }

        public static void AddCoursePrerequisiteColumns(this DataTable table)
        {
            table.Columns.Add("معرف المتطلب", typeof(int)).SetHidden(true);

            table.Columns.Add("الرئيسي_معرف المقرر", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم المقرر", typeof(string)).SetHidden(false);
            table.Columns.Add("الرئيسي_عدد الساعات", typeof(int)).SetHidden(true);
            table.Columns.Add("رمز المقرر", typeof(string)).SetHidden(false);

            table.Columns.Add("المتطلب_معرف المقرر", typeof(int)).SetHidden(true);
            table.Columns.Add("اسم المتطلب", typeof(string)).SetHidden(false);
            table.Columns.Add("المتطلب_عدد الساعات", typeof(int)).SetHidden(true);
            table.Columns.Add("رمز المتطلب", typeof(string)).SetHidden(false);
        }

        public static void AddCourseSessionColumns(this DataTable table)
        {
            table.Columns.Add("معرف الجلسة", typeof(int)).SetHidden(true);
            table.Columns.Add("وقت البداية", typeof(TimeSpan)).SetHidden(false);
            table.Columns.Add("وقت النهاية", typeof(TimeSpan)).SetHidden(false);
            table.Columns.Add("معرف المدير المنشئ (الجلسة)", typeof(int)).SetHidden(true);
            table.Columns.Add("اليوم", typeof(string)).SetHidden(false);

            table.AddCourseOfferingColumns();
            table.AddHallColumns();
        }


        public static DataColumn SetHidden(this DataColumn column, bool hidden)
        {
            column.ExtendedProperties["IsHidden"] = hidden;
            return column;
        }

        public static bool IsHidden(this DataColumn column)
        {
            return column.ExtendedProperties.ContainsKey("IsHidden") && (bool)column.ExtendedProperties["IsHidden"];
        }
    }
}