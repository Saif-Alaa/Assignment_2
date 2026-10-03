using assigment2.Data;
using assigment2.Dtos;
using assigment2.GenaricRepos;
using assigment2.Models;
using assigment2.Repos.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace assigment2.Repos
{
    public class BookRepo : GenriacRepo<Booking> , IBook
    {
        public BookRepo(AppDbContext appDb) : base(appDb)
        {
            
        }

        public List<Booking> details()
        {
            return appDbContext.Bookings.Include(b => b.Customer).Include(b => b.Movie).ThenInclude(m => m.Genre).ToList();
        }

        public List<RevenueDto> Revenue()
        {
            return appDbContext.Bookings
                .GroupBy(b => b.Movie)
                .Select(e => new RevenueDto
                {
                    Movie = e.Key.Title,
                    TotalTicketSold = e.Sum(b => b.NumberOfTickets),
                    TotalRevenue = e.Sum(b => b.Price)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToList();
        }

       
    }
}
