using Mysqlx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Models
{
    public class PaymentModel
    {
        private int id;
        private int order_id;
        private int user_id;
        private int user_payment_id;
        private int price;
        private DateTime time;

        [DisplayName("Payment ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Order ID")]
        [Required(ErrorMessage = "Order ID is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int OrderId
        {
            get { return order_id; }
            set { order_id = value; }
        }

        [DisplayName("User ID")]
        [Required(ErrorMessage = "User ID is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int UserId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        [DisplayName("User Payment ID")]
        [Required(ErrorMessage = "User Payment ID is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int UserPaymentId
        {
            get { return user_payment_id; }
            set { user_payment_id = value; }
        }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [DisplayName("Time")]
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
