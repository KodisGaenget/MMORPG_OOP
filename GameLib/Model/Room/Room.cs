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
        public int? North { get { return North.GetValueOrDefault(); } set { } }
        public int? East { get { return East.GetValueOrDefault(); } set { } }
        public int? South { get { return South.GetValueOrDefault(); } set { } }
        public int? West { get { return West.GetValueOrDefault(); } set { } }
        public int? ItemInRoomId { get { return ItemInRoomId.GetValueOrDefault(); } set { } }
        public int? ItemRequiredToEnter { get { return ItemRequiredToEnter.GetValueOrDefault(); } set { } }
        public int? EnemyInRoom { get { return EnemyInRoom.GetValueOrDefault(); } set { } }

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