using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DateOnlyJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (DateTime.TryParse(stringValue, out var dateTime))
            {
                return dateTime;
            }
            else if (DateTime.TryParseExact(stringValue, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var dateOnly))
            {
                return dateOnly;
            }
        }
        throw new JsonException("Invalid date format");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
