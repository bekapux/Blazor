using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<CategoryDto> Create(CategoryDto newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            category.CreatedDate = DateTime.Now;
            await _context.Categories.AddAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<int> Delete(int id)
        {
            var CategoryToRemove = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (CategoryToRemove != null)
                _context.Categories.Remove(CategoryToRemove);
            return await _context.SaveChangesAsync();
        }

        public async Task<CategoryDto> Get(int id)
        {
            var category = _mapper.Map<CategoryDto>(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
            if (category != null)
                return category;

            return new CategoryDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _context.Categories.ToListAsync());
        }

        public async Task<CategoryDto> Update(CategoryDto UpdatedCategory)
        {
            var OldCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == UpdatedCategory.Id);
            if (OldCategory != null)
            {
                OldCategory.Name = UpdatedCategory.Name ?? OldCategory.Name;
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<CategoryDto>(OldCategory);
        }
    }
}
