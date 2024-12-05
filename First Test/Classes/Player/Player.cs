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

    }
}
