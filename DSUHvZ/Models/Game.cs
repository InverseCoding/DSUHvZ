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
        public int OwnerID { get; set; }
        public List<int> Players { get; set; }
        public List<int> Admins { get; set; }
    }
}