using Microsoft.EntityFrameworkCore;
using Ktrgk2.Models;
using System.Collections.Generic;

namespace Ktrgk2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<HangHoa> Goods { get; set; }
    }
}