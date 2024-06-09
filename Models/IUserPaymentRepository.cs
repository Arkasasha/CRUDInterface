using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IUserPaymentRepository
    {
        void Add(UserPaymentModel userpaymentModel);
        void Edit(UserPaymentModel userpaymentModel);
        void Delete(int id);
        IEnumerable<UserPaymentModel> GetAll();
        IEnumerable<UserPaymentModel> GetByValue(string value); //Searchs
    }
}
