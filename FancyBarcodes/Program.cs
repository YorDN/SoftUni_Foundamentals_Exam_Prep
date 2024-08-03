using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\@\#{1,}[A-Z][A-Za-z0-9]{4,}[A-Z]\@\#{1,}";
            string numPattern = @"\d+";
            for (int i = 0; i < n; i++) 
            {
                bool isMatch = false;
                string group = string.Empty;
                string barcode  = Console.ReadLine();
                foreach (Match m in Regex.Matches(barcode, pattern))
                {
                    isMatch = true;
                    foreach (Match match in Regex.Matches(barcode, numPattern))
                    {
                        group += match.Value;
                    }
                    if (group == string.Empty)
                    {
                        group = "00";
                    }
                }
                if (isMatch == true)
                {
                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }

        }
    }
}
