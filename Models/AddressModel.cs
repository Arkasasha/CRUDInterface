using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class AddressModel
    {
        private int id;
        private int user_id;
        private string city;
        private string street;
        private string postal_code;

        [DisplayName("Address ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("User ID")]
        [Required(ErrorMessage = "Username is required")]
        public int UserId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        [DisplayName("City")]
        [Required(ErrorMessage = "Username is required")]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DisplayName("Street")]
        [Required(ErrorMessage = "Username is required")]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Username is required")]
        public string PostalCode
        {
            get { return postal_code; }
            set { postal_code = value; }
        }
    }
}
