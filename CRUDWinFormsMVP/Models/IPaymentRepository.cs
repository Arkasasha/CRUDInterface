using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IPaymentRepository
    {
        void Add(PaymentModel paymentModel);
        void Edit(PaymentModel paymentModel);
        void Delete(int id);
        IEnumerable<PaymentModel> GetAll();
        IEnumerable<PaymentModel> GetByValue(string value); //Searchs
    }
}
