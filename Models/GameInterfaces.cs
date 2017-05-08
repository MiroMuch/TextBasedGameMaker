using System.Collections.Generic;
using TextBasedGameMaker.Models.Game;

namespace TextBasedGameMaker.Models
{
    public interface IDescription
    {
        string BriefDescription { get; }
        string FullDescription { get; }
    }
    
    public interface IItem
    {
        string Name { get; }
        void Take();
        void Dump();
        void Action();
    }

    public interface IRoom
    {
        void Leave(IEnumerable<Door> door);
    }
}