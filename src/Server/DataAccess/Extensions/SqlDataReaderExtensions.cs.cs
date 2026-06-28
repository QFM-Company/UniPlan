using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.ExternalServices;
using Microsoft.Data.SqlClient;

namespace DataAccess.Extensions
{
    public static class SqlDataReaderExtensions
    {
        // This method retrieves a valid value from the SqlDataReader for the specified column name or null.
        private static object? GetValidValue(SqlDataReader reader, string columnName)
        {
            if (reader == null) return null;

            try
            {
                int ordinal = reader.GetOrdinal(columnName);

                if (reader.IsDBNull(ordinal))
                {
                    return null;
                }

                return reader.GetValue(ordinal);
            }
            catch (Exception)
            {
                return null;
            }
        }



        /// <summary>
        /// لقراءة رقرم انتجر من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static int ReadInt(this SqlDataReader reader, string columnName, int defaultValue = -1)
        {
            var value = GetValidValue(reader, columnName);

            if (value == null) return defaultValue;

            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// لقراءة سترينغ من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static string ReadString(this SqlDataReader reader, string columnName, string defaultValue = "")
        {
            var value = GetValidValue(reader, columnName);

            if (value == null) return defaultValue;

            return value.ToString()?.Trim() ?? defaultValue;
        }



        /// <summary>
        /// لقراءة وقت من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static TimeSpan ReadTimeSpan(this SqlDataReader reader, string columnName, TimeSpan defaultValue = default)
        {
            var value = GetValidValue(reader, columnName);
            if (value == null) return defaultValue;

            try
            {
                // TimeSpan مباشر
                if (value is TimeSpan timeSpan)
                    return timeSpan;

                // TimeOnly (أحدث)
                if (value is TimeOnly timeOnly)
                    return timeOnly.ToTimeSpan();

                // DateTime -> نأخذ الوقت فقط
                if (value is DateTime dateTime)
                    return dateTime.TimeOfDay;

                // محاولة تحويل النص
                var strValue = value.ToString();

                // محاولة TimeSpan.Parse
                if (TimeSpan.TryParse(strValue, out TimeSpan parsed))
                    return parsed;

                // محاولة DateTime.Parse ثم أخذ الوقت (للتعامل مع "2024-01-15 08:30:00")
                if (DateTime.TryParse(strValue, out DateTime parsedDateTime))
                    return parsedDateTime.TimeOfDay;

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }


        /// <summary>
        /// لقراءة تاريخ و وقت من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static DateTime ReadDateTime(this SqlDataReader reader, string columnName, DateTime defaultValue = default)
        {
            var value = GetValidValue(reader, columnName);

            if (value == null) return defaultValue;

            try
            {
                if (value is DateTime dateTimeValue)
                {
                    return dateTimeValue;
                }

                if (DateTime.TryParse(value.ToString(), out DateTime parsedValue))
                {
                    return parsedValue;
                }

                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }



        /// <summary>
        /// لقراءة بوليان من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static bool ReadBool(this SqlDataReader reader, string columnName, bool defaultValue = false)
        {
            var value = GetValidValue(reader, columnName);
            if (value == null) return defaultValue;
            try
            {
                if (value is bool boolValue)
                {
                    return boolValue;
                }
                if (bool.TryParse(value.ToString(), out bool parsedValue))
                {
                    return parsedValue;
                }
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }



        /// <summary>
        /// لقراءة رقرم ديسيمل من الداتابيز
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="columnName">اسم الكولم</param>
        /// <param name="defaultValue">بتقدر تضيف شو ترجعلك اذا ما قدرت تقرأ</param>
        /// <returns></returns>
        public static decimal ReadDecimal(this SqlDataReader reader, string columnName, decimal defaultValue = 0m)
        {
            var value = GetValidValue(reader, columnName);
            if (value == null) return defaultValue;
            try
            {
                if (value is decimal decimalValue)
                {
                    return decimalValue;
                }
                if (decimal.TryParse(value.ToString(), out decimal parsedValue))
                {
                    return parsedValue;
                }
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        // للـ GUID
        public static Guid ReadGuid(this SqlDataReader reader, string columnName, Guid defaultValue = default)
        {
            var value = GetValidValue(reader, columnName);
            if (value == null) return defaultValue;

            return value is Guid guid ? guid :
                   Guid.TryParse(value.ToString(), out var parsed) ? parsed : defaultValue;
        }

        // للـ double
        public static double ReadDouble(this SqlDataReader reader, string columnName, double defaultValue = 0)
        {
            var value = GetValidValue(reader, columnName);
            if (value == null) return defaultValue;

            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        // للتحقق من وجود عمود
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

    }
}
