
using DownloadZIP.Data;

public class DataReader
{
    public List<ZavezanecEntity> ReadAndProcessData(string dataFile)
    {
        var fileReading = File.ReadAllText(dataFile);
        var rows = fileReading.Split("\n").Where(row => !string.IsNullOrEmpty(row)).ToList();

        List<ZavezanecEntity> zavezanci = new();
        int id = 1;

        foreach (var row in rows)
        {
            var rowToZavezanec = new ZavezanecEntity(
                id: id,
                ureditev: row[0],
                zavezanostZaDDV: row[2],
                davcna: row.Substring(4, 8),
                maticna: row.Substring(13, 10),
                datumRegistracije: row.Substring(24, 10),
                sifraDejavnosti: row.Substring(35, 6),
                imeZavezanca: row.Substring(42, 100),
                naslov: row.Substring(143, 113),
                financniUrad: row.Substring(257, 2)
            );

            zavezanci.Add(rowToZavezanec);
            id++;
        }

        File.Delete(dataFile);
        return zavezanci;
    }
}
