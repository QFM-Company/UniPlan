using Core.Interfaces.ExternalServices;
using Microsoft.Data.SqlClient;

namespace Infrastructure.ExternalServices
{
    public class ExceptionService : IExceptionService
    {
        private string _GetCustomSqlExceptionMessage(SqlException ex)
        {
            string exceptionMessage = (ex.Number % 100) switch
            {
                1 => "حدث خطأ في التحقق من البيانات. يرجى مراجعة المدخلات",
                2 => "البيانات المدخلة موجودة مسبقاً. يرجى إدخال بيانات جديدة",
                3 => "المعرف غير موجود بالنظام راجع المدخلات",
                4 => "لا يمكن حذف أو تعديل هذا العنصر لأنه مرتبط بعناصر أخرى",
                5 => "عملية غير مصرح بها. يرجى التحقق من الصلاحيات",
                _ => "حدث خطأ في قاعدة البيانات. يرجى المحاولة مرة أخرى"
            };

            return $"{exceptionMessage}\n(رمز الخطأ: {ex.Number})";
        }

        private string _GetSqlExceptionMessage(SqlException ex)
        {
            if (ex.Number >= 50000)
                return _GetCustomSqlExceptionMessage(ex);

            switch (ex.Number)
            {
                case 2601: // Duplicated key row error (SQL Server)
                case 2627: // Duplicated key constraint violation
                    return $"البيانات المدخلة موجودة مسبقاً. يرجى إدخال بيانات جديدة.\n(رمز الخطأ: {ex.Number})";

                case 547: // Foreign key violation
                    return $"لا يمكن حذف أو تعديل هذا العنصر لأنه مرتبط بعناصر أخرى.\n(رمز الخطأ: {ex.Number})";

                case 4060: // Invalid Database
                    return $"قاعدة البيانات غير متوفرة حالياً.\n(رمز الخطأ: {ex.Number})";

                case 18456: // Login failed
                    return $"فشل الاتصال بقاعدة البيانات. يرجى التحقق من بيانات الدخول.\n(رمز الخطأ: {ex.Number})";

                case 208: // Invalid object name
                    return $"حدث خطأ في قاعدة البيانات. يرجى المحاولة مرة أخرى.\n(رمز الخطأ: {ex.Number})";

                case 207: // Invalid column name
                    return $"حدث خطأ في قاعدة البيانات. يرجى المحاولة مرة أخرى.\n(رمز الخطأ: {ex.Number})";

                case 8152: // String or binary data would be truncated
                    return $"أحد الحقول يحتوي على نص طويل جداً. يرجى تقصير النص المدخل.\n(رمز الخطأ: {ex.Number})";

                case 53: // Cannot connect to server
                    return $"لا يمكن الاتصال بقاعدة البيانات. يرجى التحقق من الاتصال بالشبكة.\n(رمز الخطأ: {ex.Number})";

                case -2: // Timeout expired
                    return $"انتهت مهلة عملية قاعدة البيانات. يرجى المحاولة مرة أخرى.\n(رمز الخطأ: {ex.Number})";

                case 1205: // Deadlock
                    return $"حدث تعارض في قاعدة البيانات. يرجى إعادة المحاولة.\n(رمز الخطأ: {ex.Number})";

                default:
                    return $"حدث خطأ في قاعدة البيانات. يرجى المحاولة مرة أخرى.\n(رمز الخطأ: {ex.Number})";
            }
        }

        public string GetExceptionMessage(Exception ex)
        {
            switch (ex)
            {
                case SqlException sqlEx:
                    return _GetSqlExceptionMessage(sqlEx);

                case FormatException:
                    return "التنسيق المدخل غير صحيح. يرجى التحقق من القيمة المدخلة";

                case FileNotFoundException:
                    return "الملف المطلوب غير موجود. يرجى التأكد من وجود الملف";

                case IOException:
                    return "حدث خطأ في عملية الملف. يرجى التأكد من أن الملف غير مستخدم أو مقفل";

                case ArgumentNullException:
                    return "بعض المعلومات المطلوبة غير موجودة. يرجى تعبئة جميع الحقول";

                case InvalidOperationException:
                    return "العملية المطلوبة غير صالحة في الحالة الحالية";

                case ArgumentException:
                    return "تم تقديم قيمة غير صالحة. يرجى التحقق من المدخلات";

                default:
                    return "حدث خطأ غير متوقع. يرجى المحاولة مرة أخرى";
            }
        }
    }
}