namespace GameInterfaces
{

    public interface IFightable
    {
        public string Name { get; }
        public int OriginalHealth { get; }
        public int CurrentHealth { get; set; }
        public int Power { get; }
        public int Armor { get; }
        public int Damage { get; }
        public int Level { get; }
        public int Position { get; set; }

        int Attack();
        int Block();
        bool ChangeHealth(int value);
    }


}