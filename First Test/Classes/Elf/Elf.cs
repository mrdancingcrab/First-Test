using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace First_Test.Classes.Elf
{
    public class Elf : GameObject
    {
        public float Echo = 100;
        public float MaxEcho = 100;

        public Elf(string name, float maxHP, int attackStrength, float defense, float criticalChance, float evasionChance, int maxEcho)
            : base(name, maxHP, attackStrength, defense, criticalChance, evasionChance)
        {
            MaxEcho = maxEcho;
            Echo = MaxEcho;
        }
        public override float Attack()
        {
            int randomAttack = new Random().Next(1, 4);
            float damage;
            bool IsAlive = true;

            while (IsAlive)
            {
                Console.WriteLine("1. Resin of Rot");
                Console.WriteLine("2. Ice Blast");
                Console.WriteLine("3. Ice Blast");
                Console.WriteLine("4. Ice Blast");

                switch(randomAttack)
                {
                    case 1:
                        ResinOfRot();
                        IsAlive = false;
                        break;
                    case 2:
                        ResinOfRot();
                        IsAlive = false;
                        break;
                    case 3:
                        ResinOfRot();
                        IsAlive = false;
                        break;
                    case 4:
                        ResinOfRot();
                        IsAlive = false;
                        break;
                }
                return 0;
            }
            return 0;
        }

        public float ResinOfRot()
        {
            int spellCost = 25;

            if (Echo < spellCost)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Not enough echo!");
                RegenerateEcho();
                Console.WriteLine();
                Console.ResetColor();
                return 0;
            }
            else
            {
                Random random = new Random();
                float baseDamage = new Random().Next(15, 25);
                Echo -= spellCost;

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} casts a CRITICAL rotten hit for {baseDamage} forest dmg!!!");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} casts Rotten Resin for {baseDamage} forest dmg.");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                return baseDamage;
            }
        }

        public void RegenerateEcho()
        {
            int echoRestored = new Random().Next(5, 10);
            Echo += echoRestored;
            if (Echo > MaxEcho) Echo = MaxEcho;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Name} restores {echoRestored} echo. Total echo: {Echo}/{MaxEcho}");
            Console.ResetColor();
        }
    }
}
