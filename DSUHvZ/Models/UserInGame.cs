using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSUHvZ.Models
{
    public class UserInGame
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public int GameID { get; set; }

        //Used to allow player to be selected as Original Zombie
        [Display(Name = "Enter the OZ Pool")]
        public bool SecretZombiePref { get; set; }

        //Used to designate player as being an Original Zombie
        public bool IsSecretZombie { get; set; }

        //Used to show if player is a human (1) or zombie (2)
        public int Side { get; set; }

        public bool IsAdmin { get; set; }

        [Required]
        public string TagCode { get; set; }

        private string GenerateTagCode()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }

        public UserInGame()
        {
            TagCode = GenerateTagCode();
        }
    }
}