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
    }
}
