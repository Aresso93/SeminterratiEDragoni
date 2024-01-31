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
            Console.WriteLine($"Strength check for {hero.Name}! \n-----------------------");
            int attackRoll = DiceRoll();
            bool hit;

            if (hero.Strength > attackRoll)
            {
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! The opponent will try to dodge!\n");
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
        public static bool RollToDodge(Hero hero)
        {
            bool dodge;
            int dodgeRoll = DiceRoll();
            //Console.WriteLine($"Dexterity check for {hero.Name}! \n-----------------------");
            if (hero.Dexterity > dodgeRoll)
            {
                Console.WriteLine($"{hero.Name} rolled a {dodgeRoll}! {hero.Name} dodged the opponent\'s attack!\nPiccolo would be proud!\n");
                
                dodge = true;
                return dodge;
            }
            else
            {
                Console.WriteLine($"{hero.Name} rolled a {dodgeRoll}! {hero.Name} wasn't able to dodge!\n{hero.Name}... Why... didn't you... DOOOOOOOOOOOOODGE!?\n");
                dodge = false;
                return dodge;
            }
        }
        public static bool RollToDoubleDamage(Hero hero)
        {
            int doubleDamageCheck = DiceRoll();
            bool doubleDamage;
            //Console.WriteLine($"Intelligence check for {hero.Name}! \n-----------------------");
            if (hero.Intelligence > doubleDamageCheck)
            {
                
                doubleDamage = true;
                return doubleDamage;
            }
            else
            {
                
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
