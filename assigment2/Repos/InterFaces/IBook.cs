using assigment2.Dtos;
using assigment2.GenaricRepos;
using assigment2.Models;

namespace assigment2.Repos.InterFaces
{
    public interface IBook : IGenriacRepo<Booking> 
    {
        List<RevenueDto> Revenue();
        List<Booking> details();
    }
}
