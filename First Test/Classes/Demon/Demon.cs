using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Test.Classes.Demon
{
    public class Demon : GameObject
    {
        public float Nether = 100;
        public float MaxNether = 100;

        public Demon(string name, float maxHP, int attackStrength, float defense, float criticalChance, float evasionChance, int maxNether)
            : base(name, maxHP, attackStrength, defense, criticalChance, evasionChance, Enum.Element.Fire)
        {
            MaxNether = maxNether;
            Nether = MaxNether;
        }

        public override float Attack()
        {
            int spellCost = 25;
            if (Nether < spellCost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough nether!");
                RegenerateNether();
                Console.ResetColor();
                return 0;
            }
            else
            {
                Random random = new Random();
                float baseDamage = random.Next(15, 25);
                Nether -= spellCost;

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{Name} casts a CRITICAL hit for {baseDamage} Fire-dmg!!!");
                    RegenerateNether();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} casts a spell for {baseDamage} Fire-dmg.");
                    RegenerateNether();
                    Console.ResetColor();
                }
                return baseDamage;
            }
        }

        public void RegenerateNether()
        {
            int netherRestored = new Random().Next(5, 10);
            Nether += netherRestored;
            if (Nether > MaxNether) Nether = MaxNether;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{Name} restores {netherRestored} nether. Total nether: {Nether}/{MaxNether}");
            Console.ResetColor();
        }

    }
}
