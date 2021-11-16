using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExamineRoom { get; set; }

        public bool RoomExamined { get; set; }
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }
        public int? ItemInRoomID { get; set; }
        public int? EnemyInRoomID { get; set; }

        public Room(int _Id, string _name, string _description, string _examineRoom)
        {
            ID = _Id;
            Name = _name;
            Description = _description;
            ExamineRoom = _examineRoom;
            RoomExamined = false;
        }

    }


}