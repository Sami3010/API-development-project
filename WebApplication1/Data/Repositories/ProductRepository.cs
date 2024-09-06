using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Data.Repositories
{
    public class ProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepository(DapperContext context)
        {
            _context = context;
        }

        // CREATE method
        public async Task<int> AddProduct(Product product)
        {
            var sql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { product.Name, product.Price });
            }
        }
        // READ method for all products
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var sql = "SELECT * FROM Products";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Product>(sql);
            }
        }
        // READ method single product
        public async Task<Product> GetProductById(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @ProductId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { ProductId = id });
            }
        }

        // UPDATE method
        public async Task<int> UpdateProduct(Product product)
        {
            var sql = "UPDATE Products SET Name = @Name, Price = @Price WHERE Id = @ProductId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { product.Name, product.Price, product.Id });
            }
        }

        // DELETE method
        public async Task<int> DeleteProduct(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @ProductId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
