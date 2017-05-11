using TextBasedGameMaker.Models.Game;
using System;
using System.Linq;

namespace TextBasedGameMaker.Data
{
    //Add to Startup.cs --> Configure(ApplicationDbContext context) --> {DbInitializer.Initialize(context)}
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Rooms.Any())
            {
                return;   // DB has been seeded
            }

            var rooms = new Room[]
            {
                new Room{BriefDescription="Some 1 brief description", FullDescription="Some 1 even full description"},
                new Room{BriefDescription="Some 2 brief description", FullDescription="Some 2 even full description"},
                new Room{BriefDescription="Some 3 brief description", FullDescription="Some 3 even full description"},
                new Room{BriefDescription="Some 4 brief description", FullDescription="Some 4 even full description"},
                new Room{BriefDescription="Some 5 brief description", FullDescription="Some 5 even full description"},
                new Room{BriefDescription="Some 6 brief description", FullDescription="Some 6 even full description"},
                new Room{BriefDescription="Some 7 brief description", FullDescription="Some 7 even full description"},
                new Room{BriefDescription="Some 8 brief description", FullDescription="Some 8 even full description"}
            };
            foreach (Room r in rooms)
            {
                context.Rooms.Add(r);
            }
            context.SaveChanges();

            var gameProjects = new GameProject[]
            {
                new GameProject{ Name="Project name", Description="Some project description", StartRoomId=1 }
            };
            foreach (GameProject gp in gameProjects)
            {
                context.GameProjects.Add(gp);
            }
            context.SaveChanges();
        }
    }
}