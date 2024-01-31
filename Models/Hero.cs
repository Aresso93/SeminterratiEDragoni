using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminterratiEDragoni.Models
{
    class Hero
    {
        public int HP { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public static void HeroDeath(Hero hero)
        {
            Console.WriteLine($"{hero.Name} has been vanquished. This is so sad... Alexa, play Requiem by Wolfgang Amadeus Mozart");
        }
        public static int DiceRoll()
        {
            Random roll = new Random();
            return roll.Next(1, 20);
        }
        public static bool RollToHit(Hero hero)
        {
            int attackRoll = DiceRoll();
            bool hit;
            Console.WriteLine($"Strength check for {hero.Name}! \n-----------------------");
            if (hero.Strength > attackRoll)
            {
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! The opponent will try to dodge!\n\n");
                hit = true;
                return hit;
            }
            else
            {
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! Miss!\n");
                hit = false;
                return hit;
            }
        }

        public static bool RollToDodge(Hero hero1, Hero hero2)
        {
            bool dodge;
            int dodgeRoll = DiceRoll();
            Console.WriteLine($"Dexterity check for {hero1.Name}! \n-----------------------");
            if (hero1.Dexterity > dodgeRoll)
            {
                Console.WriteLine($"{hero1.Name} rolled a {dodgeRoll}! {hero1.Name} dodged {hero2.Name}\'s attack!\n");
                dodge = true;
                return dodge;
            }
            else
            {
                Console.WriteLine($"{hero1.Name} rolled a {dodgeRoll}! {hero1.Name} wasn't able to dodge!\n");
                dodge = false;
                return dodge;
            }
        }
        public static bool RollToDoubleDamage(Hero hero)
        {
            int doubleDamageCheck = DiceRoll();
            bool doubleDamage;
            Console.WriteLine($"Intelligence check for {hero.Name}! \n-----------------------");
            if (hero.Intelligence > doubleDamageCheck)
            {
                Console.WriteLine("It's a critical hit!");
                doubleDamage = true;
                return doubleDamage;
            }
            else
            {
                Console.WriteLine("It's a regular hit!");
                doubleDamage = false;
                return doubleDamage;
            }
        }

        public static int RollForDamage()
        {
            Random roll = new Random();
            int damage = roll.Next(1, 10);
            return damage;
        }
    }
}
