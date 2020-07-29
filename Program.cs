using System;
using System.Collections.Generic;

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
        public static GAME_STATE state = GAME_STATE.NONE;


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
            int selection = 0;
            state = GAME_STATE.MENU;
            ShowStats();
            Console.WriteLine("\nType in the number of the option you want to select");  // Had a weird bug in vs code where it would show option 1&2 twice before stats
            Console.WriteLine("1.Story");
            Console.WriteLine("2.Training");
            Console.WriteLine("3.Character");
            Console.WriteLine("4.Options");
            Console.WriteLine("5.Exit");


            // Might throw this in a while loop instead of calling mainmenu everytime not sure
            try{
                selection = Convert.ToInt16(Console.ReadLine());
            }
            catch(FormatException e){
                Console.WriteLine("FormatError: " + e);
                
            }

                
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
                    Environment.Exit(0);
                    break;
                case 6:
                    try{
                        EnemyList.InitEnemyList();  // Will move this to startup
                        Character wolf = EnemyList.enemyList[0];
                        int wolfbp = wolf.CalcBattlePower();
                        Console.WriteLine(wolfbp);
                    }
                    catch(NullReferenceException e){
                        Console.WriteLine("Unable to grab enemy. Exception: " + e);
                    }
                    Console.WriteLine("Press Enter to Continue.");
                    Console.ReadKey();
                    MainMenu();
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

    public static class Battle{  // Going to be another file
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


        // Abilities

        public List<Ability> abilities = new List<Ability>();
        public void LearnAbility(Ability abil){
            if(!abilities.Contains(abil)){
                abilities.Add(abil);
                Console.WriteLine(Name + " learned: " + abil.name);
            }
            else
                Console.WriteLine(Name + " already knows " + abil.name + ".");
        }
        public void UnlearnAbility(Ability abil){
            if(abilities.Contains(abil)){
                abilities.Remove(abil);
                Console.WriteLine(abil + " removed from " + Name + ".");
            }
            else
                Console.WriteLine(Name + " doesn't know " + abil);
        }

        public void UseAbility(Ability ability, Character enemy){
            if(Game.state != GAME_STATE.BATTLE || !abilities.Contains(ability))
                return;
            // Need to check if you have the move
            // Can change this to something else to say you don't have ability or that it can't be used


            // Need to check if it's multi turn or not 
            bool multiTurn;
            switch(ability.turnLimit){
                case -1:
                    multiTurn = true;
                    ability.inUse = true;
                    break;
                case 0:
                    multiTurn = false;
                    break;
                default:
                    multiTurn = true;
                    ability.inUse = true;
                    // Need to relay to battle system that a multi turn abil is in use and to set a turn timer for it
                    // Might need to redo to apply damage or something like that for multi turn attacks or buffs
                    break;
            }

            if(multiTurn){
                health -= ability.healthDrain;
                ki -= ability.kiDrain;
                stamina -= ability.stamDrain;
            }
            else{
                health -= ability.healthUse;
                ki -= ability.kiUse;
                stamina -= ability.stamUse;
            }
            

            if(ability.chanceToHit != 100){  // For chance to miss
                Random r = new Random();
                int rInt = r.Next(0, 100); // Random range
                if(rInt > ability.chanceToHit)
                    return; // Show a miss text
            }

            speed += ability.speedModifier;
            attack += ability.attackModifier;
            defence += ability.defenceModifier;

            enemy.health -= (ability.damage + attack) - defence;
        }

    }

    // Start of item class. Will have a seperate file.
    public class Item{
        string name;

    }

}
