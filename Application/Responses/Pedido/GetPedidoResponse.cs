namespace Application.Responses.Pedido;

public class GetPedidoResponse
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public bool Pago { get; set; }
    public decimal ValorTotal { get; set; }
    
    public List<Item> ItensPedido { get; set; }

    public class Item
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}