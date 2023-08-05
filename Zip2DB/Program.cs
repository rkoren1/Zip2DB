
using System.IO.Compression;
using System.Net;
using DownloadZIP;
using DownloadZIP.Data;


string zipFilePath = "zavezanci.zip";


//downloads the zip file and extracts it into zip folder
using (HttpClient client = new HttpClient())
{
    using (HttpResponseMessage response = await client.GetAsync("http://datoteke.durs.gov.si/DURS_zavezanci_PO.zip"))
    {
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            using (Stream zip = File.OpenWrite(zipFilePath))
            {
                stream.CopyTo(zip);
            }
        }
    }
}
ZipFile.ExtractToDirectory(zipFilePath, @"../../../zip");
File.Delete("./" + zipFilePath);
//reads txt
var fileReading = File.ReadAllText(@"../../../zip/DURS_zavezanci_PO.txt");

//splits txt file by lines
var lines = fileReading.Split("\n");

List<Zavezanec> zavezanci = new List<Zavezanec>();
Zavezanec lineToObject;

//saves data from txt file into zavezanci list of objects
var id = 1;
foreach (var line in lines)
{
    if (line != "")
    {
        lineToObject = new Zavezanec(id: id, status: line.Substring(0, 4), number1: line.Substring(4, 9), number2: line.Substring(13, 11), date: line.Substring(24, 11), amount: line.Substring(35, 7), companyName: line.Substring(42, 101), address: line.Substring(143, 114), rating: line.Substring(257));
        zavezanci.Add(lineToObject);
        id++;
    }
}

File.Delete(@"../../../zip/DURS_zavezanci_PO.txt");


//writes data to sqlite database (zavezanci.db) -> make sure your database is empty else you will get error for trying to insert same id
using(var database = new ZavezanciContext())
{
    
    zavezanci.ForEach(element =>
    {
        Console.WriteLine("Id: " + element.Id);
        database.Add(new ZavezanecEntity()
        {
            Id = element.Id,
            Status = element.Status,
            Number1 = element.Number1,
            Number2 = element.Number2,
            Date = element.Date,
            Amount = element.Amount,
            CompanyName = element.CompanyName,
            Address = element.Address,
            Rating = element.Rating
        });
    });
    try
    {
        database.SaveChanges();
        Console.WriteLine("Program Completed Successfully!");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }
    
}
