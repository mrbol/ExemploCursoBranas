using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;
using Domain.Interface;

namespace Infra.Gateway
{
    public class CalculateFreightHttpGateway : ICalculateFreightGateway
    {
        private string _url;
        private JsonSerializerOptions _options;
        private FreightGatewayResponse? _freightGatewayResponse;

        public CalculateFreightHttpGateway()
        {
            _url = "https://localhost:44312";
            _freightGatewayResponse = new FreightGatewayResponse() { Total = 0 };
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null
            };
        }

        public async Task<FreightGatewayResponse> Calculate(FreightGatewaySend freightGatewaySend)
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(freightGatewaySend, _options), Encoding.UTF8, "application/json");
            using HttpClient client = new() { BaseAddress = new Uri(_url) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsync("/api/CalculateFreight", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                _freightGatewayResponse = JsonSerializer.Deserialize<FreightGatewayResponse>(response.Content.ReadAsStringAsync().Result, _options);
            }
            return _freightGatewayResponse != null ? _freightGatewayResponse : new FreightGatewayResponse();
        }
    }
}
