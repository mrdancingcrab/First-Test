using First_Test.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace First_Test.Classes
{
    public class GameObject
    {
        public string Name { get; private set; }
        public float HP { get; set; }
        public float MaxHP { get; private set; }
        public int AttackStrength { get; private set; }
        public float Defense { get; private set; }
        public float CriticalChance { get; private set; }
        public float EvadeChance { get; private set; }
        public Element AttackElement { get; private set; }

        public GameObject(string name, float maxHP, int attackStrength, float defense, float criticalChance, float evadeChance, Element attackElement)
        {
            Name = name;
            MaxHP = maxHP;
            HP = maxHP;
            AttackStrength = attackStrength;
            Defense = defense;
            CriticalChance = criticalChance;
            EvadeChance = evadeChance;
            AttackElement = attackElement;
        }



        public virtual float Attack()
        {
            Random random = new Random();
            float baseDamage = random.Next(AttackStrength - 5, AttackStrength + 5);

            if (random.NextDouble() < CriticalChance)
            {
                baseDamage = (float)(baseDamage * 1.5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{Name} deals a CRITICAL strike for {baseDamage} {AttackElement}-dmg!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{Name} deals a strike for {baseDamage} {AttackElement}-dmg.");
            }
            return baseDamage;
        }



        public virtual void TakeDamage(float amount)
        {
            Random rand = new Random();
            if (rand.NextDouble() < EvadeChance)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{Name} evades the attack!");
                Console.ResetColor();
                Console.WriteLine($"{Name} Current HP: {HP}/{MaxHP}\n");
                return;
            }

            float reducedDamage = amount - Defense;
            if (reducedDamage < 0)
            {
                reducedDamage = 0;
            }
            else
            {
                HP -= reducedDamage;
                if (HP < 0) { HP = 0; }
                Console.WriteLine($"{Name} takes {reducedDamage} dmg due to his {Defense} def.\n{Name} Current HP: {HP}/{MaxHP}\n");
            }
        }


        public virtual void Heal(float amount)
        {
            if (HP < MaxHP)
            {
                float restAmount = MaxHP - HP;
                HP += amount;
                if (HP > MaxHP)
                {
                    HP = MaxHP;
                    Console.WriteLine($"{Name} healed for {restAmount} HP,\n{Name} Current HP: {HP}/{MaxHP}.\n");
                }
                else
                {
                    Console.WriteLine($"{Name} healed for {amount}HP,\n{Name} Current HP: {HP}/{MaxHP}.\n");
                }
            }
            else
            {
                Console.WriteLine($"{Name} is already at full health,\n{Name} Current HP: {HP}/{MaxHP}.\n");
            }
        }

        public bool IsAlive()
        {
            return HP > 0;
        }
    }

    public abstract class Enemy : GameObject
    {
        public Enemy(string name, float maxHP, int attackStrength, float defense, float criticalChance, float evadeChance, Element attackElement)
            : base(name, maxHP, attackStrength, defense, criticalChance, evadeChance, attackElement)
        { 
        }
    }
}
 
