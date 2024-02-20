using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations;

public class ItensPedidoConfiguration : IEntityTypeConfiguration<ItensPedido>
{
    public void Configure(EntityTypeBuilder<ItensPedido> builder)
    {
        builder.ToTable("ItensPedido").HasKey(t => new {t.Id, t.IdPedido, t.IdProduto});

        builder.Property(p => p.Id).UseIdentityColumn();
        
        builder.HasOne(t => t.Pedido)
            .WithMany(t => t.ItensPedidos)
            .HasForeignKey(x => x.IdPedido);
        
        builder.HasOne(t => t.Produto)
            .WithMany(t => t.ItensPedidos)
            .HasForeignKey(x => x.IdProduto);
        
        // builder.HasData(new Pedido { });
    }
}