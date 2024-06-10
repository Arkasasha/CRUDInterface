using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class DeliveryModel
    {
        private int id;
        private string name;

        [DisplayName("Delivery ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Delivery Type")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
