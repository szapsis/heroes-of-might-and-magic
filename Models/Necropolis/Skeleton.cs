using Heroes_of_Might_and_Magic.Models;

namespace Heroes_of_Might_and_Magic.Models.Units.Necropolis
{
    public class Skeleton : Unit
    {
        public Skeleton(int count)
        : base(
        name: "Skeleton",
        count: count,
        attack: 5,
        defense: 4,
        minDamage: 1,
        maxDamage: 3,
        health: 6)
        {
        }
    }
}
