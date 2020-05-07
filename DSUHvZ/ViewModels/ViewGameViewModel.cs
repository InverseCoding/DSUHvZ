using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSUHvZ.Models;

namespace DSUHvZ.ViewModels
{
    public class ViewGameViewModel
    {
        public Player CurrentPlayer { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public Game SelectedGame { get; set; }

    }
}