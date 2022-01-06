using Microsoft.EntityFrameworkCore;
using P2SWII_API.Models;

namespace P2SWII_API.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet <Usuario> Usuarios { get; set; }
        public DbSet <Produto> Produtos { get; set; }
    }

}

