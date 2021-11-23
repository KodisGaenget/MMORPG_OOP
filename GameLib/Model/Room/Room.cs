using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExamineText { get; set; }
        public Dictionary<Direction, int> Directions { get; set; }
        public List<int> ItemInRoomId { get; set; }
        public int ItemRequiredToEnter { get; set; }
        public int EnemyInRoom { get; set; }

        public Room(int _Id, string _name, string _description, string _examineText, int _north, int _east, int _south, int _west)
        {
            ID = _Id;
            Name = _name;
            Description = _description;
            ExamineText = _examineText;
            Directions = new();
            Directions.Add(Direction.North, _north);
            Directions.Add(Direction.East, _east);
            Directions.Add(Direction.South, _south);
            Directions.Add(Direction.West, _west);
            ItemRequiredToEnter = 0;
            EnemyInRoom = 0;
            ItemInRoomId = new();
        }
    }

    // move enum? where?
    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}