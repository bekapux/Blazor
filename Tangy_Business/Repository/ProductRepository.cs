using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Create(ProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _context.Products.Add(_mapper.Map<Product>(product));
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product != null) _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductDto> Get(int? id)
        {
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var Products = await _context.Products.Include(x => x.Category).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(Products);
        }

        public async Task<int> Update(ProductDto product)
        {
            var productToUpdate = await _context.Products.FirstOrDefaultAsync(x=> x.Id == product.Id);
            if(productToUpdate != null)
            {
                productToUpdate.ShopFavourites = product.ShopFavourites;
                productToUpdate.CustomerFavourites = product.CustomerFavourites;
                productToUpdate.Description = product.Description;
                productToUpdate.Name = product.Name;
                productToUpdate.ImageUrl = product.ImageUrl;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.Color = product.Color;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
