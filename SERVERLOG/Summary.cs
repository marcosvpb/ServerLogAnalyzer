using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVERLOG
{
    class Summary
    {
        static List<Entity> damageEntities = new List<Entity>();
        static List<Entity> damagePlayers = new List<Entity>();


        public static void addPlayer(string name, int damage)
        {
            bool checkExists = damagePlayers.Any(x => x.Name == name);
            if (checkExists)
            {
                var player = damagePlayers.First(x => x.Name == name);
                player.Damage += damage;
            }
            else
            {
                damagePlayers.Add(new Entity(name, damage));
            }
        }

        public static void addMonster(string name, int damage)
        {
            bool checkExists = damageEntities.Any(x => x.Name == name);
            if (checkExists)
            {
                var monster = damageEntities.First(x => x.Name == name);
                monster.Damage += damage;
            }
            else
            {
                damageEntities.Add(new Entity(name, damage));
            }
        }

        public static void showOverallDamagePlayers()
        {
            damagePlayers.ForEach(x => Console.WriteLine("{0} deals a total of {1} on you.",x.Name,x.Damage));
 
        }

        public static void showOverallDamageMonsters()
        {
            damageEntities.ForEach(x => Console.WriteLine("{0} deals a total of {1} on you.", x.Name, x.Damage));

        }
    }
}
