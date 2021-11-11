using System;

namespace GameLib
{
    public interface IClass : IMainAbility, ISecondaryAbility, IBlockable
    {
        int health { get; }
        string Name { get; }
    }
}
