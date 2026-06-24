using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes_of_Might_and_Magic.Models;

namespace Heroes_of_Might_and_Magic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Unit pikeman = new Unit(name: "Pikeman", count: 10, attack: 4, defense: 5, minDamage: 1, maxDamage: 3, health: 10);
            Unit skeleton = new Unit(name: "Skeleton", count: 15, attack: 5, defense: 4, minDamage: 1, maxDamage: 3, health: 6);

            //Console.WriteLine($"{pikeman.Name} | ATK: {pikeman.Attack} | DEF: {pikeman.Defense} | DMG: {pikeman.Damage} | HP: {pikeman.Health}");
            //Console.WriteLine($"{skeleton.Name} | ATK: {skeleton.Attack} | DEF: {skeleton.Defense} | DMG: {skeleton.Damage} | HP: {skeleton.Health}");


            Fight(pikeman, skeleton);

        }

        static void Fight(Unit unit1, Unit unit2)
        {
            int round = 1;

            while (unit1.IsAlive && unit2.IsAlive)
            {
                Console.WriteLine("=== Battle Start ===");
                Console.WriteLine($"{unit1.Count} {unit1.Name} (HP: {unit1.TotalHealth})");
                Console.WriteLine("VS");
                Console.WriteLine($"{unit2.Count} {unit2.Name} (HP: {unit2.TotalHealth})");
                Console.WriteLine();

                Console.WriteLine($"=== Round {round} ===");

                int damage = unit1.GetDamage();
                Console.WriteLine($"{unit1.Name} attacks {unit2.Name} for {damage} damage");
                unit2.TakeDamage(damage);
                Console.WriteLine($"{unit2.Count} {unit2.Name} HP: {unit2.TotalHealth}");

                if (!unit2.IsAlive)
                {
                    Console.WriteLine($"{unit2.Count} {unit2.Name} died. {unit1.Name} wins!");
                    break;
                }

                damage = unit2.GetDamage();
                Console.WriteLine($"{unit2.Name} attacks {unit1.Name} for {damage} damage");
                unit1.TakeDamage(damage);
                Console.WriteLine($"{unit1.Count} {unit1.Name} HP: {unit1.TotalHealth}");

                if (!unit1.IsAlive)
                {
                    Console.WriteLine($"{unit1.Count} {unit1.Name} died. {unit2.Name} wins!");
                    break;
                }

                Console.WriteLine();
                round++;
            }

        }
    }
}
