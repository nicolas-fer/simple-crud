﻿namespace Domain.Models;

public class Pedido
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public string EmailCliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Pago { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}