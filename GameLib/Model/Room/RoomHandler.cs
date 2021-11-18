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
            allRooms.Add(new Room(1, "Foyer", "You open the door to the castle and enter the foyer. It's moist and water is leaking in from every where. You notice a rack with 3 knobs on it on which there is one jacket hanging. 'Nice jacket, very modern. It looks brand new, only used a few times. I'm starting to get the feeling that I'm not alone in here'. {There is only one door right in front of you}.", "You came up short, there is nothing of value in this room.", 2, null, null, null));
            allRooms.Add(new Room(2, "Dank hallway", "As you open the door, you arrive at a dank hallway. You hear a strange sound emanating from the walls, but there is no way to hear where the sound is coming from. A thought hits you as you take a glance around the room: 'I'm starting to suspect that that I'm not alone in this old castle even more than before the previous room'. {There is one door to your left, one door to your right and one door straight ahead}.", "There's two vials on the sideboard in the hallway. You pick them up and gain {2 small health potions}", 5, 4, 1, 3));
            allRooms.Add(new Room(3, "Library", "You open the door to the library and step in. As you enter the door SLAMS SHUT HARD AS GODAMN HELL BEHIND YOU AND A BOOK COMES FLYING TOWARDS YOU. You manage to dodge the first two books as you think: 'What the shit is going on in here?!' but there are too many books coming at you too fast. The third book hits you in the head knocking you on your ass. As you're starting to get back up on your feet you notice a rancid odor so bad that you can taste it in your mouth. You've encountered a toxic fart cloud {Insert toxic fart cloud}. {There is no additional door}.", "You notice a weak, glowing light from one of the books in the book shelf, you open it and feel a small rush of power run through you. You {gained 200 XP}.", null, 2, null, null));
            allRooms.Add(new Room(4, "Dildo exhibition room", "'Hmm, this door opened smooth, a bit too smooth. Suspiciously smooth even. Almost as if it's been lubricated'. The first thing you notice is the big neon sign reading 'DILDOS' in glowing purple letters and an arrow pointing you to around the corner at the end of the room. Suddenly, a slap echoes throughout the room. You slowly walk toward the end of the room and take a peek around the corner. You see two small Goblins with red cheeks slapping each other with the various different sizes of dildos surrounding the entire room on shelve after shelve after shelve of dildos. You notice a shrine in the middle of the room with a huge double ended dildo of pure gold and small candles lit around it: 'This must be a temple to worship some sort of dildo god'. {Insert 2 Goblins}. {There is no additional door}.", "As you examine the room you notice a chest on the floor labeled 'weapons'. It's unlocked, lucky you. You dig around and find a {Sharpened dildo}", null, null, null, 2));
            allRooms.Add(new Room(5, "Living room", "You enter a regular living room with a couch next to a fireplace, a shelve with books and really expensive-looking curtains covering a window. 'THUD, THUD, THUD, THUD'. You hear four thuds and then some sort of deep rolling sound, like four huge wheels of cheese rolling on hardwood from the room right in front of you. Unlucky for you, that's the only way forward since that is {the only door in this room}. ", "There's a wepon mounted above the fire place. You gain a {Double edged axe}.", 6, null, 2, null));
            allRooms.Add(new Room(6, "Kitchen", "You open the door to the kitchen and notice three giant rats trying to haul away large wheels of cheese. The bad part is that they noticed you as well and have now dropped their cheese to charge towards you {Insert 3 giant rats}. {There is one door to your left and one door straight ahead}. ", "In one of the cupboard you notice a glass flask, you pick it up and gain {1 medium health potion}", 8, null, 5, 7));
            allRooms.Add(new Room(7, "Storage room", "'Not much to see in here, mostly dusty cleaning equipment and a lot of spider webs. Why are there so many spider webs? They look fresh, like they were made just moments ago. And why are they so thick, they're thick like a bowl of oatmeal and why is there so much of it godamn it's like that first cave in Skyrim but even worse, like a spider on roids mixed up with cocain. I can't even move anymore I get tangled up it's TO THICK'. You get stuck in the spider web and all your flailing made it worse until you can't move at all. As you accept your fate of starvation you feel the web starting to tremble along with very uncomfartable clacking sounds. There's a giant spider heading your way from up the ceiling and you realize that this is it. But as you pee your pants it loosens up the web, making you able to move your lower body. With an acrobatic jerk of your hip you mange to reach your small dagger from your belt and you cut loose the spider web. You're free but you have no time to plan a move, the spider is rushing at you with full speed {insert giant spider}. {There is no additional door in this room.}", "As you search the room you trip and fall down. From the floor you notice that there are weapons under a shelf and one large glass flask. You gain {Daggers} and {one large health potion}", null, 6, null, null));
            allRooms.Add(new Room(8, "Stairway", "'Not much to see in here, only a stairway up to the second floor'.{One door to the right}", "Room Examine string", 11, 9, 6, null));
            allRooms.Add(new Room(9, "Torture chamber", "'Lots of leather and latex in here. Whips, wooden paddles, ropes. I wouldn't wanna be the guy being tortured in here that's for sure'. There is one door right in front of you. When you get closer you hear muffled screams for help coming from the other side.", "You find a Kama sutra on a table next to the limb stretcher device, you read it through and {gain 500xp}", null, 10, null, 8));
            allRooms.Add(new Room(10, "Prison cells", "When you open the door to the prison cell, the scream for help gets clearer. As you rush to the prison cell you see a beautiful woman behind bars. You take a look around to see if there are any keys to unlock the prison cells. There's a table in the far side of the room you notice a keychain with keys. You grab it and run back to the cell to unlock it, imagining how when you save the beautiful woman she will give you a kiss. Maybe you'll get a house on the country side where you can farm your own vegetables, breed a couple of kids and get a dog. As the cell is unlocked she stands up and gives you a punch straight in the face. 'Ah shit, it's a godamn shapeshifter' you think as the creature takes the form of a handsome middle aged man. {Insert shapeshifter} ", "There is a mannequin with a full set of armour on it. You go to examine it and gain {one helmet, one chest armor, gloves, leg armor and boots}", null, null, null, 9));
            allRooms.Add(new Room(11, "Observatory", "You arrive at the top of the stairs, there is a door in front of you. You open the door and notice a desk and a chair, with its back turned towards you, in the middle of the room. As you enter, the door slams shut and the chair start spinning around: 'Well well well, if it isn't the hero of the story. You've come far, but this is where your journey and your life ends', The man in the chair cackles maniacally. 'Gustavo, you lunatic. Your reign of terror has been running rampant for too long. Prepear to meet your doom', you shout as you run towards him with your weapon held high, ready to kick some ass. {Insert Gustavo boss}  ", "Room Examine string", null, null, 8, null));
            AddItemToRoom();
        }

        private void AddItemToRoom()
        {
            allRooms[8].ItemInRoomID = 31;
        }
    }
}
