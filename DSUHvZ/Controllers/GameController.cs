using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DSUHvZ.Models;
using DSUHvZ.ViewModels;

namespace DSUHvZ.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _contextGames;
        private ApplicationDbContext _contextUsers;

        public GameController()
        {
            _contextGames = new ApplicationDbContext();
            _contextUsers = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contextGames.Dispose();
        }
        // GET: GameInstance
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

            var game = _contextGames.Games.SingleOrDefault(g => g.ID == id);

            if (game == null)
                return HttpNotFound();

            List<AppUser> Players = (from user in _contextUsers.AppUsers
                                     where user.ActiveGameID == game.ID
                                     select user).ToList();
            game.Players = Players.ConvertAll(p => new Player(p));


            return View(game);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Game game)
        {
            //TEMPORARY
            game.OwnerID = 0;

            _contextGames.Games.Add(game);
            _contextGames.SaveChanges();

            return RedirectToAction("Index", "Game");
        }

        public ActionResult Index()
        {
            var games = _contextGames.Games.ToList();

            return View(games);
        }
    }
}