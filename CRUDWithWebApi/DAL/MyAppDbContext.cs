using CRUDWithWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithWebApi.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }

        // Criar a tabela de books dentro do Db
        public DbSet<Book> Books { get; set; }
    }

}
