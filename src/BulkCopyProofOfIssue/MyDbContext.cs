using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BulkCopyProofOfIssue
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions? options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Currency>();
        }


        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
            var nameTranslator = NpgsqlConnection.GlobalTypeMapper.DefaultNameTranslator;

            string enumName = nameTranslator.TranslateTypeName(typeof(Currency).Name);
            var memberNames = Enum.GetNames(typeof(Currency))
                .Select(x => nameTranslator.TranslateMemberName(x));

            modelBuilder.HasPostgresEnum(enumName, memberNames.ToArray());

            modelBuilder.Entity<Account>().ToTable("Account");
        }
    }
}
