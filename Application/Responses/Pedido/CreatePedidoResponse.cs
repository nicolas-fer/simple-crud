namespace Application.Responses.Pedido;

public class CreatePedidoResponse
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Pago { get; set; }
}