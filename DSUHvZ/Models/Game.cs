using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSUHvZ.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [StringLength(8192)]
        public string Rules { get; set; }

        [Required]
        public int OwnerID { get; set; }

        
        public List<Player> Players { get; set; }
    }
}