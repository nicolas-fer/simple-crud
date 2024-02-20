using Domain.Models;
using Infrastructure.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApiDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItensPedido> ItensPedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoConfiguration).Assembly);
    }
}