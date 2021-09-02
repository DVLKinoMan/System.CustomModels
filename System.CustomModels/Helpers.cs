using System.Collections.Generic;
using System.CustomModels.Filters;

namespace System.CustomModels
{
    public static class Helpers
    {
        public static Dictionary<ZodiacSign, IRange<(int month, int day)>> ZodiacDateRange = new()
        {
            [ZodiacSign.Aquarius] = new Range<(int month, int day)>((1, 20), (2, 18)),
            [ZodiacSign.Pisces] = new Range<(int month, int day)>((2, 19), (3, 20)),
            [ZodiacSign.Aries] = new Range<(int month, int day)>((3, 21), (4, 19)),
            [ZodiacSign.Taurus] = new Range<(int month, int day)>((4, 20), (5, 20)),
            [ZodiacSign.Gemini] = new Range<(int month, int day)>((5, 21), (6, 20)),
            [ZodiacSign.Cancer] = new Range<(int month, int day)>((6, 21), (7, 22)),
            [ZodiacSign.Leo] = new Range<(int month, int day)>((7, 23), (8, 22)),
            [ZodiacSign.Virgo] = new Range<(int month, int day)>((8, 23), (9, 22)),
            [ZodiacSign.Libra] = new Range<(int month, int day)>((9, 23), (10, 22)),
            [ZodiacSign.Scorpio] = new Range<(int month, int day)>((10, 23), (11, 21)),
            [ZodiacSign.Sagittarius] = new Range<(int month, int day)>((11, 22), (12, 21)),
            [ZodiacSign.Capricorn] = new Range<(int month, int day)>((12, 22), (1, 19)),
        };

        public static ZodiacSign GetZodiacSign(this DateTime birthDay)
        {
            int month = birthDay.Month;
            int day = birthDay.Day;
            foreach (var (sign, range) in ZodiacDateRange)
                if ((range.Start.month == month && range.Start.day <= day) ||
                    (range.End.month == month && range.End.day >= day))
                    return sign;

            throw new ApplicationException("ZodiacDateRange does not contain this datetime");
        }

        public static Gender? GetGender(this byte sex) => sex switch
        {
            0 => Gender.Unknown,
            1 => Gender.Male,
            2 => Gender.Female,
            _ => null
        };

        public static int GetAge(this DateTime birthDate, DateTime? deathDate = null)
        {
            var end = deathDate ?? DateTime.Now;
            int age = end.Year - birthDate.Year;
            if (birthDate > end.AddYears(-age))
                age--;

            return age;
        }

        public static byte? GetByte(this Gender gender) => gender switch
        {
            Gender.Unknown => 0,
            Gender.Male => 1,
            Gender.Female => 2,
            _ => null
        };

        /// <summary>
        /// Returns string After prevoiusString from text
        /// </summary>
        /// <param name="previousString"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetAfterString(this string text, string previousString) =>
            text.IndexOf(previousString) switch
            {
                var index and >= 0 => text.Substring(index + previousString.Length),
                _ => string.Empty
            };

        /// <summary>
        /// Returns string Before nextString from text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="nextString"></param>
        /// <returns></returns>
        public static string GetBeforeString(this string text, string nextString) =>
            text.IndexOf(nextString) switch
            {
                var index and >= 0 => text.Substring(0, index),
                _ => string.Empty
            };

        /// <summary>
        /// Returns string Before nextString and After previousString
        /// </summary>
        /// <param name="text"></param>
        /// <param name="previousString"></param>
        /// <param name="nextString"></param>
        /// <returns></returns>
        public static string GetBetweenString(this string text, string previousString, string nextString)
        {
            int startIndex = text.IndexOf(previousString);
            if (startIndex < 0 || startIndex == text.Length - 1)
                return string.Empty;

            startIndex += previousString.Length;

            int endIndex = text.IndexOf(nextString, startIndex);
            if (endIndex < 0)
                return string.Empty;

            var result = text.Substring(startIndex, endIndex - startIndex);
            return result;
        }
    }
}
