using System;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TextBasedGameMaker.Data;
using TextBasedGameMaker.Models;
using TextBasedGameMaker.Models.Game;

namespace TextBasedGameMaker.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GameController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return View(rooms);
        }

        [Authorize]
        public async Task<IActionResult> Settings()
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var defaultGameId = await (
                    from au in _context.ApplicationUsers
                    where au.Id == currentUserId
                    select au.DefaultGameProjectId
                    ).SingleAsync();
            if(defaultGameId != 0)
            {
                var defaultGameProject = await (
                        from gp in _context.GameProjects
                        where gp.GameProjectId == defaultGameId
                        select gp
                        ).SingleAsync();

                return View(defaultGameProject);
            }

            return View();
        }

        public async Task<IActionResult> GameProjects()
        {
            var gp = await _context.GameProjects.ToListAsync();
            return View(gp);
        }

        public ActionResult Game()
        {
            var game = from x in _context.Rooms
                       where x.RoomId == 1
                       select x;
            return View(game);
        }
    }
}