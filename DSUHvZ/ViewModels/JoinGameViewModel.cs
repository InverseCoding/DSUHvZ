﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSUHvZ.Models;
using Microsoft.AspNet.Identity;

namespace DSUHvZ.ViewModels
{
    public class JoinGameViewModel
    {
        public Game Game { get; set; }

        public UserInGame User { get; set; }
    }
}