using System;
using System.Collections.Generic;
using GameInterfaces;

namespace PlayerClasses
{
    public class Mage : PlayerClass, IClass
    {
        public int health => 100;
        public string Name => "Mage";

        // private List<Spell> learnedSpells = new();

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
