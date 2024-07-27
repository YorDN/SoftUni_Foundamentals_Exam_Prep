using System.Text.RegularExpressions;

namespace Problem_Two_Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> coolEmojiList = new List<string>();
            string input = Console.ReadLine();
            string patternEmoji = @"((?:\*{2}|\:{2}))(?<emoji>[A-Z][a-z]{2,})(\1)";
            string patternNum = @"\d";
            long coolThreshold = 1;
            
            foreach (Match match in Regex.Matches(input, patternNum))
            {
                coolThreshold *= long.Parse(match.Value);
            }
            int emojiCount = 0;
            foreach (Match match in Regex.Matches(input, patternEmoji))
            {
                emojiCount++;
                long emojiCoolness = 0;
                foreach (char c in match.Groups["emoji"].Value)
                {
                    emojiCoolness += (int)c;
                }
                if (emojiCoolness >= coolThreshold)
                {
                    coolEmojiList.Add(match.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojiList)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
