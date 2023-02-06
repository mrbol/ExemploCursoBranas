using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Domain.DTO;

namespace Integration
{
    public class ApiTest
    {
        private string _url;
        private OrderResponse _orderPreviewResponse;
        private JsonSerializerOptions _options;

        public ApiTest()
        {
            _url = "https://localhost:44374";
            _orderPreviewResponse = new OrderResponse() { Total = 0 };
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };
        }

        [Fact(DisplayName = "Deve simular compra")]
        public async Task Simular_CompraAsync()
        {
            //Arrange
            int total = 6350;
            using StringContent jsonContent = new(JsonSerializer.Serialize(new
            {
                cpf = "886.634.854-68",
                orderItens = new[] {
                    new { idItem = 1, quantity = 1 },
                    new { idItem = 2, quantity = 1 },
                    new { idItem = 3, quantity = 3 }
                },
            }, _options),
            Encoding.UTF8, "application/json");

            //act
            using HttpClient client = new() { BaseAddress = new Uri(_url) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("/api/OrderPreview", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                _orderPreviewResponse = JsonSerializer.Deserialize<OrderResponse>(response.Content.ReadAsStringAsync().Result, _options);
            }

            //Assert
            Assert.Equal(total, _orderPreviewResponse?.Total);
        }

    }
}
