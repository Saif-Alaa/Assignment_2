using assigment2.Data;
using assigment2.GenaricRepos;
using assigment2.Models;
using assigment2.Repos.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace assigment2.Repos
{
    public class CustomerRepo : GenriacRepo<Customer>, ICustomer
    {

        public CustomerRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public List<Customer> GetCustomersByBooing()
        {
            return appDbContext.Customers.Include(e => e.Bookings).ThenInclude(b => b.Movie).ToList();   
        }

        public List<Customer> GetCustomersNeverBook()
        {
            return appDbContext.Customers.Where(b => b.Bookings.Count == 0).ToList();
        }

        public List<Customer> GetVipCustomers()
        {
            return appDbContext.Customers.OrderByDescending(b => b.Bookings.Sum(e => e.Price)).ToList();
        }
    }
}
