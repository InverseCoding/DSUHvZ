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
        [StringLength(128)]
        public string AccountID { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int? ActiveGameID { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        public AppUser()
        {

        }

        public AppUser(ApplicationUser other)
        {
            this.AccountID = other.Id;
            this.Name = other.UserName;
            this.ActiveGameID = 0;
            this.Email = other.Email;
        }
        public AppUser(AppUser other)
        {
            this.ID = other.ID;
            this.AccountID = other.AccountID;
            this.Name = other.Name;
            this.ActiveGameID = other.ActiveGameID;
            this.Email = other.Email;
        }

    }
}