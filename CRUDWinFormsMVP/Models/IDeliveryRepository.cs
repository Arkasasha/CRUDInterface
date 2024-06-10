using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IDeliveryRepository
    {
        void Add(DeliveryModel deliveryModel);
        void Edit(DeliveryModel deliveryModel);
        void Delete(int id);
        IEnumerable<DeliveryModel> GetAll();
        IEnumerable<DeliveryModel> GetByValue(string value); //Searchs
    }
}
