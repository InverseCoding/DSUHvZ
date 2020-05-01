using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSUHvZ.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }
        public List<Player> Players { get; set; }
        public List<Admin> Admins { get; set; }
    }
}