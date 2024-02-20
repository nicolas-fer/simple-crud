namespace Domain.Models;

public class Produto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; }
    public decimal Valor { get; set; }
    
    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}