using System;
namespace DownloadZIP
{
    public class Zavezanec
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }

        public Zavezanec
        (int id, string status, string number1, string number2, string date, string amount, string companyName, string address, string rating)
        {
            Id = id;
            Status = TransformString(status);
            Number1 = TransformString(number1);
            Number2 = TransformString(number2);
            var dateInString = TransformString(date);
            Amount = ParseDecimalThenTransformString(amount);
            CompanyName = TransformString(companyName);
            Address = TransformString(address);
            Rating = ParseIntThenTransformString(rating);
            if (DateTime.TryParse(dateInString, out DateTime nDate))
            {
                Date = nDate;
            }

        }

        public string TransformString(string str)
        {
            var trim = str.TrimStart().TrimEnd();
            var split = trim.Split(" ");
            var newString = String.Join(" ", split);
            return newString;
        }

        public int ParseIntThenTransformString(string str)
        {
            var transform = TransformString(str);
            return int.Parse(transform);
        }

        public decimal ParseDecimalThenTransformString(string str)
        {
            var transform = TransformString(str);
            return decimal.Parse(transform);        }

}

}

