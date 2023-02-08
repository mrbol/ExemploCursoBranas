using Microsoft.Extensions.Configuration;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using Infra.Persistence;
using Application;
using NSubstitute;

namespace Integration
{
    public class CalculateFreightTest
    {
        private readonly IDapperAdapter _dapperAdapter;
        private readonly IConfiguration _configuration;
        public CalculateFreightTest()
        {
            _configuration = Substitute.For<IConfiguration>();
            _configuration.GetConnectionString("DefaultConnection").Returns("Server=(localdb)\\mssqllocaldb;Database=ApiInicial;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dapperAdapter = new DapperAdapter(_configuration);
        }

        [Fact(DisplayName = "Deve calcular a distancia entre dois ceps")]
        [Trait("Categoria", "Frete - calcular o frete")]
        public async void Calcular_Distancia_EntreDoisCep()
        {
            //Arrange
            CitySend citySend = new CitySend()
            {
                From = "22060030",
                To = "88015600",
                OrderItems = new List<OrderItemSend>() { 
                    new OrderItemSend(){ 
                        Volume=0.03,
                        Density=100,
                        Quantity=1,
                    }
                }
            };
            ICityRepository cityRepository = new CityRepositoryDatabase(_dapperAdapter);
            CalculateFreight calculateFreight = new CalculateFreight(cityRepository);

            //Action
            CityResponse cityResponse = await calculateFreight.Execute(citySend);

            //Assert
            Assert.Equal(22.45, cityResponse?.Total);
            await _dapperAdapter.CloseAsync();
        }
    }
}
