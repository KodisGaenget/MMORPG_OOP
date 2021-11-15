using System;

namespace GameInterfaces
{
    public interface IClass : IMainAbility, ISecondaryAbility, IBlockable
    {
        float HealthMultiplier { get; }
        string Name { get; }
    }
}
