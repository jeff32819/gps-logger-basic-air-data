using System.Xml;
using Newtonsoft.Json;

namespace GpsLoggerDll;

/// <summary>
///     Provides methods for parsing XML data into a <see cref="Model" /> object.
/// </summary>
/// <remarks>
///     This class includes methods for parsing XML data from a file, a string, or an
///     <see
///         cref="XmlDocument" />
///     . The parsed data is deserialized into a <see cref="Model" /> object.
/// </remarks>
public static class Parse
{
    /// <summary>
    ///     Parse from file on disk
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static Model? FromDisk(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception($"File not found {filePath}");
        }
        var doc = new XmlDocument();
        doc.Load(filePath);
        return FromXmlDocument(doc);
    }

    /// <summary>
    /// Parse from a string
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static Model? FromString(string txt)
    {
        // Replace with your actual file path

        var doc = new XmlDocument();
        doc.LoadXml(txt);
        return FromXmlDocument(doc);
    }

    /// <summary>
    ///     Convert the XML document to a JSON Model object
    /// </summary>
    /// <param name="doc"></param>
    /// <returns></returns>
    public static Model? FromXmlDocument(XmlDocument doc)
    {
        // Convert XML to JSON
        var tmp = JsonConvert.SerializeXmlNode(doc.DocumentElement);
        // Deserialize JSON to C# object
        return JsonConvert.DeserializeObject<Model>(tmp);
    }
}