
namespace Lab.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            // Gets customers from the database
            var customers = _dbContext.Customers.ToList();

            return customers;
        }

        public Customer GetById(int id)
        {
            var result = _dbContext.Customers.Find(id);

            if (result == null)
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }

            return result;
        }

        public int Add(Customer customer)
        {
            // Validates the order
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer is null.");
            }

            // Adds a new customer to the database
            _dbContext.Customers.Add(customer);
            int result = _dbContext.SaveChanges();

            return result;
        }

        public void Update(int id, Customer order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
