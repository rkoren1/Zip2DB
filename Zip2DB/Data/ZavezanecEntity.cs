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

        public ZavezanecEntity()
        { }

        public ZavezanecEntity
        (int id, char ureditev, char zavezanostZaDDV, string davcna, string maticna, string datumRegistracije,
            string sifraDejavnosti, string imeZavezanca, string naslov, string financniUrad)
        {
            Id = id;
            Ureditev = ureditev;
            ZavezanostZaDDV = zavezanostZaDDV;
            Davcna = TransformString(davcna);
            Maticna = TransformString(maticna);
            var dateInString = TransformString(datumRegistracije);
            SifraDejavnosti = TransformString(sifraDejavnosti);
            ImeZavezanca = TransformString(imeZavezanca);
            Naslov = TransformString(naslov);
            FinancniUrad = TransformString(financniUrad);
            if (DateTime.TryParse(dateInString, out DateTime nDate))
            {
                DatumRegistracije = nDate;
            }

        }

        public string TransformString(string str)
        {
            var trim = str.TrimStart().TrimEnd();
            var split = trim.Split(" ");
            var newString = String.Join(" ", split);
            return newString;
        }
    }
}
