using System.Text;

namespace Problem_One_World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputDest = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(inputDest);
            string[]input = Console.ReadLine().Split(' ', ':');
            while (input[0] != "Travel")
            {
                switch (input[0])
                {
                    case "Add":
                        int index = int.Parse(input[2]);
                        string value = input[3];
                        if (index >= 0 && index <= stringBuilder.Length - 1)
                        {
                            stringBuilder.Insert(index, value);
                        }
                        
                        break;
                    case "Remove":
                        int startIndex = int.Parse(input[2]);
                        int endIndex = int.Parse(input[3]);
                        if ((startIndex >= 0 && startIndex <= stringBuilder.Length - 1) && (endIndex >= 0 && endIndex <= stringBuilder.Length - 1))
                        {
                            int lenght = endIndex - startIndex + 1;
                            stringBuilder.Remove(startIndex, lenght);
                        }
                        break;
                    case "Switch":
                        string oldValue = input[1];
                        string newValue = input[2];
                        if (stringBuilder.ToString().IndexOf(oldValue) != -1)
                        {
                            stringBuilder.Replace(oldValue, newValue);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(stringBuilder);
                input = Console.ReadLine().Split(' ', ':');
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stringBuilder}");
        }
    }
}
