using SeminterratiEDragoni.Models;
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
                Console.WriteLine($"{hero1.Name}'s HP: {hero1.HP}\n{hero2.Name}'s HP: {hero2.HP}");
                Console.WriteLine("Press enter for next round when ready");
                roundNumber += 1;
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

            Fight(CreateCharacter(), CreateCharacter());

        }
    }
}
