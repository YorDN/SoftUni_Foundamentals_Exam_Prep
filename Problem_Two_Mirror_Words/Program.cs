using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_Two_Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mirrorList = new List<string>();
            string pattern = @"([\@\#])(?<RightWord>[A-Za-z]{3,})\1{2}(?<ReverseWord>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();
            int mirrorCount = 0;
            int validPairsCount = 0;
            foreach(Match match in Regex.Matches(input, pattern))
            {
                validPairsCount++;
                string rightWord = match.Groups["RightWord"].Value;
                string oldReverseWord = match.Groups["ReverseWord"].Value;
                char[] arr = oldReverseWord.ToCharArray();
                Array.Reverse(arr);
                string newReverseWord = new string (arr);
                if (rightWord == newReverseWord)
                {
                    mirrorCount++;
                    mirrorList.Add($"{rightWord} <=> {oldReverseWord}");
                }
            }
            if (validPairsCount == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{validPairsCount} word pairs found!");
            }
            if (mirrorCount == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            
            else
            {
                Console.WriteLine($"The mirror words are: ");
                Console.WriteLine(String.Join(", ", mirrorList));
            }
        }
    }
}
