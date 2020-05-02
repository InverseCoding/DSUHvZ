using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DSUHvZ.Models
{
    public class AppUser
    {
        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int ActiveGameID { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        public AppUser()
        {

        }
        public AppUser(AppUser other)
        {
            this.ID = other.ID;
            this.Name = other.Name;
            this.ActiveGameID = other.ActiveGameID;
            this.Email = other.Email;
        }

    }
}