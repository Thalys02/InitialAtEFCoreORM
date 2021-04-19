using CursoEFCore.Enums;
using System;
using System.Collections.Generic;

namespace CursoEFCore.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Observation { get; set; }
        public DateTime InitialAtDate { get; set; }
        public DateTime FinishAtDate { get; set; }
        public DispatchType DispatchType{ get; set; }
        public StatusOrder StatusOrder{ get; set; }

        public Client Client { get; set; }
        public ICollection<OrderItem> Itens { get; set; }
    }
}
