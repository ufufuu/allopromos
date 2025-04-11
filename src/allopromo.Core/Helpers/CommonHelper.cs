using System;
using System.Collections.Generic;
using System.Text;

namespace allopromo.Core.Helpers
{
    public static class CommonHelper
    {
        public static string EnsureSubscriberEmailOrThrow(string email)
        {
            string email1 = CommonHelper.EnsureMaximumLength(CommonHelper.EnsureNotNull(email).Trim(), (int)byte.MaxValue);
            return CommonHelper.IsValidEmail(email1) ? email1 : throw new Exception("Email is not valid.");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            email = email.Trim();
            return Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
        }

        public static string GenerateRandomDigitCode(int length)
        {
            string empty = string.Empty;
            RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] numArray = new byte[length];
            byte[] data = numArray;
            cryptoServiceProvider.GetBytes(data);
            for (int index = 0; index < length; ++index)
                empty += numArray[index].ToString();
            return empty.Substring(0, length);
        }

        public static int GenerateRandomInteger(int min = 0, int max = 2147483647)
        {
            byte[] data = new byte[10];
            RandomNumberGenerator.Create().GetBytes(data);
            return new Random(BitConverter.ToInt32(data, 0)).Next(min, max);
        }

        public static string EnsureMaximumLength(string str, int maxLength, string postfix = null)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
                return str;
            int length = postfix == null ? 0 : postfix.Length;
            string str1 = str.Substring(0, maxLength - length);
            if (!string.IsNullOrEmpty(postfix))
                str1 += postfix;
            return str1;
        }

        public static string EnsureNotNull(string str) => str ?? string.Empty;

        public static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (a1 == a2)
                return true;
            if (a1 == null || a2 == null || a1.Length != a2.Length)
                return false;
            EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
            for (int index = 0; index < a1.Length; ++index)
            {
                if (!equalityComparer.Equals(a1[index], a2[index]))
                    return false;
            }
            return true;
        }

        public static object To(object value, Type destinationType)
        {
            return CommonHelper.To(value, destinationType, CultureInfo.InvariantCulture);
        }

        public static object To(object value, Type destinationType, CultureInfo culture)
        {
            if (value != null)
            {
                Type type = value.GetType();
                TypeConverter converter1 = TypeDescriptor.GetConverter(destinationType);
                if (converter1 != null && converter1.CanConvertFrom(value.GetType()))
                    return converter1.ConvertFrom((ITypeDescriptorContext)null, culture, value);
                TypeConverter converter2 = TypeDescriptor.GetConverter(type);
                if (converter2 != null && converter2.CanConvertTo(destinationType))
                    return converter2.ConvertTo((ITypeDescriptorContext)null, culture, value, destinationType);
                if (destinationType.IsEnum && value is int num)
                    return Enum.ToObject(destinationType, num);
                if (!destinationType.IsInstanceOfType(value))
                    return Convert.ChangeType(value, destinationType, (IFormatProvider)culture);
            }
            return value;
        }

        public static T To<T>(object value) => (T)CommonHelper.To(value, typeof(T));

        public static string ConvertEnum(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            string str1 = string.Empty;
            foreach (char ch in str)
                str1 = !(ch.ToString() != ch.ToString().ToLower()) ? str1 + ch.ToString() : str1 + " " + ch.ToString();
            return str1.TrimStart();
        }

        public static int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            int differenceInYears = endDate.Year - startDate.Year;
            if (startDate > endDate.AddYears(-differenceInYears))
                --differenceInYears;
            return differenceInYears;
        }

        public static string MapPath(string path)
        {
            path = path.Replace("~/", "").TrimStart('/');
            return Path.Combine(CommonHelper.BaseDirectory, path);
        }

        public static string BaseDirectory { get; set; }

        public static string WebMapPath(string path)
        {
            path = path.Replace("~/", "").TrimStart('/');
            return Path.Combine(CommonHelper.WebRootPath, path);
        }

        public static string WebRootPath { get; set; }

        public static int CacheTimeMinutes { get; set; }

        public static int CookieAuthExpires { get; set; }

        public static bool AllowToJsonResponse { get; set; }
    }
}
