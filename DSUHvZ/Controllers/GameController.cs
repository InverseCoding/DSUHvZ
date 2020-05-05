using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DSUHvZ.Models;

namespace DSUHvZ.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: GameInstance
        [Authorize]
        public ActionResult ActiveGame()
        {
            //TODO: Replace code with quereies that get the logged in user's current game
            /*var gameInstance = new Game() { Name = "Test Game Title" };
            gameInstance.Players = new List<Player>
            {
                new Player {Name = "Test Player 1"},
                new Player {Name = "Test Player 2"}
            };*/

            return View();
        }


        public ActionResult Edit(int id)
        {
            //TODO: Replace code with actions relevant to allowing a user to edit their owned games by ID
            return Content("id=" + id);
        }

        public ActionResult View(int? id)
        {
            if (!id.HasValue)
            {
                id = 0;
                return RedirectToAction("Index");
            }

            var game = _context.Games.SingleOrDefault(g => g.ID == id);

            if (game == null)
                return HttpNotFound();

            List<ApplicationUser> Players = (from user in _context.Users
                                             where user.ActiveGameID == id
                                             select user).ToList();
            game.Players = Players;


            return View(game);
        }

        [Authorize]
        public ActionResult New()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Game game)
        {
            //TEMPORARY
            game.OwnerID = User.Identity.GetUserId();

            _context.Games.Add(game);
            _context.SaveChanges();

            return RedirectToAction("Index", "Game");
        }

        public ActionResult Index()
        {
            var games = _context.Games.ToList();

            return View(games);
        }
    }
}