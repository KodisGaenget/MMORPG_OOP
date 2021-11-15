using System;
using System.Collections.Generic;
using GameInterfaces;
using Spells;

namespace PlayerClasses
{
    public class Mage : PlayerClass, IClass
    {
        public float HealthMultiplier => 1.06F;
        public string Name => "Mage";
        private List<Spell> learnedSpells = new();
        public Spell ChoosenMain { get; private set; }
        public Spell ChoosenSecond { get; private set; }


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
