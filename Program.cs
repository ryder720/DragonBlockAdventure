using System;

namespace DragonBlockAdventure_1
{
    class Program
    {
        static void Main()
        {
            Game.StartGame();
            

            // Exiting
            Console.WriteLine("Exiting Application");
            Console.ReadKey();
        }



        
    }

    public static class Game{
        // Create the player character
        static Character Player = new Character();


        // Game Methods
        public static void StartGame(){
            Console.WriteLine("Welcome to Dragon Block C Adventure!");
            Console.WriteLine("DBC: Adventure! is all about training to get stronger and defeating the enemies in your way to completing your goal.");
            
        }
        
        // Player Methods
        static void NewCharacter(){
            Console.WriteLine("What will your character's name be?");
            string charName = Console.ReadLine();
            Player.Name = charName;
        }

        
    }
    
    // Class for all characters base
    public class Character{
        public string Name = "John Doe";
        public int battlePower;
        public int stamina;
        public int maxStamina = 10;
        public int ki;
        public int maxKi = 10;
        public int health;
        public int maxHealth = 100;
        public int speed = 5;
        public int attack = 5;
        public int defence = 5;
        public int kiAttack = 5;

        // Formula to calculate battle power. Probably needs a ton of work to balance
        public int CalcBattlePower(){
            return ((maxStamina+maxKi+(maxHealth/10))/5+speed+attack+defence+kiAttack);
        }
    }

    // Start of item class. Will probably have a seperate file as a dictionary using this class so may move it.
    public class Item{
        string name;

    }

}
