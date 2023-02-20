using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using Infra.Persistence;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Application;

namespace Integration
{
    public class DecrementStockTest
    {
        private readonly IDapperAdapter _dapperAdapter;
        private readonly IConfiguration _configuration;
        private readonly IStockEntryRepository _stockEntryRepository;

        public DecrementStockTest()
        {
            _configuration = Substitute.For<IConfiguration>();
            _configuration.GetConnectionString("DefaultConnection").Returns("Server=(localdb)\\mssqllocaldb;Database=ApiInicial;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dapperAdapter = new DapperAdapter(_configuration);
            _stockEntryRepository = new StockEntryRepositoryDatabase(_dapperAdapter);
        }

        [Fact(DisplayName = "Deve decrementar o estoque")]
        public async void Decrementar_Estoque()
        {
            //arrange
            var incrementStock = new IncrementStock(_stockEntryRepository);
            var decrementStock = new DecrementStock(_stockEntryRepository);
            var getStock = new GetStock(_stockEntryRepository);

            //action
            await _stockEntryRepository.Clear();
            await incrementStock.Execute(new List<StockSend>() { new StockSend() { IdItem=1,Quantity=10} });
            await decrementStock.Execute(new List<StockSend>() { new StockSend() { IdItem = 1, Quantity = 5 } });
            int output = await getStock.Execute(1);

            //Assert
            Assert.Equal(5, output);

            await _dapperAdapter.CloseAsync();
        }

        [Fact(DisplayName = "Não deve decrementar o estoque")]
        public async void Nao_Decrementar_Estoque()
        {
            //arrange
            var incrementStock = new IncrementStock(_stockEntryRepository);
            var decrementStock = new DecrementStock(_stockEntryRepository);
            var getStock = new GetStock(_stockEntryRepository);
            string message = "Insufficient stock";

            //action
            await _stockEntryRepository.Clear();
            await incrementStock.Execute(new List<StockSend>() { new StockSend() { IdItem = 1, Quantity = 5 } });
            var myException = Assert.ThrowsAsync<AppException>(async () => await decrementStock.Execute(new List<StockSend>() { new StockSend() { IdItem = 1, Quantity = 10 } }));
            
            //Assert
            Assert.Equal(message, myException.Result.Message);

            await _dapperAdapter.CloseAsync();
        }

    }
}