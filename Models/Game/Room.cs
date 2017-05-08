using System;
using System.Collections.Generic;

namespace TextBasedGameMaker.Models.Game
{
    public class Room : IRoom, IDescription
    {
        public int RoomId { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }

        public void Leave(IEnumerable<Door> door)
        {
            throw new NotImplementedException(door.ToString());
        }
    }
}