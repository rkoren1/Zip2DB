using DownloadZIP.Data;
using System.IO.Compression;
using System.Text.Encodings.Web;
using System.Text.Json;

string zipFile = "zavezanci.zip";

Console.WriteLine("Prenašam zip datoteko.");
//downloads the zip file and extracts it into zip folder
using (HttpClient client = new HttpClient())
{
    using (HttpResponseMessage response = await client.GetAsync("http://datoteke.durs.gov.si/DURS_zavezanci_PO.zip"))
    {
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            using (Stream zip = File.OpenWrite(zipFile))
            {
                stream.CopyTo(zip);
            }
        }
    }
}
ZipFile.ExtractToDirectory(zipFile, @"../zip");
File.Delete("./" + zipFile);
//reads txt
var fileReading = File.ReadAllText(@"../zip/DURS_zavezanci_PO.txt");

//splits txt file by rows
var rows = fileReading.Split("\n");

List<ZavezanecEntity> zavezanci = new();
ZavezanecEntity rowToZavezanec;

//saves data from txt file into zavezanci list of objects
var id = 1;
foreach (var row in rows)
{
    if (row != "")
    {
        rowToZavezanec = new ZavezanecEntity(id: id, ureditev: row.Substring(0)[0], zavezanostZaDDV: row.Substring(2)[0], davcna: row.Substring(4, 8), maticna: row.Substring(13, 10),
            datumRegistracije: row.Substring(24, 10), sifraDejavnosti: row.Substring(35, 6), imeZavezanca: row.Substring(42, 100),
            naslov: row.Substring(143, 113), financniUrad: row.Substring(257, 2));
        zavezanci.Add(rowToZavezanec);
        id++;
    }
}

File.Delete(@"../zip/DURS_zavezanci_PO.txt");


//writes data to sqlite database (davcni_zavezanci.db) -> make sure your database is empty else you will get error for trying to insert same id
using (var database = new ZavezanciContext())
{
    Console.WriteLine("Zapisujem v bazo.");
    zavezanci.ForEach(element =>
    {
        database.Add(element);
    });

    try
    {
        database.SaveChanges();
        Console.WriteLine("Zapisi so uspešno dodani v bazo!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    database.Zavezanci.ToList().ForEach(element =>
    {
        Console.WriteLine(JsonSerializer.Serialize(element, new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        }));
    });

}
