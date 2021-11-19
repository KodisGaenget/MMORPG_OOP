using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Room
    {
        // kommentar
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExamineText { get; set; }

        public bool RoomExamined { get; set; }
        public int? North { get { return North.GetValueOrDefault(); } set { North = value; } }
        public int? East { get { return East.GetValueOrDefault(); } set { East = value; } }
        public int? South { get { return South.GetValueOrDefault(); } set { South = value; } }
        public int? West { get { return West.GetValueOrDefault(); } set { West = value; } }
        public int? ItemInRoomId { get { return ItemInRoomId.GetValueOrDefault(); } set { ItemInRoomId = value; } }
        public int? ItemRequiredToEnter { get { return ItemRequiredToEnter.GetValueOrDefault(); } set { ItemRequiredToEnter = value; } }
        public int? EnemyInRoom { get { return EnemyInRoom.GetValueOrDefault(); } set { EnemyInRoom = value; } }

        public Room(int _Id, string _name, string _description, string _examineText, int? _north, int? _east, int? _south, int? _west)
        {
            ID = _Id;
            Name = _name;
            Description = _description;
            ExamineText = _examineText;
            North = _north;
            East = _east;
            South = _south;
            West = _west;
            RoomExamined = false;
        }
    }
}