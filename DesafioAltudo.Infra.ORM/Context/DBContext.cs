using DesafioAltudo.Domain.Features;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infra.ORM.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
         : base(options)
        {
        }

        public DbSet<Page> Pages{ get; set; }


       
    }
}
