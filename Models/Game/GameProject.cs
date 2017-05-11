namespace TextBasedGameMaker.Models.Game
{
    public class GameProject
    {
        public int GameProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartRoomId { get; set; }
    }
}