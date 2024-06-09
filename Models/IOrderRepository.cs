using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IOrderRepository
    {
        void Add(OrderModel orderModel);
        void Edit(OrderModel orderModel);
        void Delete(int id);
        IEnumerable<OrderModel> GetAll();
        IEnumerable<OrderModel> GetByValue(string value); //Searchs
    }
}
