using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<int> Create(ProductDto product);
        public Task<int> Update(ProductDto product);

        public Task<int> Delete(int id);
        public Task<IEnumerable<ProductDto>> GetAll();
        public Task<ProductDto> Get(int? id);
    }
}
