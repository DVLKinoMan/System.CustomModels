using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace System.CustomModels.Filters
{
    public class FilterTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
            sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var str = value as string;
            if (str == null)
                return null;

            var jo = JObject.Parse(str);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return (jo["filterType"] ?? throw new InvalidOperationException($"Type has no filterType"))
                .Value<int>() switch
                {
                    (int)FilterType.ExactValue => DeserilizeToTargetType(str, typeof(ExactValueFilter<,>), options),
                    (int)FilterType.PatternString => DeserilizeToTargetType(str, typeof(PatternString<>), options),
                    (int)FilterType.Range => DeserilizeToTargetType(str, typeof(Range<,>), options),
                    (int)FilterType.DatetimePattern => DeserilizeToTargetType(str, typeof(DatetimePattern<>), options),
                    _ => throw new NotImplementedException("filterType is not implemented")
                };
        }

        private static object? DeserilizeToTargetType(string jsonString, Type targetType, JsonSerializerOptions? options)
        {
            var deserializeMethod = typeof(JsonSerializer)
            .GetMethod(nameof(JsonSerializer.Deserialize), [typeof(string), typeof(JsonSerializerOptions)]);

            var deserializedObject = deserializeMethod!.Invoke(null, [jsonString, options]);

            return Convert.ChangeType(deserializedObject, targetType);
        }
    }
}
