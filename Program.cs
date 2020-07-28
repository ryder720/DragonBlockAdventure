using System;

namespace DragonBlockAdventure_1
{
    public enum GAME_STATE{NONE, MENU, BATTLE, TRAINING, STORY}
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
            Console.Clear();
            Console.WriteLine("Welcome to Dragon Block C Adventure!");
            Console.WriteLine("DBC: Adventure! is all about training to get stronger and defeating the enemies in your way to completing your goal.");
            NewCharacter();
            MainMenu();
        }

        public static void MainMenu(){  // Show main menu screen
            Console.Clear();
            state = GAME_STATE.MENU;
            ShowStats();
            Console.WriteLine("\nType in the number of the option you want to select");  // Had a weird bug in vs code where it would show option 1&2 twice before stats
            Console.WriteLine("1.Story");
            Console.WriteLine("2.Training");
            Console.WriteLine("3.Character");
            Console.WriteLine("4.Options");
            Console.WriteLine("5.Exit");

            int selection = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            switch(selection){
                case 1:
                    Console.WriteLine("Coming Soon!");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 2:
                    Console.WriteLine("Coming Soon!");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("Coming Soon!");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    Console.WriteLine("Coming Soon!");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
        
        // Player Methods
        static void NewCharacter(){
            Console.WriteLine("What will your character's name be?");
            string charName = Console.ReadLine();
            Player.Name = charName;
            Player.level = 1;
            Player.RestoreCharacter();
            
        }

        static void ShowStats(){
            Console.WriteLine(Player.Name + " LVL:" + Player.level + " BP:" + Player.CalcBattlePower());
            Console.WriteLine("HP: " + Player.health + "/" + Player.maxHealth);
            Console.WriteLine("KI: " + Player.ki + "/" + Player.maxKi);
            Console.WriteLine("STAMINA: " + Player.stamina + "/" + Player.maxStamina);
            Console.WriteLine("Attack:" + Player.attack);
            Console.WriteLine("KiAttack:" + Player.kiAttack);
            Console.WriteLine("Defence:" + Player.defence);
            Console.WriteLine("Speed:" + Player.speed);
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

    public static class Battle{
        static BATTLE_STATE bState = BATTLE_STATE.NONE;

        public static void StartBattle(Character enemy){  // Need to reference enemy in the start battle. I'll learn how to make a seperate file for enemies
            enemy.RestoreCharacter();
        }


    }
    
    // Class for all characters base
    public class Character{
        public string Name = "John Doe";
        public int level;
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
            return (((maxStamina+maxKi+(maxHealth/10))/5+speed+attack+defence+kiAttack)/5);
        }

        public void RestoreCharacter(){
            ki = maxKi;
            health = maxHealth;
            stamina = maxStamina;
        }

        public void initCharacter(String name, int totHealth, int totKi, int totStamina, int spd, int atk, int def, int kiAtk){
            Name = name;
            maxHealth = totHealth;
            maxKi = totKi;
            maxStamina = totStamina;
            speed = spd;
            attack = atk;
            defence = def;
            kiAttack = kiAtk;
        }
    }

    // Start of item class. Will probably have a seperate file as a dictionary using this class so may move it.
    public class Item{
        string name;

    }

}
