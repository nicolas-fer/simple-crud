using Domain.Contracts.Repository;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class PedidoRepository : IPedidoRepository
{
    private readonly ApiDbContext _context;

    public PedidoRepository(ApiDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Pedido>> GetAll()
    {
        return await _context.Pedidos
            .AsNoTracking()
            .Include(x => x.ItensPedidos)
            .ToListAsync();
    }

    public async Task<Pedido?> GetById(int id)
    {
        return await _context.Pedidos
            .AsNoTracking()
            .Include(x => x.ItensPedidos)
            .ThenInclude(e => e.Produto)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Pedido> Create(Pedido entity)
    {
        await _context.Pedidos.AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Pedido> Update(Pedido entity)
    {
        _context.Pedidos.Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id) ?? throw new ArgumentException("Pedido não encontrado!");

        _context.Pedidos.Remove(entity);

        await _context.SaveChangesAsync();
    }
}