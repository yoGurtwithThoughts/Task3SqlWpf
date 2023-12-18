using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3SqlWpf.MVVM.Model.Data
{
    class ApplicationContext: DbContext
    {
        public DbSet<Employee > Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Departament> Departamentes { get; set;}
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\msssqllocaldb;Database=Task3SqlWpf;Trusted_Connection=True") ;
        }
    }
}
