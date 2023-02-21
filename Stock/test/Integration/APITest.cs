using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Azure;
using Domain.DTO;

namespace Integration
{
    public class APITest
    {
        private string _url;
        private JsonSerializerOptions _options;
        List<StockSend> _stocksIncrement;
        List<StockSend> _stocksDecrement;

        public APITest()
        {
            _url = "https://localhost:44363/";
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };
            _stocksIncrement = new List<StockSend>() { new StockSend() { IdItem = 1, Quantity = 10 } };
            _stocksDecrement = new List<StockSend>() { new StockSend() { IdItem = 1, Quantity = 5 } };
        }

        [Fact(DisplayName = "Deve decrementar o estoque")]
        public async void Decrementar_Estoque()
        {
            //arrange
            int total = 0;
            using StringContent jsonContentIncrement = new(JsonSerializer.Serialize(_stocksIncrement.ToArray(), _options), Encoding.UTF8, "application/json");
            using StringContent jsonContentDecrement = new(JsonSerializer.Serialize(_stocksDecrement.ToArray(), _options), Encoding.UTF8, "application/json");
            using HttpClient client = new() { BaseAddress = new Uri(_url) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Action
            var responseIncrement = await client.PostAsync("api/Stock/IncrementStock", jsonContentIncrement);
            var responseDecrement = await client.PostAsync("api/Stock/DecrementStock", jsonContentDecrement);
            var responseGetStock = await client.GetAsync("api/stock/1");
            if (responseGetStock.IsSuccessStatusCode)
            {
                total = JsonSerializer.Deserialize<int>(responseGetStock.Content.ReadAsStringAsync().Result, _options);
            }

            //Assert
            Assert.Equal(5,total);

        }
    }
}
