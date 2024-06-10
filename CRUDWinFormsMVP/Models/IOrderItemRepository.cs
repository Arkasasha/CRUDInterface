using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IOrderItemRepository
    {
        void Add(OrderItemModel orderItemModel);
        void Edit(OrderItemModel orderItemModel);
        void Delete(int id);
        IEnumerable<OrderItemModel> GetAll();
        IEnumerable<OrderItemModel> GetByValue(string value); //Searchs
    }
}
