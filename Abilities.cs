using System;



namespace DragonBlockAdventure_1{


    public class Ability{
        public string name = "Default-Something went wrong";
        public int level = 1;
        public int damage = 0;
        public int stamUse = 0;
        public int stamDrain = 0;
        public int kiUse = 0; // If it's a one time use
        public int kiDrain = 0; // If it drains per turn
        public int healthUse = 0;
        public int healthDrain = 0;
        public int speedModifier = 0;
        public int attackModifier = 0;
        public int defenceModifier = 0;
        public int turnRecharge = 0;
        public bool inUse = false; // Used for things you can turn off
        public int turnLimit = 0;
        public int chanceToHit = 0;


    }

    





}