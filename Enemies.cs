using System;
using System.Collections.Generic;


namespace DragonBlockAdventure_1{

    
    public static class EnemyList{

        public static List<Character> enemyList = new List<Character>();


        
        public static void InitEnemyList(){
            // Creating enemies then adding them to the list to pull during fights

            // Wolf Level 1
            Character wolfLVL1 = new Character{Name = "Wolf", level = 1, maxStamina = 10, maxKi = 2, maxHealth = 10, 
            speed = 8, attack = 8, defence = 1, kiAttack = 0};
            wolfLVL1.RestoreCharacter();
            enemyList.Add(wolfLVL1);  



        }
    }
    
}