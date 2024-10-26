namespace FUMiniHotelManagement.Service.Interfaces;

public interface IXmlStream<T> where T : class
{
    List<T> Import(string filePath);
    bool  Export(List<T> data, string filePath);
}