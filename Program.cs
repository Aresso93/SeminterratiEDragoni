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
        static void HeroDeath(Hero hero)
        {
                Console.WriteLine($"{hero.Name} has been vanquished. This is so sad... Alexa, play Requiem by Wolfgang Amadeus Mozart");
        }
        static Hero CreateCharacter()
        {
            Hero hero = new Hero();
            Console.WriteLine("Name your hero!\n");
            hero.Name = Console.ReadLine()!;
            hero.HP = 100;
            hero.Strength = DiceRoll();
            hero.Dexterity = DiceRoll();
            hero.Intelligence = DiceRoll();
            Console.WriteLine("This is your hero!\n");
            Console.WriteLine("Name: " + hero.Name +
                              "\nHitpoints: " + hero.HP +
                              "\nStrength: " + hero.Strength +
                              "\nDexterity: " + hero.Dexterity +
                              "\nIntelligence: " + hero.Intelligence + "\n"
                              );
            return hero;
        }
        static bool RollToHit(Hero hero)
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
                Console.WriteLine($"{hero.Name} rolled a {attackRoll}! Miss!\n\n");
                hit = false;
                return hit;
            }
        }
        static bool RollToDodge(Hero hero1, Hero hero2)
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
                Console.WriteLine($"{hero1.Name} rolled a {dodgeRoll}! {hero1.Name} wasn't able to dodge!\n\n");
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
        static bool RollToDoubleDamage(Hero hero)
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

            while (hero1.HP > 0 && hero2.HP > 0)
            {
                if (RollToHit(hero1))
                {
                    if (RollToDodge(hero2, hero1) == false)
                    {
                        if (RollToDoubleDamage(hero1))
                        {
                            int damage = RollForDamage() * 2;
                            hero2.HP = hero2.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
                            if (hero2.HP <= 0)
                            {
                                HeroDeath(hero2);
                                break;
                            }
                        }
                        else
                        {
                            int damage = RollForDamage();
                            hero2.HP = hero2.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
                            if (hero2.HP <= 0)
                            {
                                HeroDeath(hero2);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Piccolo would be proud! Next round!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Next round!");
                }

                if (RollToHit(hero2))
                {
                    if (RollToDodge(hero1, hero2) == false)
                    {
                        if (RollToDoubleDamage(hero2))
                        {
                            int damage = RollForDamage() * 2;
                            hero1.HP = hero1.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
                            if (hero1.HP <= 0)
                            {
                                HeroDeath(hero1);
                                break;
                            }
                        }
                        else
                        {
                            int damage = RollForDamage();
                            hero1.HP = hero1.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
                            if (hero1.HP <= 0)
                            {
                                HeroDeath(hero1);
                                break;
                            }
                        } 
                    }
                    else
                    {
                        Console.WriteLine("Piccolo would be proud! Next round!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Next round!\n");
                }
                Console.WriteLine("Press enter for next round when ready");
                Console.ReadLine();
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

            //Fight(paulJots, lukeAlbanians);
            Fight(CreateCharacter(), CreateCharacter());

        }
    }
}
