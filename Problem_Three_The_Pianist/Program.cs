namespace Problem_Three_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string, Pieces> piecesDictionary = new Dictionary<string, Pieces> ();   
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++) 
            { 
                string inp = Console.ReadLine();
                string[] arr = inp.Split('|');
                Pieces piece = new Pieces(arr[0], arr[1], arr[2]);
                piecesDictionary.Add(arr[0], piece);
                
            }
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] arr = input.Split('|');
                string command = arr[0];
                switch (arr[0])
                {
                    case "Add":
                        Pieces piece = new Pieces(arr[1], arr[2], arr[3]);
                        if (piecesDictionary.ContainsKey(arr[1]))
                        {
                            Console.WriteLine($"{arr[1]} is already in the collection!");
                        }
                        else
                        {
                            piecesDictionary.Add(arr[1], piece);
                            Console.WriteLine($"{arr[1]} by {arr[2]} in {arr[3]} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (piecesDictionary.ContainsKey(arr[1]))
                        {
                            piecesDictionary.Remove(arr[1]);
                            Console.WriteLine($"Successfully removed {arr[1]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {arr[1]} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        if (piecesDictionary.ContainsKey(arr[1]))
                        {
                            piecesDictionary[arr[1]].KeyNote = arr[2];
                            Console.WriteLine($"Changed the key of {arr[1]} to {arr[2]}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {arr[1]} does not exist in the collection.");
                        }
                        break;
                    default:
                        break;
                }
            }
            foreach (KeyValuePair<string, Pieces> piece in piecesDictionary)
            {
                Console.WriteLine($"{piece.Value.Piece} -> Composer: {piece.Value.Composer}, Key: {piece.Value.KeyNote}");
            }
        }
    }
    class Pieces
    {
        public string Piece;
        public string Composer;
        public string KeyNote;

        public Pieces(string piece, string composer, string keyNote)
        {
            Piece = piece;
            Composer = composer;
            KeyNote = keyNote;
        }
    }

}
