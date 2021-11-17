using System.Collections.Generic;

namespace Characters
{
    public class Level
    {
        private const int maxLvl = 20;
        public Dictionary<int, int> ExpToLevel = new()
        {

        };

        public Level()
        {
            for (int i = 2; i < maxLvl + 1; i++)
            {
                if (i <= 11)
                {
                    ExpToLevel.TryAdd(i, 10 * (i * i) - (5 * i) + 8);

                }
                else if (i >= 12)
                {
                    ExpToLevel.TryAdd(i, (int)(65 * (i * i) - 165 * (i) - 6750 * 0.82F));
                }
            }
        }
        public int GetLevel(int exp)
        {
            KeyValuePair<int, int> lastlvl = new(1, 0);
            int currentLevel = 1;
            foreach (var level in ExpToLevel)
            {
                if (lastlvl.Value <= exp)
                {
                    currentLevel = lastlvl.Key;
                }
                else if (level.Value < exp)
                {
                    lastlvl = level;
                }
                else if (level.Value <= exp && level.Key == maxLvl)
                {
                    currentLevel = level.Key;
                }

                lastlvl = level;
            }
            return currentLevel;
        }

        public float ExpToNextLevel(int currentExp, int level)
        {
            int expToLevelUp = 0;

            if (level <= 11)
            {
                expToLevelUp = (10 * (level * level) - (5 * level) + 8) - currentExp;

            }
            else if (level >= 12)
            {
                expToLevelUp = (int)((65 * (level + 1 * level + 1) - 165 * (level + 1) - 6750) * 0.82F) - currentExp;
            }
            return expToLevelUp;
        }
    }


}