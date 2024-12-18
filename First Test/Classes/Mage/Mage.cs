using First_Test.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Test.Classes.Mage
{
    public class Mage : GameObject
    {
        public float Mana = 100;
        public float MaxMana = 100;

        public Mage(string name, float maxHp, int attackStrength, float defense, float critChance, float evadeChance, int maxMana)
            : base(name, maxHp, attackStrength, defense, critChance, evadeChance, Element.Lightning)
        {
            MaxMana = maxMana;
            Mana = MaxMana;
        }

        public override float Attack()
        {
            int spellCost = 10;

            if (Mana < spellCost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough mana!");
                Console.ResetColor();
                return 0;
            }
            else
            {
                Random random = new Random();
                float baseDamage = random.Next(15, 25);
                Mana -= spellCost;

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{Name} casts a CRITICAL hit for {baseDamage} dmg!!!");
                    RegenerateMana();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"{Name} casts a spell for {baseDamage} magic dmg.");
                    RegenerateMana();
                    Console.ResetColor();
                }
                return baseDamage;

            }
        }
        public void RegenerateMana()
        {
            int manaRestored = new Random().Next(5, 15);
            Mana += manaRestored;
            if (Mana > MaxMana) Mana = MaxMana;
            Console.WriteLine($"{Name} restores {manaRestored} mana. Total mana: {Mana}/{MaxMana}");
        }
    }
}
