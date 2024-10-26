using System.Xml.Serialization;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Service.Implements;

public class XmlSteam<T> : IXmlStream<T> where T : class
{
    public bool Export(List<T> items, string filePath)
    {
        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                serializer.Serialize(textWriter, items);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<T> Import(string filePath)
    {
        using var reader = new StreamReader(filePath);
        var serializer = new XmlSerializer(typeof(List<T>));
        var data = (List<T>)serializer.Deserialize(reader);
        return data ?? new List<T>();
    }
}