using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IAddressRepository
    {
        void Add(AddressModel addressModel);
        void Edit(AddressModel addressModel);
        void Delete(int id);
        IEnumerable<AddressModel> GetAll();
        IEnumerable<AddressModel> GetByValue(string value); //Searchs
    }
}
