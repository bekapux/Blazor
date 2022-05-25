using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<CategoryDto> Create(CategoryDto category);
        public Task<CategoryDto> Update(CategoryDto category);

        public Task<int >Delete(int id);
        public Task<IEnumerable<CategoryDto>> GetAll();
        public Task<CategoryDto> Get(int id);
    }
}
