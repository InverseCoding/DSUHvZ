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
            //TODO: Replace declarations with queries to get game by ID
            if (!id.HasValue)
            {
                id = 0;
                return RedirectToAction("Index");
            }
            /*var gameInstance = new Game() { Name = "Test Game Title", ID = (int)id};
            gameInstance.Players = new List<Player>
            {
                new Player {Name = "Test Player 1"},
                new Player {Name = "Test Player 2"}
            };*/

            return View();
        }

        public ActionResult Index()
        {
            var allGames = new List<Game>
            {
                //TODO: Replace setting here with database calls to retreive active game instances
                new Game {Name = "Game 1", ID = 1},
                new Game {Name = "Game 2", ID = 2}
            };

            var viewModel = new GamesViewModel
            {
                GamesList = allGames
            };

            return View(viewModel);
        }
    }
}