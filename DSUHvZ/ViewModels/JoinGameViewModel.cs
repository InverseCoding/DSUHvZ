using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSUHvZ.Models;
using Microsoft.AspNet.Identity;

namespace DSUHvZ.ViewModels
{
    public class JoinGameViewModel
    {
        public Game game { get; set; }

        public ApplicationUser user { get; set; }
    }
}