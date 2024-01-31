using SeminterratiEDragoni.Models;

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
            string newInput = Console.ReadLine();
            if (input.ToLower().Trim() == "y")
            {
                Fight(CreateCharacter(), CreateCharacter());
            }
            else if (input.ToLower().Trim() == "n")
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Press Y to play again or N to exit");
                PlayAgain(newInput);
            }
        }

        static void BattlePhase(Hero hero)
        {
            
        }

        static void Fight(Hero hero1, Hero hero2)
        {
            Models.Announcer.RoundStart(hero1, hero2);
            Console.ReadLine();

            int roundNumber = 1;
            while (hero1.HP > 0 && hero2.HP > 0)
            {
                Console.WriteLine($"Round {roundNumber}! FIGHT!");
                if (Models.Hero.RollToHit(hero1))
                {
                    if (Models.Hero.RollToDodge(hero2, hero1) == false)
                    {
                        if (Models.Hero.RollToDoubleDamage(hero1))
                        {
                            int damage = Models.Hero.RollForDamage() * 2;
                            hero2.HP = hero2.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
                            if (hero2.HP <= 0)
                            {
                                Models.Hero.HeroDeath(hero2);
                                break;
                            }
                        }
                        else
                        {
                            int damage = Models.Hero.RollForDamage();
                            hero2.HP = hero2.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero2.Name} has {hero2.HP} HP left!\nNext round!\n");
                            if (hero2.HP <= 0)
                            {
                                Models.Hero.HeroDeath(hero2);
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

                if (Models.Hero.RollToHit(hero2))
                {
                    if (Models.Hero.RollToDodge(hero1, hero2) == false)
                    {
                        if (Models.Hero.RollToDoubleDamage(hero2))
                        {
                            int damage = Models.Hero.RollForDamage() * 2;
                            hero1.HP = hero1.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
                            if (hero1.HP <= 0)
                            {
                                Models.Hero.HeroDeath(hero1);
                                break;
                            }
                        }
                        else
                        {
                            int damage = Models.Hero.RollForDamage();
                            hero1.HP = hero1.HP - damage;
                            Console.WriteLine($"{damage} damage! {hero1.Name} has {hero1.HP} HP left!\n");
                            if (hero1.HP <= 0)
                            {
                                Models.Hero.HeroDeath(hero1);
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
                roundNumber += 1;
                Announcer.RoundEnd(hero1, hero2);
                Thread.Sleep(3);
            }
            Console.WriteLine("Would you like to play again? Y/N");
            string input = Console.ReadLine()!;
            PlayAgain(input);
        }

        static void Main(string[] args)
        {
            Fight(CreateCharacter(), CreateCharacter());
        }
    }
}
