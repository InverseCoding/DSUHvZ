using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSUHvZ.Models
{
    public class Player
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        //Used to allow player to be selected as Original Zombie
        public bool SecretZombiePref { get; set; }

        //Used to designate player as being an Original Zombie
        public bool IsSecretZombie { get; set; }

        //Used to show if player is a human (1) or zombie (2)
        public int Side { get; set; }

        public bool IsAdmin { get; set; }
        public string TagCode { get; set; }
    }
}