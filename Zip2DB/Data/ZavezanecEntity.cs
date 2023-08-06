namespace DownloadZIP.Data
{

    internal class ZavezanecEntity
    {
        public int Id { get; set; }
        public char Ureditev { get; set; }
        public char ZavezanostZaDDV { get; set; }
        public string Davcna { get; set; }
        public string Maticna { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string SifraDejavnosti { get; set; }
        public string ImeZavezanca { get; set; }
        public string Naslov { get; set; }
        public string FinancniUrad { get; set; }
    }
}
