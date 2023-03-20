using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        protected ContextBase()
        {
            Database.AutoSavepointsEnabled = true;
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<PokemonsCapturados> PokemonsCapturados { get; set; }
        public DbSet<ApplicationUser> ASpplicationUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ObterStringConexao());
            optionsBuilder.UseSqlite(ObterStringConexao());
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }


        public string ObterStringConexao()
        {
            //return "Data Source=Localshost\\SQLEXPRESS;Initial Catalog=DbMsSqlName;Integrated Security=False;User ID=sa;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return "Data Source=DBAPIPOKEMON.db";
        }
    }
}
