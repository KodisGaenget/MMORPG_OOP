namespace Spells
{
    public abstract class Spell
    {
        internal int Id { get; init; }
        public string Name { get; init; }
        public int DrainPower { get; init; }
    }
}