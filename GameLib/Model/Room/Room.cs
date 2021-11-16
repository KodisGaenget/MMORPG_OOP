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

        public bool RoomExamined { get; set; }
        public int North { get; set; }
        public int East { get; set; }
        public int South { get; set; }
        public int West { get; set; }
        public int? ItemInRoomID { get; set; }

        public Room(int _Id, string _name, string _description, string _examineText)
        {
            ID = _Id;
            Name = _name;
            Description = _description;
            ExamineText = _examineText;
            RoomExamined = false;
        }

        public Room()
        {

        }

    }


}