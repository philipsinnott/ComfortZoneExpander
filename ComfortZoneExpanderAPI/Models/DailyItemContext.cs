using Microsoft.EntityFrameworkCore;

namespace ComfortZoneExpanderAPI.Models
{
    public class DailyItemContext : DbContext
    {
        public DailyItemContext(DbContextOptions<DailyItemContext> options)
            : base(options)
        {

        }
        public DbSet<DailyItem> DailyItems { get; set; }
    }
}
