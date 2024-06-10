using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class OrderItemModel
    {
        private int id;
        private int order_id;
        private int product_id;
        private int size;

        [DisplayName("Order Item ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Order ID")]
        [Required(ErrorMessage = "Username is required")]
        public int OrderId
        {
            get { return order_id; }
            set { order_id = value; }
        }

        [DisplayName("Product ID")]
        [Required(ErrorMessage = "Username is required")]
        public int ProductId
        {
            get { return product_id; }
            set { product_id = value; }
        }

        [DisplayName("Size")]
        [Required(ErrorMessage = "Username is required")]
        public int Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
