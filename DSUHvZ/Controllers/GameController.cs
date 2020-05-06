using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DSUHvZ.Models;
using DSUHvZ.ViewModels;

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
            var currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            var game = _context.Games.SingleOrDefault(g => g.ID == currentUser.ActiveGameID);

            if (game == null)
                return HttpNotFound();

            List<ApplicationUser> Players = (from _user in _context.Users
                                             where _user.ActiveGameID == game.ID
                                             select _user).ToList();
            game.Players = Players;


            return View(game);

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

        [Authorize]
        [HttpGet]
        public ActionResult Join(int? id)
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

            var currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = _context.Users.SingleOrDefault(u => u.Id == currentUserId);

            var joinGame = new JoinGameViewModel
            {
                game = game,
                user = currentUser
            };

            return View(joinGame);
        }
    }
}