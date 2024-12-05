using First_Test.Classes;

namespace First_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Kajkel", 100, 20, 5, 0.2f, 0.1f);
            Enemy enemy = new Enemy("KornKorn", 100, 20, 5, 0.2f, 0.1f);
            Battle(player, enemy);
        }
        
        static void Battle(Player player, Enemy enemy)
        {
            Console.WriteLine($"{enemy.Name} comes out of the closet!\n");

            while (player.IsAlive() && enemy.IsAlive())
            {
                enemy.TakeDamage(player.Attack());
                if (!enemy.IsAlive())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{enemy.Name} took to much korn and died...");
                    Console.ResetColor();
                    break;
                }

                player.TakeDamage(enemy.Attack());
                if (!player.IsAlive())
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"{player.Name} took to much korn and died...");
                    Console.ResetColor();
                    break;
                }
            }
            Console.WriteLine("\nThe fight is over!");
        }
    }
}
