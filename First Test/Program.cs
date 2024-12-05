using First_Test.Classes;
using First_Test.Classes.Demon;
using First_Test.Classes.Elf;
using First_Test.Classes.Mage;
using First_Test.Classes.Player;

namespace First_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kajkel", 100, 20, 5, 0.2f, 0.1f);
            Enemy enemy = new Enemy("KornKorn", 100, 20, 5, 0.2f, 0.1f);
            Mage mage = new Mage("Magel", 120, 25, 2, 0.2f, 0.25f, 100);
            Demon demon = new Demon("Demikorn", 100, 30, 10, 0.5f, 0.05f, 100);
            Elf elf = new Elf("Kornolas", 100, 30, 10, 0.2f, 0.3f, 100);
            Battle(player, elf);
        }
        
        static void Battle(GameObject player, GameObject enemy)
        {
            Console.WriteLine($"{enemy.Name} comes out of the closet!\n");

            while (player.IsAlive() && enemy.IsAlive())
            {
                enemy.TakeDamage(player.Attack());
                if (!enemy.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{enemy.Name} took too much korn and died...");
                    player.Heal(10);
                    enemy.Heal(10);
                    Console.ResetColor();
                    break;
                }

                player.TakeDamage(enemy.Attack());
                if (!player.IsAlive())
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} took too much korn and died...");
                    Console.ResetColor();
                    break;
                }
            }
            Console.WriteLine("\nThe fight is over!");
        }
    }
}
