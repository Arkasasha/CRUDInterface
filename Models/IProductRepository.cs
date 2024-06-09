using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public interface IProductRepository
    {
        void Add(ProductModel productModel);
        void Edit(ProductModel productModel);
        void Delete(int id);
        float GetGrade(int id);
        IEnumerable<ProductModel> GetAll();
        IEnumerable<ProductModel> GetByValue(string value); //Searchs
    }
}
