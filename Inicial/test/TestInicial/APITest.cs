using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using Inicial.DTO;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace TestInicial
{
    public class APITest
    {
        private string _url;
        private OrderPreviewResponse _orderPreviewResponse;
        private JsonSerializerOptions _options;

        public APITest()
        {
            _url = "https://localhost:44321";
            _orderPreviewResponse = new OrderPreviewResponse() { Total = 0 };
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
                cpf = "071.899.637-23",
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
                _orderPreviewResponse = JsonSerializer.Deserialize<OrderPreviewResponse>(response.Content.ReadAsStringAsync().Result, _options);
            }

            //Assert
            Assert.Equal(total, _orderPreviewResponse?.Total);

        }
    }
}
