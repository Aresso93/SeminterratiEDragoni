using SeminterratiEDragoni.Models;
using static System.Net.Mime.MediaTypeNames;

namespace SeminterratiEDragoni
{
    internal class Program
    {
        static int DiceRoll()
        {
            Random roll = new Random();
            return roll.Next(1, 20);
        }
        static Hero CreateCharacter()
        {
            Hero hero = new Hero();
            Console.WriteLine("Name your hero!");
            hero.Name = Console.ReadLine()!;
            hero.HP = 100;
            hero.Strength = DiceRoll();
            hero.Dexterity = DiceRoll();
            hero.Intelligence = DiceRoll();
            Console.WriteLine("Name: " + hero.Name +
                              "\nHitpoints: " + hero.HP +
                              "\nStrength: " + hero.Strength +
                              "\nDexterity: " + hero.Dexterity +
                              "\nIntelligence: " + hero.Intelligence
                              );
            return hero;
        }

        static bool RollToHit(Hero hero)
        {
            int attackRoll = DiceRoll();
            bool hit;
            Console.WriteLine("Strength check! \n-----------------------");
            if (hero.Strength > attackRoll)
            {
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! The opponent will try to dodge!\n***********************");
                hit = true;
                return hit;
            }
            else
            {
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! Miss!\n***********************");
                hit = false;
                return hit;
            }
            
        }

        static bool RollToDodge(Hero hero1, Hero hero2)
        {
            bool dodge;
            int dodgeRoll = DiceRoll();
            Console.WriteLine("Dexterity check! \n-----------------------");
            if (hero1.Dexterity > dodgeRoll)
            {
                Console.WriteLine($"{hero1.Name} rolled a {dodgeRoll}! {hero1.Name} dodged {hero2.Name}\'s attack!\n***********************");
                dodge = true;
                return dodge;
            } else
            {
                Console.WriteLine($"{hero1.Name} rolled a {dodgeRoll}! {hero1.Name} wasn't able to dodge!\n***********************");
                dodge = false;
                return dodge;
            }
        }

        static int RollForDamage()
        {
            Random roll = new Random();
            int damage = roll.Next(1, 10);
            return damage;
        }

        static Hero TakeDamage(Hero woundedHero)
        {
            woundedHero.HP = woundedHero.HP - RollForDamage();
            Console.WriteLine($"{woundedHero.Name}\'s HP are now {woundedHero.HP}");
            return woundedHero;
        }

        static bool RollToDoubleDamage(Hero hero)
        {
            int doubleDamageCheck = DiceRoll();
            bool doubleDamage;
            Console.WriteLine("Intelligence check! \n-----------------------");
            if (hero.Intelligence > doubleDamageCheck)
            {
                Console.WriteLine("It's a critical hit!");
                doubleDamage = true;
                return doubleDamage;

            } else
            {
                Console.WriteLine("It's a regular hit!");
                doubleDamage = false;
                return doubleDamage;
            }
        }

        static void Fight(Hero hero1, Hero hero2)
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
            Console.ReadLine();

            //while (hero1.HP > 0 && hero2.HP > 0) { 
                        //COSE DA CICLARE
            //}

            //if (RollToHit(hero1) == true && RollToDodge(hero2, hero1) == false)
            //{
            //    Console.WriteLine("Rolling for double damage...");

            //} else if (RollToDodge(hero2, hero1) == true)
            //{
            //    Console.WriteLine($"It's a hit on {hero2.Name}!");
            //}

            if (RollToHit(hero1))
            {
                if(RollToDodge(hero2, hero1) == false) 
                {
                    if (RollToDoubleDamage(hero1))
                    {
                        int damage = RollForDamage()*2;
                        hero2.HP = hero2.HP - damage;
                        Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!");
                    } else
                    {
                        int damage = RollForDamage();
                        hero2.HP = hero2.HP - damage;
                        Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!");
                    }
                }
            } else
            {
                Console.WriteLine("CULO");
            }
            
        }

        static void Main(string[] args)
        {
            Hero paulJots = new Hero();
            paulJots.Name = "Mario";
            paulJots.HP = 100;
            paulJots.Strength = 14;
            paulJots.Dexterity = 9;
            paulJots.Intelligence = 15;

            Hero lukeAlbanians = new Hero();
            lukeAlbanians.Name = "Pasta al forno";
            lukeAlbanians.HP = 100;
            lukeAlbanians.Strength = 17;
            lukeAlbanians.Dexterity = 6;
            lukeAlbanians.Intelligence = 13;

            Fight(paulJots, lukeAlbanians);
            //RollToDodge(lukeAlbanians, paulJots);
        }
    }
}


