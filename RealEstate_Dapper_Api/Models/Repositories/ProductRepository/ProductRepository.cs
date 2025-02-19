using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Models.Dtos.ProductDtos
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connectioon = _context.CreateConnection())
            {
                var values = await connectioon.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = @"
                            SELECT 
                                p.ProductID, 
                                p.Title, 
                                p.Price, 
                                p.City, 
                                p.District, 
                                c.CategoryName
                            FROM Product p
                            INNER JOIN Category c ON p.ProductCategory = c.CategoryID";
            ;
            using (var connectioon = _context.CreateConnection())
            {
                var values = await connectioon.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
    }
}
