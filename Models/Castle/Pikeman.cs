using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes_of_Might_and_Magic.Models;

namespace Heroes_of_Might_and_Magic.Models.Units.Castle
{
    public class Pikeman : Unit
    {
        public Pikeman(int count)
            : base(
                name: "Pikeman",
                count: count,
                attack: 4,
                defense: 5,
                minDamage: 1,
                maxDamage: 3,
                health: 10)
        {
        }
    }
}
