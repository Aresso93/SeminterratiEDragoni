using SeminterratiEDragoni.Models;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace SeminterratiEDragoni
{
    internal class Program
    {
        static int DiceRoll()
        {
            Random roll = new Random();
            return roll.Next(10, 20);
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
        static void PlayAgain(string input)
        {
            if (input.ToLower().Trim() == "no")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Fight(CreateCharacter(), CreateCharacter());
            }
        }

        static int Attack(Hero hero)
        {
            if (Models.Hero.RollToHit(hero))
            {
                if (Models.Hero.RollToDoubleDamage(hero))
                {
                    int damage = Models.Hero.RollForDamage() * 2;
                    return damage;
                } else
                {
                    int damage = Models.Hero.RollForDamage();
                    return damage;
                }
            } else
            {
                return 0;
            }
        }

        static int RemainingHP(Hero hero, int damage)
        {
            hero.HP = hero.HP - damage;
           
            Console.WriteLine($"{hero.Name} took {damage} damage! {hero.Name}'s HP are now {hero.HP}");
            return hero.HP;
        }

        static void Fight(Hero hero1, Hero hero2)
        {
            Models.Announcer.RoundStart(hero1, hero2);
            int roundNumber = 1;
            while (hero1.HP > 0 && hero2.HP > 0)
            {
                Console.WriteLine($"Round {roundNumber}! FIGHT!");

                //Attack(hero1);
                
                Models.Hero.RollToDodge(hero2);

                //Attack(hero2);
                
                Models.Hero.RollToDodge(hero1);
                
                RemainingHP(hero1, Attack(hero2));
                RemainingHP(hero2, Attack(hero1));
                if (hero1.HP <= 0 && hero2.HP > 0)
                {
                    Models.Hero.HeroDeath(hero1);
                    break;
                } else if (hero2.HP <= 0 && hero1.HP > 0)
                {
                    Models.Hero.HeroDeath(hero2);
                } else if (hero1.HP <= 0 && hero2.HP <= 0)
                {
                    Console.WriteLine($"IT'S A DOUBLE KO!!!");
                    break;
                }
                roundNumber += 1;
                Announcer.RoundEnd(hero1, hero2);
                Thread.Sleep(3000);
            }
            Console.WriteLine("Would you like to play again? Press anything for yes or type \"no\" for no");
            string input = Console.ReadLine()!;
            PlayAgain(input);
        }
        static void Main(string[] args)
        {
            Fight(CreateCharacter(), CreateCharacter());
        }
    }
}