using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes_of_Might_and_Magic.Models;
using Heroes_of_Might_and_Magic.Models.Units.Castle;
using Heroes_of_Might_and_Magic.Models.Units.Necropolis;

using Heroes_of_Might_and_Magic.AI;
using System.Threading.Tasks;

namespace Heroes_of_Might_and_Magic
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Unit pikeman = new Unit(name: "Pikeman", count: 10, attack: 4, defense: 5, minDamage: 1, maxDamage: 3, health: 10);
            //Unit skeleton = new Unit(name: "Skeleton", count: 15, attack: 5, defense: 4, minDamage: 1, maxDamage: 3, health: 6);
            Unit pikeman = new Pikeman(5);
            Unit skeleton = new Skeleton(5);

            //Console.WriteLine($"{pikeman.Name} | ATK: {pikeman.Attack} | DEF: {pikeman.Defense} | DMG: {pikeman.Damage} | HP: {pikeman.Health}");
            //Console.WriteLine($"{skeleton.Name} | ATK: {skeleton.Attack} | DEF: {skeleton.Defense} | DMG: {skeleton.Damage} | HP: {skeleton.Health}");

            Task<string> descriptionTask = Narrator.GetBattlefieldDescription(pikeman, skeleton);

            await ShowSwordLoading(descriptionTask);

            string description = await descriptionTask;

            Console.WriteLine("=== Battlefield ===");
            Console.WriteLine(description);
            Console.WriteLine();

            Fight(pikeman, skeleton);
        }

        static void Fight(Unit unit1, Unit unit2)
        {
            int round = 1;
            Console.WriteLine("=== Battle Start ===");
            Console.WriteLine($"{unit1.Count} {unit1.Name} (HP: {unit1.TotalHealth})");
            Console.WriteLine("VS");
            Console.WriteLine($"{unit2.Count} {unit2.Name} (HP: {unit2.TotalHealth})");
            Console.WriteLine();

            while (unit1.IsAlive && unit2.IsAlive)
            {
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

        static async Task ShowSwordLoading(Task descriptionTask)
        {
            string[] frames =
            {
        "🗡️    ",
        " 🗡️   ",
        "  🗡️  ",
        "   🗡️ ",
        "    🗡️",
        "   🗡️ ",
        "  🗡️  ",
        " 🗡️   "
    };

            int frame = 0;

            while (!descriptionTask.IsCompleted)
            {
                Console.Write($"\rGenerating battlefield {frames[frame]}");

                frame = (frame + 1) % frames.Length;

                await Task.Delay(150);
            }

            Console.Write("\r                              \r");
        }
    }
}
