using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido").HasKey(t => t.Id);

        builder.Property(p => p.NomeCliente).HasColumnType("varchar").HasMaxLength(60);
        builder.Property(p => p.EmailCliente).HasColumnType("varchar").HasMaxLength(60);
        
        builder.HasMany(t => t.ItensPedidos).WithOne(t => t.Pedido);
    }
}