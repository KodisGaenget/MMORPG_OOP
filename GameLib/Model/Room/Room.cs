using System;
using System.Collections.Generic;

namespace GameLib
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomDescription { get; set; }
        public List<int> ConnectingRooms { get; set; }
        public string ExamineRoomText { get; set; }
        public bool RoomExamined { get; set; }

        public Room(int _roomID, string _roomName, string _roomDescription, string _examineRoomText, List<int> _connectingRoomsID)
        {
            this.RoomID = _roomID;
            this.RoomName = _roomName;
            this.RoomDescription = _roomDescription;
            this.ConnectingRooms = _connectingRoomsID;
            this.ExamineRoomText = _examineRoomText;
            RoomExamined = false;
        }

    }


}