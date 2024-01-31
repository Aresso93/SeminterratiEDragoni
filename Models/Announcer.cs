using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminterratiEDragoni.Models
{
    internal class Announcer
    {
        public static void RoundStart(Hero hero1, Hero hero2)
        {
            Console.WriteLine("First challenger!" +
                              "\nName: " + hero1.Name +
                              "\nHitpoints: " + hero1.HP +
                              "\nStrength: " + hero1.Strength +
                              "\nDexterity: " + hero1.Dexterity +
                              "\nIntelligence: " + hero1.Intelligence +
                              "\n"
                              );
            Console.WriteLine("And the opponent!" +
                              "\nName: " + hero2.Name +
                              "\nHitpoints: " + hero2.HP +
                              "\nStrength: " + hero2.Strength +
                              "\nDexterity: " + hero2.Dexterity +
                              "\nIntelligence: " + hero2.Intelligence +
                              "\n"
                              );
            Console.WriteLine("Press enter to start the round");
        }

        public static void RoundEnd(Hero hero1, Hero hero2)
        {
            Console.WriteLine($"{hero1.Name}'s HP: {hero1.HP}\n{hero2.Name}'s HP: {hero2.HP}");
            Console.WriteLine("Next round starting soon...");
        }
    }
}
