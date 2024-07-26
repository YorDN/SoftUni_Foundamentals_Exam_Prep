using System.Text;

namespace Problem_One_ActivationKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inp = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(inp);

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] arr = input.Split(">>>");
                string command = arr[0];
                switch (command)
                {
                    case "Contains":
                        string sub = arr[1];
                        if (sb.ToString().Contains(sub))
                        {
                            Console.WriteLine($"{sb} contains {sub}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string typeFlip = arr[1];
                        int startIndex = int.Parse(arr[2]);
                        int endIndex = int.Parse(arr[3]);

                        if (typeFlip == "Upper")
                        {
                            string subString = String.Empty;
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                subString += sb[i];
                            }
                            string oldSubString = subString;
                            subString = subString.ToUpper();
                            sb.Replace(oldSubString, subString);
                            Console.WriteLine(sb);
                        }
                        else
                        {
                            string subString = String.Empty;
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                subString += sb[i];
                            }
                            string oldSubString = subString;
                            subString =  subString.ToLower();
                            sb.Replace(oldSubString, subString);
                            Console.WriteLine(sb);
                        }
                        break;
                    case "Slice":
                        int startIndexSlice = int.Parse(arr[1]);
                        int endIndexSlice = int.Parse(arr[2]);
                        sb.Remove(startIndexSlice, endIndexSlice - startIndexSlice);
                        Console.WriteLine(sb);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {sb}");
        }
    }
}
