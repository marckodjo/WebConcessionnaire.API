using Microsoft.EntityFrameworkCore;
using WebConcessionnaire.API.Models;

namespace WebConcessionnaire.API.Data
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
       : base(options) { }

        public DbSet<Concessionnaire> Concessionnaires { get; set; }
    }
}
