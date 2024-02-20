using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto").HasKey(t => t.Id);

        builder.Property(p => p.NomeProduto).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(p => p.Valor).HasPrecision(10, 2);
        
        builder.HasMany(t => t.ItensPedidos).WithOne(t => t.Produto);
        
        // builder.HasData(new Pedido { });
    }
}