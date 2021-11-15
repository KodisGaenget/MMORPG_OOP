using System;

namespace GameInterfaces
{
    public interface IClass : IMainAbility, ISecondaryAbility, IBlockable
    {
        int health { get; }
        string Name { get; }
    }
}
