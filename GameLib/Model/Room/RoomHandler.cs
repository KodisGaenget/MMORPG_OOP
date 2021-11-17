using System.Collections.Generic;

namespace GameLib
{
    public class RoomHandler
    {
        List<Room> allRooms = new();

        public RoomHandler()
        {
            CreateRooms();
        }

        public string ExamineRoom(int _roomID)
        {
            GetRoom(_roomID).RoomExamined = true;
            return GetRoom(_roomID).ExamineText;
        }

        public bool IsRoomExaminated(int _roomID)
        {
            return GetRoom(_roomID).RoomExamined;
        }

        public string GetRoomName(int _roomID)
        {
            return GetRoom(_roomID).Name;
        }

        public void AddRooms(List<Room> rooms)
        {
            allRooms.AddRange(rooms);
        }

        public string DescribeRoom(int _roomID)
        {
            return GetRoom(_roomID).Description;
        }

        public Room GetRoom(int _roomID)
        {
            foreach (var room in allRooms)
            {
                if (room.ID == _roomID)
                {
                    return room;
                }
            }
            return null;
        }

        private void CreateRooms()
        {
            allRooms.Add(new Room(1, "Foyer", "You open the door to the castle and enter the foyer. It's moist and water is leaking in from every where. You notice a rack with 3 knobs on it on which there is one jacket hanging. 'Nice jacket, very modern. It looks brand new, only used a few times. I'm starting to get the feeling that I'm not alone in here'.  ", "Room Examine string", 2, null, null, null));
            allRooms.Add(new Room(2, "Dank hallway", "Room description string", "Room Examine string", 5, 4, 1, 3));
            allRooms.Add(new Room(3, "Library", "Room description string", "Room Examine string", null, 2, null, null));
            allRooms.Add(new Room(4, "Dildo exhibition room", "Room description string", "Room Examine string", null, null, null, 2));
            allRooms.Add(new Room(5, "Living room", "Room description string", "Room Examine string", 6, null, 2, null));
            allRooms.Add(new Room(6, "Kitchen", "Room description string", "Room Examine string", 8, null, 5, 7));
            allRooms.Add(new Room(7, "Storage room", "Room description string", "Room Examine string", null, 6, null, null));
            allRooms.Add(new Room(8, "Stairway", "Room description string", "Room Examine string", 11, 9, 6, null));
            allRooms.Add(new Room(9, "Torture chamber", "Room description string", "Room Examine string", null, 10, null, 8));
            allRooms.Add(new Room(10, "Prison cells", "Room description string", "Room Examine string", null, null, null, 9));
            allRooms.Add(new Room(11, "Observatory", "Room description string", "Room Examine string", null, null, 8, null));
        }
    }
}
