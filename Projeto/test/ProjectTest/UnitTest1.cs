using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Domain.DTO;

namespace ProjectTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            string _url = "https://localhost:44374";

            var _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };

            int total = 6350;
            using StringContent jsonContent = new(JsonSerializer.Serialize(new OrderPreviewSend
            {
                Cpf = "886.634.854-68",
                OrderItens = new List<OrderItemSend>() {
                    new OrderItemSend { IdItem = 1, Quantity = 1 }
                }
            }, _options),
            Encoding.UTF8, "application/json");


            //act
            using HttpClient client = new() { BaseAddress = new Uri(_url) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("/api/OrderPreview",jsonContent);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}