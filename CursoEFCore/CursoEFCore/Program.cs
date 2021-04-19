using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //InserirDadosEmMassa();
            //InserirDados();
            //CadastrarPedido();
            ConsultarPedidoCarregamentoAdiantado();
        }


        private static void ConsultarPedidoCarregamentoAdiantado()
        {
            using var db = new Data.ApplicationContext();
            var pedidos = db.Orders
                .Include(i => i.Itens)
                    .ThenInclude(i => i.Product)
                .ToList();
            Console.WriteLine(pedidos.Count);
        }

        private static void CadastrarPedido()
        {
            using var db = new Data.ApplicationContext();

            var client = db.Clients.FirstOrDefault();
            var product = db.Products.FirstOrDefault();

            var pedido = new Order
            {
                ClientId = client.Id,
                InitialAtDate = DateTime.Now,
                FinishAtDate = DateTime.Now,
                Observation = "Pedido Teste",
                StatusOrder = Enums.StatusOrder.Pending,
                DispatchType = Enums.DispatchType.NoDispatch,
                Itens = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId=product.Id,
                        Discount = 0,
                        Amount = 1,
                        Value = 10,
                    }
                }
            };
            db.Orders.Add(pedido);
            db.SaveChanges();
        }
        private static void InserirDadosEmMassa()
        {
            var produto = new Product
            {
                Description = "Produto 2",
                BarCode = "12345678910",
                Value = 20m,
                ProductType = Enums.ProductType.MerchandiseForResale,
                Active = true
            };

            var cliente = new Client
            {
                Name = "Thalys Melicio",
                Cep = "60510450",
                City = "Fortaleza",
                State = "CE",
                PhoneNumber = "85987938455"
            };

            using var db = new Data.ApplicationContext();
            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
            Console.WriteLine($"Quantidade registro(s):{registros}");
        }

        private static void InserirDados()
        {
            var produto = new Product
            {
                Description = "Produto 1",
                BarCode = "123456789",
                Value = 10m,
                ProductType = Enums.ProductType.MerchandiseForResale,
                Active = true
            };
            using var db = new Data.ApplicationContext();
            db.Products.Add(produto);
            var registros = db.SaveChanges();
            Console.WriteLine("Total registros:" + registros);
        }
    }
}
