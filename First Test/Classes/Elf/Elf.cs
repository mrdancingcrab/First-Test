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
            float damage = 0;
            bool IsAlive = true;

            Console.WriteLine("1. Resin of Rot");
            Console.WriteLine("2. VineWhip");
            Console.WriteLine("3. Stone Block");
            Console.WriteLine("4. Heal");
            int.TryParse(Console.ReadLine(), out int choice);

            while (IsAlive)
            {
                

                switch(choice)
                {
                    case 1:
                        damage = ResinOfRot();
                        IsAlive = false;
                        break;
                    case 2:
                        damage = VineWhip();
                        IsAlive = false;
                        break;
                    case 3:
                        damage = StoneBlock();
                        IsAlive = false;
                        break;
                    case 4:
                        Heal();
                        IsAlive = false;
                        break;
                }
            }
            return damage;
        }

        public float ResinOfRot()
        {
            int spellCost = 20;

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
                float baseDamage = new Random().Next(15, 20);
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

        public float VineWhip()
        {
            int spellCost = 10;

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
                float baseDamage = new Random().Next(5, 10);
                Echo -= spellCost;

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} throws a CRITICAL whip hit for {baseDamage} forest dmg!!!");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} whips you for {baseDamage} forest dmg.");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                return baseDamage;
            }
        }


        public float StoneBlock()
        {
            int spellCost = 15;

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
                float baseDamage = new Random().Next(10, 15);
                Echo -= spellCost;

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} smashes you with a big stone block and deals {baseDamage} CRITICAL forest dmg!!!");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} smashes you with a big stone block and deals {baseDamage} forest dmg.");
                    RegenerateEcho();
                    Console.ResetColor();
                }
                return baseDamage;
            }
        }

        public virtual void Heal()
        {
            float amount = 10;

            if (HP < MaxHP)
            {
                float restAmount = MaxHP - HP;
                HP += amount;
                if (HP > MaxHP)
                {
                    HP = MaxHP;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} healed for {restAmount} HP,\n{Name} Current HP: {HP}/{MaxHP}.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} healed for {amount}HP,\n{Name} Current HP: {HP}/{MaxHP}.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} is already at full health,\n{Name} Current HP: {HP}/{MaxHP}.\n");
                Console.ResetColor();
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
