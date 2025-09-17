
namespace Lab.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            // Gets Products from the database
            var Products = _dbContext.Products.ToList();

            return Products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(Product Product)
        {
            // Validates the Product
            if (Product == null)
            {
                throw new ArgumentNullException(nameof(Product), "Product is null.");
            }

            // Adds a new Product to the database
            _dbContext.Products.Add(Product);
            int result = _dbContext.SaveChanges();

            return result;
        }

        public void Update(int id, Product Product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
