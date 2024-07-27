namespace Problem_Three_Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Cities> cities = new Dictionary<string, Cities>();
            string firstInput;
            while ((firstInput = Console.ReadLine()) != "Sail")
            {
                string[] inputArr = firstInput.Split("||");
                string name = inputArr[0];
                long population = long.Parse(inputArr[1]);
                long gold = long.Parse(inputArr[2]);
                if (cities.ContainsKey(name))
                {
                    cities[name].Gold += gold;
                    cities[name].Population += population;
                }
                else
                {
                    Cities city = new Cities(name, population, gold);
                    cities.Add(name, city);
                }    
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                string[] inputArr = secondInput.Split("=>");
                string command = inputArr[0];
                
                switch (command)
                {
                    case "Plunder":
                        string city1 = inputArr[1];
                        if (cities.ContainsKey(city1))
                        {
                            long peopleKilled = long.Parse(inputArr[2]);
                            long goldStollen = long.Parse(inputArr[3]);
                            if (cities[city1].Gold <= 0 || cities[city1].Population <= 0)
                            {
                                cities.Remove(city1);
                                Console.WriteLine($"{city1} has been wiped off the map!");
                            }
                            else
                            {
                                cities[city1].Gold -= goldStollen;
                                cities[city1].Population -= peopleKilled;
                                Console.WriteLine($"{city1} plundered! {goldStollen} gold stolen, {peopleKilled} citizens killed.");
                            }
                            if(cities[city1].Gold <= 0 || cities[city1].Population <= 0)
                            {
                                cities.Remove(city1);
                                Console.WriteLine($"{city1} has been wiped off the map!");
                            }
                        }
                        break;
                    case "Prosper":
                        string city2 = inputArr[1];
                        if (cities.ContainsKey(city2))
                        {
                            long goldGained = long.Parse(inputArr[2]);
                            if (goldGained < 0)
                            {
                                Console.WriteLine("Gold added cannot be a negative number!");
                            }
                            else
                            {
                                cities[city2].Gold += goldGained;
                                Console.WriteLine($"{goldGained} gold added to the city treasury. {city2} now has {cities[city2].Gold} gold.");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (KeyValuePair<string, Cities> city in cities)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
    class Cities
    {
        public string Name;
        public long Population;
        public long Gold;

        public Cities(string name, long population, long gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }
    }
}
