namespace HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Heroes> heroes = new Dictionary<string, Heroes>();
            int numHeroes = int.Parse(Console.ReadLine());  
            for (int i = 0; i < numHeroes; i++)
            {
                string[] inp = Console.ReadLine().Split();
                string name = inp[0];
                int hp = int.Parse(inp[1]);
                int mp = int.Parse(inp[2]);
                Heroes hero = new Heroes(name, hp, mp);
                heroes.Add(name, hero);
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arr = input.Split(" - ");
                string command = arr[0];
                string name;
                switch (command)
                {
                    
                    case "CastSpell":
                        name = arr[1];
                        int mpNeeded = int.Parse(arr[2]);
                        string spellName = arr[3];
                        if (heroes[name].MP >= mpNeeded)
                        {
                            
                            Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroes[name].MP - mpNeeded} MP!");
                            heroes[name].MP -= mpNeeded;
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        name= arr[1];
                        int damage = int.Parse(arr[2]);
                        string attacker = arr[3];
                        heroes[name].HP -= damage;
                        if (heroes[name].HP <= 0)
                        {
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                            heroes.Remove(name);
                        }
                        else
                        {
                            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");
                        }
                        break;
                    case "Recharge":
                        name= arr[1];
                        int amount = int.Parse(arr[2]);
                        int orgAmount = heroes[name].MP;
                        heroes[name].MP += amount;
                        if (heroes[name].MP > 200)
                        {
                            heroes[name].MP = 200;
                            Console.WriteLine($"{name} recharged for {200 - orgAmount} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} recharged for {amount} MP!");
                        }
                        break;
                    case "Heal":
                        name = arr[1];
                        int healAmount = int.Parse(arr[2]);
                        int orgLevel = heroes[name].HP;
                        heroes[name].HP += healAmount;
                        if (heroes[name].HP > 100)
                        {
                            heroes[name].HP = 100;
                            Console.WriteLine($"{name} healed for {100 - orgLevel} HP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} healed for {healAmount} HP!");
                        }
                        break;

                    default:
                        break;
                }
            }
            foreach (KeyValuePair<string, Heroes> hero in heroes)
            {
                Console.WriteLine($"{hero.Value.Name}");
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
    class Heroes
    {
        public string Name;
        public int HP;
        public int MP;

        public Heroes(string name, int hP, int mP)
        {
            Name = name;
            HP = hP;
            MP = mP;
        }
    }
}
