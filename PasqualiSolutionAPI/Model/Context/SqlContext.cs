using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoListAPI.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<RegisterPF> Registers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegisterPF>().HasData(new RegisterPF
            {
                Id = 1,
                Name = "Teste PasqualiSolution",
                BIrthDate = DateTime.Now,
                Cpf = "14323412383",
                IncomeValue = 3000
            });
        }
    }
}
