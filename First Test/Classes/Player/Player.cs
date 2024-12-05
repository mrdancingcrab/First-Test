using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace First_Test.Classes.Player
{
    public class Player : GameObject
    {
        public Player(string name, float maxHP, int attackStrength, float defense, float criticalChance, float evadeChance)
            : base(name, maxHP, attackStrength, defense, criticalChance, evadeChance)
        {

        }
        public override float Attack()
        {
            int randomAttack = new Random().Next(1, 4);
            float damage = 0;
            bool IsAlive = true;
            Console.WriteLine("1. Children of the Korn");
            Console.WriteLine("2. Korn on the Kob");
            Console.WriteLine("3. Kornrows");
            Console.WriteLine("4. Heal");
            int.TryParse(Console.ReadLine(), out int choice);

            while (IsAlive)
            {
                switch (choice)
                {
                    case 1:
                        damage = ChildrenOfTheKorn();
                        IsAlive = false;
                        break;
                    case 2:
                        damage = KornOnTheKob();
                        IsAlive = false;
                        break;
                    case 3:
                        damage = KornRows();
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

        public float ChildrenOfTheKorn()
        {
            
                Random random = new Random();
                float baseDamage = new Random().Next(15, 20);

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{Name} sends out his Kornlings who deals {baseDamage} CRITICAL korn dmg!!!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} sends out his Kornlings who deals  {baseDamage} korn dmg.");
                    Console.ResetColor();
                }
                return baseDamage;
        }

        public float KornOnTheKob()
        {

            Random random = new Random();
            float baseDamage = new Random().Next(5, 10);

            if (random.NextDouble() < CriticalChance)
            {
                baseDamage = (int)(baseDamage * 1.5);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} throws in a Korn on the Kob and deals {baseDamage} korn dmg!!!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Name} throws in a Korn on the Kob and deals {baseDamage} korn dmg.");
                Console.ResetColor();
            }
            return baseDamage;
        }


        public float KornRows()
        {
                Random random = new Random();
                float baseDamage = new Random().Next(10, 15);

                if (random.NextDouble() < CriticalChance)
                {
                    baseDamage = (int)(baseDamage * 1.5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} takes 10 rows of korn and deals {baseDamage} CRITICAL korn dmg!!!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{Name} takes 10 rows of korn and deals {baseDamage} korn dmg.");
                    Console.ResetColor();
                }
                return baseDamage;
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

    }
}
