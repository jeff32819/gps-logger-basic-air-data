using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GpsLoggerDll;

public class SingleOrArrayConverter<T> : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(List<T>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        if (token.Type == JTokenType.Array)
        {
            return token.ToObject<List<T>>(serializer);
        }

        if (token.Type == JTokenType.Null)
        {
            return null;
        }

        // Single object, wrap in a list
        return new List<T> { token.ToObject<T>(serializer) };
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var list = value as List<T>;
        if (list != null && list.Count == 1)
        {
            serializer.Serialize(writer, list[0]);
        }
        else
        {
            serializer.Serialize(writer, list);
        }
    }
}