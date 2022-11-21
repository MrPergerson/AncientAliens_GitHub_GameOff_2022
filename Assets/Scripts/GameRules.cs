using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AncientAliens
{
    public static class GameRules
    {
        // Wonder
        public static int startWonderProgress = 5;
        public static int maxWonderProgress = 100;
        public static int brickProgressValue = 10;

        // TileObjects
        public static int peopleValue = 10;
        public static int rockValue = 10;
        public static int brickValue = 5;
        public static int barbarianValue = 5;
        public static int cityValue = 10;

        // BarbarianAI
        public static float barbarianActionTick = 1;
        public static int damageToWonder = 5;
        public static int damageToPeople = 5;
        public static int damageToCity = 10;

        // Combinations
        public static float cityAndPeopleCombineTime = 20;
        public static float peopleAndBarbarianCombineTime = 5;
        public static float peopleAndPeopleCombineTime = 12;
        public static float peopleAndBrickCombineTime = 20;
        public static float peopleAndRockCombineTIme = 10;
        
    }
}