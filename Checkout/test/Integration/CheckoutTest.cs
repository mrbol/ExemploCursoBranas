using Microsoft.Extensions.Configuration;
using Domain.DTO;
using Domain.Interface;
using Infra.Persistence;
using Application;
using NSubstitute;

namespace Integration
{
    public class CheckoutTest
    {
        private readonly IDapperAdapter _dapperAdapter;
        private readonly IConfiguration _configuration;
        private OrderResponse _orderResponse;

        public CheckoutTest()
        {
            _orderResponse = new OrderResponse() { Total = 0 };
            _configuration = Substitute.For<IConfiguration>();
            _configuration.GetConnectionString("DefaultConnection").Returns("Server=(localdb)\\mssqllocaldb;Database=ApiInicial;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dapperAdapter = new DapperAdapter(_configuration);
        }
        [Fact(DisplayName = "Deve fazer um pedido")]
        public async Task Pedido_FazerPedidoAsync()
        {

            //Arrange
            int total = 6350;
            IItemRepository itemRepository = new ItemRepositoryDatabase(_dapperAdapter);
            IOrderRepository orderRepository = new OrderRepositoryDatabase(_dapperAdapter);
            await orderRepository.Clean();
            Checkout checkout = new Checkout(itemRepository, orderRepository);
            OrderSend orderSend = new OrderSend
            {
                Cpf = "886.634.854-68",
                Date = DateTime.Parse("2022-03-01T10:00:00"),
                OrderItens = new List<OrderItemSend>() {
                    new OrderItemSend { IdItem = 1, Quantity = 1 },
                    new OrderItemSend{ IdItem = 2, Quantity = 1 },
                    new OrderItemSend{ IdItem = 3, Quantity = 3 }
                }
            };
            //act
            _orderResponse = await checkout.Execute(orderSend);
            //Assert
            Assert.Equal(total, _orderResponse?.Total);
            Assert.Equal("202200000001", _orderResponse.Code);
            //Fechando a conexão manualmente 
            await _dapperAdapter.CloseAsync();
        }
    }
}
