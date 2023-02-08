using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Domain.DTO;


namespace Integration
{
    public class APITest
    {
        private string _url;
        private CityResponse? _cityResponse;
        private JsonSerializerOptions _options;

        public APITest()
        {
            _url = "https://localhost:44312";
            _cityResponse = new CityResponse() { Total = 0 };
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };
        }

        [Fact(DisplayName = "Deve calcular o frete")]
        [Trait("Categoria", "Frete - calcular o frete")]
        public async void Calcular_Frete()
        {
            //Arrange
            using StringContent jsonContent = new(JsonSerializer.Serialize(new CitySend()
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
            }, _options),Encoding.UTF8, "application/json");
            using HttpClient client = new() { BaseAddress = new Uri(_url) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //act
            var response = await client.PostAsync("/api/CalculateFreight", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                _cityResponse = JsonSerializer.Deserialize<CityResponse>(response.Content.ReadAsStringAsync().Result, _options);
            }

            //Assert
            Assert.Equal(22.45, _cityResponse?.Total);
        }
    }
}
