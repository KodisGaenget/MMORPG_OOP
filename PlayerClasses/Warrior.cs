using System;
using GameInterfaces;

namespace GameLib
{
    public class Warrior : IClass
    {
        public float HealthMultiplier => 1.3F;

        public string Name => throw new NotImplementedException();

        public int Block(int i)
        {
            throw new NotImplementedException();
        }

        public int MainAbility()
        {
            throw new NotImplementedException();
        }

        public int SecondaryAbility()
        {
            throw new NotImplementedException();
        }
    }
}
