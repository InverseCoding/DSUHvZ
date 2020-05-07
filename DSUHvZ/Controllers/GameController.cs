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

            var currentUserID = User.Identity.GetUserId();
            var currentUserInGame = _context.UsersInGames.SingleOrDefault(u => u.UserID == currentUserID);


            if (currentUserInGame == null)
                return RedirectToAction("Index", "Game");

            var selectedGame = _context.Games.SingleOrDefault(g => g.ID == currentUserInGame.GameID);

            if (selectedGame == null)
                return HttpNotFound();

            //Find all players that have this game set as their active game
            var ListOfPlayers = (from p in _context.UsersInGames
                                 where p.GameID == currentUserInGame.GameID
                                 select p).ToList();
            List<Player> players = new List<Player>();

            //Generate Player objects for easy representation of players
            foreach(UserInGame user in ListOfPlayers)
            {
                Player tempPlayer = new Player
                {
                    UserID = user.UserID,
                    EntryID = user.ID,
                    UserName = _context.Users.SingleOrDefault(u => u.Id == user.UserID).UserName,
                    SecretZombiePref = user.SecretZombiePref,
                    IsSecretZombie = user.IsSecretZombie,
                    Side = user.Side,
                    IsAdmin = user.IsAdmin,
                    TagCode = user.TagCode
                };
                players.Add(tempPlayer);
            }

            Player currentPlayer;
            string currentUserId = User.Identity.GetUserId();
            Player selectedPlayer = players.SingleOrDefault(p => p.UserID == currentUserId);

            if (selectedPlayer != null)
            {
                currentPlayer = selectedPlayer;
            }
            else
            {
                currentPlayer = new Player
                {
                    UserID = currentUserId,
                    EntryID = 0,
                    UserName = _context.Users.SingleOrDefault(p => p.Id == currentUserId).UserName,
                    SecretZombiePref = false,
                    IsSecretZombie = false,
                    Side = 0,
                    IsAdmin = false,
                    TagCode = ""
                };
            }

            var viewGameViewModel = new ViewGameViewModel
            {
                Players = players,
                SelectedGame = selectedGame,
                CurrentPlayer = currentPlayer
            };

            return View(viewGameViewModel);

        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            //TODO: Replace code with actions relevant to allowing a user to edit their owned games by ID
            return Content("id=" + id);
        }

        [Authorize]
        public ActionResult ChangeSide(int id)
        {
            var selectedUser = _context.UsersInGames.SingleOrDefault(u => u.ID == id);

            if (selectedUser == null)
            {
                return HttpNotFound();
            }

            return View(selectedUser);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangeSideAction(UserInGame user)
        {

            var userInDb = _context.UsersInGames.SingleOrDefault(u => u.ID == user.ID);

            if (userInDb == null)
                return HttpNotFound();
            else
                userInDb.Side = user.Side;

            _context.SaveChanges();

            return RedirectToAction("ActiveGame", "Game");
        }

        [Authorize]
        public ActionResult ClaimTag()
        {
            var tempUser = new UserInGame();
            tempUser.Side = 2;
            tempUser.TagCode = "";

            return View(tempUser);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ClaimTagAction(UserInGame user)
        {
            var userInDb = _context.UsersInGames.SingleOrDefault(u => u.TagCode == user.TagCode);

            if (userInDb == null)
                return HttpNotFound();
            else
                userInDb.Side = user.Side;

            _context.SaveChanges();

            return RedirectToAction("ActiveGame", "Game");
        }

        [Authorize]
        public ActionResult View(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Game");

            var selectedGame = _context.Games.SingleOrDefault(g => g.ID == id);

            if (selectedGame == null)
                return HttpNotFound();

            //Find all players that have this game set as their active game
            var ListOfPlayers = (from p in _context.UsersInGames
                                 where p.GameID == id
                                 select p).ToList();

            List<Player> players = new List<Player>();

            //Generate Player objects for easy representation of players
            foreach(UserInGame user in ListOfPlayers)
            {
                Player tempPlayer = new Player
                {
                    UserID = user.UserID,
                    EntryID = user.ID,
                    UserName = _context.Users.SingleOrDefault(u => u.Id == user.UserID).UserName,
                    SecretZombiePref = user.SecretZombiePref,
                    IsSecretZombie = user.IsSecretZombie,
                    Side = user.Side,
                    IsAdmin = user.IsAdmin,
                    TagCode = user.TagCode
                };
                players.Add(tempPlayer);
            }

            Player currentPlayer;
            string currentUserId = User.Identity.GetUserId();
            Player selectedPlayer = players.SingleOrDefault(p => p.UserID == currentUserId);

            if(selectedPlayer!=null)
            {
                currentPlayer = selectedPlayer;
            } else
            {
                currentPlayer = new Player
                {
                    UserID = currentUserId,
                    EntryID = 0,
                    UserName = _context.Users.SingleOrDefault(p => p.Id == currentUserId).UserName,
                    SecretZombiePref = false,
                    IsSecretZombie = false,
                    Side = 0,
                    IsAdmin = false,
                    TagCode = ""
                };
            }

            var viewGameViewModel = new ViewGameViewModel
            {
                Players = players,
                SelectedGame = selectedGame,
                CurrentPlayer = currentPlayer
            };

            return View(viewGameViewModel);
        }

        [Authorize]
        public ActionResult Join(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Game");

            var selectedGame = _context.Games.SingleOrDefault(g => g.ID == id);

            if (selectedGame == null)
                return HttpNotFound();

            var tempUserInGame = new UserInGame
            {
                UserID = User.Identity.GetUserId(),
                GameID = (int)id,
                SecretZombiePref = false,
                IsSecretZombie = false,
                Side = 1,
                IsAdmin = false
            };

            return View(tempUserInGame);
        }

        [Authorize]
        [HttpPost]
        public ActionResult JoinAction(UserInGame otherUser)
        {
            var tempUserInGame = new UserInGame
            {
                UserID = otherUser.UserID,
                GameID = otherUser.GameID,
                SecretZombiePref = otherUser.SecretZombiePref,
                IsSecretZombie = false,
                Side = 1,
                IsAdmin = false
            };

            UserInGame potentialOtherInstance = _context.UsersInGames.SingleOrDefault(u => u.UserID == tempUserInGame.UserID);

            if (potentialOtherInstance != null)
            {
                _context.UsersInGames.Remove(potentialOtherInstance);
                _context.SaveChanges();
            }
            _context.UsersInGames.Add(tempUserInGame);
            _context.SaveChanges();

            return RedirectToAction("ActiveGame", "Game");
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


            var tempUserInGame = new UserInGame
            {
                UserID = game.OwnerID,
                GameID = game.ID,
                SecretZombiePref = false,
                IsSecretZombie = false,
                Side = 1,
                IsAdmin = true
            };

            UserInGame potentialOtherInstance = _context.UsersInGames.SingleOrDefault(u => u.UserID == tempUserInGame.UserID);

            if (potentialOtherInstance != null)
            {
                _context.UsersInGames.Remove(potentialOtherInstance);
                _context.SaveChanges();
            }

            _context.UsersInGames.Add(tempUserInGame);
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