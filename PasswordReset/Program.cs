using System.Text;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(inputString);
            string input;
            while ( (input = Console.ReadLine()) != "Done")
            {
                string[] arr = input.Split();
                string command = arr[0];
                switch (command)
                {
                    case "TakeOdd":
                        string text = "";
                        for (int i = 0; i < sb.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                text += sb[i];

                            }
                        }
                        sb.Clear();
                        sb.Append(text);
                        Console.WriteLine(sb);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(arr[1]);
                        int lenght = int.Parse(arr[2]);
                        sb.Remove(startIndex, lenght);
                        Console.WriteLine(sb);
                        break;
                    case "Substitute":
                        string subString = arr[1];
                        string substituted = arr[2];
                        if (sb.ToString().Contains(subString))
                        {
                            sb.Replace(subString, substituted);
                            Console.WriteLine(sb);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your password is: {sb}");
        }
    }
}
