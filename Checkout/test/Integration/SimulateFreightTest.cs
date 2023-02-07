using Microsoft.Extensions.Configuration;
using Domain.DTO;
using Domain.Interface;
using Infra.Persistence;
using Application;
using NSubstitute;

namespace Integration
{
    public class SimulateFreightTest
    {
        private readonly IDapperAdapter _dapperAdapter;
        private readonly IConfiguration _configuration;
        public SimulateFreightTest()
        {
            _configuration = Substitute.For<IConfiguration>();
            _configuration.GetConnectionString("DefaultConnection").Returns("Server=(localdb)\\mssqllocaldb;Database=ApiInicial;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dapperAdapter = new DapperAdapter(_configuration);
        }

        [Fact(DisplayName = "Deve simular o frete")]
        public async Task Simular_FreteAsync()
        {
            //arrange
            IItemRepository itemRepository = new ItemRepositoryDatabase(_dapperAdapter);
            var simulateFreight = new SimulateFreight(itemRepository);

            //action
            var response = await simulateFreight.Execute(new FreightSend()
            { OrdemItems = new List<OrderItemSend>() {
                    new OrderItemSend { IdItem = 1, Quantity = 1 },
                    new OrderItemSend{ IdItem = 2, Quantity = 1 },
                    new OrderItemSend{ IdItem = 3, Quantity = 3 }
                }
               
            });
            //assert
            Assert.Equal(260, response.Total);
            await _dapperAdapter.CloseAsync();
        }
}
}
