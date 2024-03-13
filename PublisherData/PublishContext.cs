using Microsoft.EntityFrameworkCore;
using PubDomain;

namespace PublisherData
{
    public class PublishContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = ASSEM;Initial Catalog = PubDatabase;" +
                "Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}
