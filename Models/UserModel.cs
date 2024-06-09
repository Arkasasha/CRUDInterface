using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWinFormsMVP.Models
{
    public class UserModel
    {
        private int id;
        private string username;
        private string name;
        private string surname;
        private string email;
        private string password;

        [DisplayName("User ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(16, MinimumLength = 1, ErrorMessage = "Username length must be between 1 and 16 characters")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name length must be between 1 and 25 characters")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Surname is required")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Surname length must be between 1 and 25 characters")]
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Password length must be between 1 and 60 characters")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
