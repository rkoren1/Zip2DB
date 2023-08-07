
string ZipFilePath = "zavezanci.zip";
string DownloadUrl = "http://datoteke.durs.gov.si/DURS_zavezanci_PO.zip";
string ExtractFolder = @"../zip";
string DataFile = @"../zip/DURS_zavezanci_PO.txt";

var downloader = new Downloader();
var dataReader = new DataReader();
var databaseWriter = new DatabaseWriter();

Console.WriteLine("Prenašam zip datoteko.");
await downloader.DownloadAndExtractZip(DownloadUrl, ZipFilePath, ExtractFolder);

var zavezanci = dataReader.ReadAndProcessData(DataFile);
databaseWriter.WriteToDatabase(zavezanci);
