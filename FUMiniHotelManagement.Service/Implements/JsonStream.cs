using System.Text.Json;
using FUMiniHotelManagement.Service.Interfaces;

namespace FUMiniHotelManagement.Service.Implements;

public class JsonStream<T> : IJsonStream<T> where T : class
{
    public List<T> Import(string filePath)
    {
        try
        {
            // Read JSON file asynchronously
            string jsonData =  File.ReadAllText(filePath);

            // Deserialize JSON data to List<T>
            List<T> list = JsonSerializer.Deserialize<IEnumerable<T>>(jsonData).ToList();

            return list;
        }
        catch (Exception ex)
        {
            return new List<T>(); 
        }
    }

    public bool Export(List<T> data, string filePath)
    {
        try
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
            string json = JsonSerializer.Serialize(data, option);
            File.WriteAllText(filePath, json);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}