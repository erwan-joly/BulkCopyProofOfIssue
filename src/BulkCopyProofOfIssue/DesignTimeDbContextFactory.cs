using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BulkCopyProofOfIssue
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=127.0.0.1;Port=5432;Database=testbulkcopy;");
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}