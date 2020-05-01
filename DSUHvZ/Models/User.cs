using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSUHvZ.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Game ActiveGame { get; set; }
        public string Email { get; set; }

    }
}