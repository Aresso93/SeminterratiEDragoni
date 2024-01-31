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
            //Console.WriteLine($"Strength check for {hero.Name}! \n-----------------------");
            if (Models.Hero.RollToHit(hero))
            {
                //Console.WriteLine($"Intelligence check for {hero.Name}! \n-----------------------");
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

        static void Dodge(Hero hero)
        {
            //Console.WriteLine($"Dexterity check for {hero.Name}! \n-----------------------");
            if (Models.Hero.RollToDodge(hero) == true)
            {
                Console.WriteLine("Piccolo would be proud!\n");
            } else
            {
                Console.WriteLine("Why... didn't you... DOOOOOOOOOOOOODGE!?\n");
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


//Console.WriteLine($"Round {roundNumber}! FIGHT!");

//if (Models.Hero.RollToHit(hero1))
//{
//    if (Models.Hero.RollToDodge(hero2) == false)
//    {
//        if (Models.Hero.RollToDoubleDamage(hero1))
//        {
//            int damage = Models.Hero.RollForDamage() * 2;
//            hero2.HP = hero2.HP - damage;
//            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
//            if (hero2.HP <= 0)
//            {
//                Models.Hero.HeroDeath(hero2);
//                break;
//            }
//        }
//        else
//        {
//            int damage = Models.Hero.RollForDamage();
//            hero2.HP = hero2.HP - damage;
//            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
//            if (hero2.HP <= 0)
//            {
//                Models.Hero.HeroDeath(hero2);
//                break;
//            }
//        }
//    }
//    else
//    {
//        Console.WriteLine("Piccolo would be proud! Next round!\n");
//    }
//}
//else
//{
//    Console.WriteLine("Next round!");
//}

//if (Models.Hero.RollToHit(hero2))
//{
//    if (Models.Hero.RollToDodge(hero1) == false)
//    {
//        if (Models.Hero.RollToDoubleDamage(hero2))
//        {
//            int damage = Models.Hero.RollForDamage() * 2;
//            hero1.HP = hero1.HP - damage;
//            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
//            if (hero1.HP <= 0)
//            {
//                Models.Hero.HeroDeath(hero1);
//                break;
//            }
//        }
//        else
//        {
//            int damage = Models.Hero.RollForDamage();
//            hero1.HP = hero1.HP - damage;
//            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
//            if (hero1.HP <= 0)
//            {
//                Models.Hero.HeroDeath(hero1);
//                break;
//            }
//        }
//    }
//    else
//    {
//        Console.WriteLine("Piccolo would be proud! Next round!\n");
//    }
//}
//else
//{
//    Console.WriteLine("Next round!\n");
//}

//static void BattlePhase(Hero hero, Hero opponent)
//{
//    if (Models.Hero.RollToHit(hero))
//    {
//        if (Models.Hero.RollToDodge(opponent) == false)
//        {
//            if (Models.Hero.RollToDoubleDamage(hero))
//            {
//                int damage = Models.Hero.RollForDamage() * 2;
//                opponent.HP = opponent.HP - damage;
//                Console.WriteLine($"{damage} damage! {opponent.Name} has {opponent.HP} HP left!\nNext round!\n");
//                if (opponent.HP <= 0)
//                {
//                    Models.Hero.HeroDeath(opponent);
//                }
//            }
//            else
//            {
//                int damage = Models.Hero.RollForDamage();
//                opponent.HP = opponent.HP - damage;
//                Console.WriteLine($"{damage} damage! {opponent.Name} has {opponent.HP} HP left!\nNext round!\n");
//                if (opponent.HP <= 0)
//                {
//                    Models.Hero.HeroDeath(opponent);
//                }
//            }
//        }
//        else
//        {
//            int damage = Models.Hero.RollForDamage();
//            opponent.HP = opponent.HP - damage;
//            Console.WriteLine($"{damage} damage! {opponent.Name} has {opponent.HP} HP left!\nNext round!\n");
//            if (opponent.HP <= 0)
//            {
//                Models.Hero.HeroDeath(opponent);
//            }
//            else
//            {
//                Console.WriteLine("Piccolo would be proud! Next round!\n");
//            }
//        }
//    }
//    else
//    {
//        Console.WriteLine("Next round!");
//    }
//}