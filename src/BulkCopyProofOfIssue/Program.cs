using Microsoft.AspNetCore;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using LinqToDB.Data;
using LinqToDB.EntityFrameworkCore;

namespace BulkCopyProofOfIssue
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=127.0.0.1;Port=5432;Database=testbulkcopy;");
            var context = new MyDbContext(optionsBuilder.Options);

            var accounts = new Faker<Account>()
                .RuleFor(s => s.DefaultCurrency, f => Currency.Usd)
                .Generate(500);

            context.BulkCopy(new BulkCopyOptions(), accounts);
            return Task.CompletedTask;
        }
    }
}