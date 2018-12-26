using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVERLOG
{
    class Entity
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public Entity(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
    }
}
