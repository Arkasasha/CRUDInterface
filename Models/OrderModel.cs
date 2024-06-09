using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWinFormsMVP.Models
{
    public class OrderModel
    {
        private int id;
        private int user_id;
        private int address_id;
        private int delivery_id;
        private DateTime time;
        private string status;

        [DisplayName("Order ID")]
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

        [DisplayName("Address ID")]
        [Required(ErrorMessage = "Username is required")]
        public int AddressId
        {
            get { return address_id; }
            set { address_id = value; }
        }

        [DisplayName("Delivery ID")]
        [Required(ErrorMessage = "Username is required")]
        public int DeliveryId
        {
            get { return delivery_id; }
            set { delivery_id = value; }
        }

        [DisplayName("Time")]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        [DisplayName("Status")]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
