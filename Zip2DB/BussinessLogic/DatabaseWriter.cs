
using DownloadZIP.Data;
using System.Text.Encodings.Web;
using System.Text.Json;

public class DatabaseWriter
{
    public void WriteToDatabase(List<ZavezanecEntity> zavezanci)
    {
        using var database = new ZavezanciContext();
        Console.WriteLine("Zapisujem v bazo.");

        foreach (var element in zavezanci)
        {
            database.Add(element);
        }

        try
        {
            database.SaveChanges();
            Console.WriteLine("Zapisi so uspešno dodani v bazo!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        foreach (var element in database.Zavezanci)
        {
            Console.WriteLine(JsonSerializer.Serialize(element, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }));
        }
    }
}
