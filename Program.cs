using System;

namespace DragonBlockAdventure_1
{
    public enum GAME_STATE{NONE, MENU, BATTLE, TRAINING}
    public enum BATTLE_STATE{NONE, PLAYER_TURN, ENEMY_TURN, BEAM_STRUGGLE}  // Not sure how I want battles to go 100%
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
        // Create the player character will change if saving implemented
        static Character Player = new Character();
        static GAME_STATE state = GAME_STATE.NONE;


        // Game Methods
        public static void StartGame(){
            
            Console.WriteLine("Welcome to Dragon Block C Adventure!");
            Console.WriteLine("DBC: Adventure! is all about training to get stronger and defeating the enemies in your way to completing your goal.");
            NewCharacter();
            MainMenu();
        }

        public static void MainMenu(){  // Show main menu screen
            Console.Clear();
            state = GAME_STATE.MENU;
            Console.WriteLine("Menu Coming soon!");  // Need to design the menu
        }
        
        // Player Methods
        static void NewCharacter(){
            Console.WriteLine("What will your character's name be?");
            string charName = Console.ReadLine();
            Player.Name = charName;
            Player.RestoreCharacter();
        }

        // Dialog
        public static void PlayerDialog(String message){
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void EnemyDialog(string message){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void NpcDialog(string message){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
    
    // Class for all characters base
    public class Character{
        public string Name = "John Doe";
        public int level;
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

        public void RestoreCharacter(){
            ki = maxKi;
            health = maxHealth;
            stamina = maxStamina;
        }
    }

    // Start of item class. Will probably have a seperate file as a dictionary using this class so may move it.
    public class Item{
        string name;

    }

}
