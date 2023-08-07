using System.IO.Compression;

public class Downloader
{
    public async Task DownloadAndExtractZip(string downloadUrl, string zipFile, string extractFolder)
    {
        using HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(downloadUrl);
        using var stream = await response.Content.ReadAsStreamAsync();
        using (Stream zipStream = File.OpenWrite(zipFile))
        {
            stream.CopyTo(zipStream);
            // Ensure all data is written to the file before we close the stream.
            await zipStream.FlushAsync();
        }

        ZipFile.ExtractToDirectory(zipFile, extractFolder);
        File.Delete(zipFile);
    }
}
