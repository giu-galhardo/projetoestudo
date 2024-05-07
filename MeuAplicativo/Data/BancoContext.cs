using MeuAplicativo.Controllers;
using MeuAplicativo.Data;
using MeuAplicativo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuAplicativo.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}