namespace DownloadZIP.Data
{

    internal class ZavezanecEntity
    {
        public int Id { get; set; }
        public char? Ureditev { get; set; }
        public char? ZavezanostZaDDV { get; set; }
        public string Davcna { get; set; }
        public string? Maticna { get; set; }
        public DateTime? DatumRegistracije { get; set; }
        public string SifraDejavnosti { get; set; }
        public string ImeZavezanca { get; set; }
        public string Naslov { get; set; }
        public string FinancniUrad { get; set; }

        public ZavezanecEntity()
        { }

        public ZavezanecEntity
        (int id, char ureditev, char zavezanostZaDDV, string davcna, string maticna, string datumRegistracije,
            string sifraDejavnosti, string imeZavezanca, string naslov, string financniUrad)
        {
            Id = id;
            Ureditev = CheckForNull(ureditev);
            ZavezanostZaDDV = CheckForNull(zavezanostZaDDV);
            Davcna = TrimString(davcna);
            Maticna = TrimStringAndCheckForNull(maticna);
            var dateInString = TrimString(datumRegistracije);
            SifraDejavnosti = TrimString(sifraDejavnosti);
            ImeZavezanca = TrimString(imeZavezanca);
            Naslov = TrimString(naslov);
            FinancniUrad = TrimString(financniUrad);
            if (DateTime.TryParse(dateInString, out DateTime nDate))
            {
                DatumRegistracije = nDate;
            }
            else
                DatumRegistracije = null;

        }

        private string TrimString(string str)
        {
            return str.TrimEnd();
        }
        private string? TrimStringAndCheckForNull(string str)
        {
            var tmp = str.TrimEnd();
            if (tmp == "")
                return null;
            return tmp;
        }
        private char? CheckForNull(char chr)
        {
            if (chr == ' ')
                return null;
            return chr;
        }
    }
}
