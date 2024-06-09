using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class UserPaymentModel
    {
        private int id;
        private int user_id;
        private string payment_type;
        private string account_number;
        private string expire_date;

        [DisplayName("Payment Method ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("User ID")]
        [Required(ErrorMessage = "User ID is required")]
        public int UserId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        [DisplayName("Payment Type")]
        [Required(ErrorMessage = "Payment Type is required")]
        public string PaymentType
        {
            get { return payment_type; }
            set { payment_type = value; }
        }

        [DisplayName("Account Number")]
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountNumber
        {
            get { return account_number; }
            set { account_number = value; }
        }

        [DisplayName("Expire Date")]
        public string ExpireDate
        {
            get { return expire_date; }
            set { expire_date = value; }
        }
    }
}
