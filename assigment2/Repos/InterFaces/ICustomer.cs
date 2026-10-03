using assigment2.GenaricRepos;
using assigment2.Models;


namespace assigment2.Repos.InterFaces
{
    public interface ICustomer : IGenriacRepo<Customer>
    {
        List<Customer> GetCustomersByBooing();
        List<Customer> GetVipCustomers();
        List<Customer> GetCustomersNeverBook();
    }
}
