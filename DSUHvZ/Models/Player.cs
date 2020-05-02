using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSUHvZ.Models
{
    [NotMapped] public class Player : AppUser
    {
        public Player(AppUser user) : base(user)
        {

        }
    }
}