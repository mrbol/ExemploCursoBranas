﻿using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using Inicial.DTO;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace TestInicial
{
    public class PreviewOrderTest
    {
        private readonly IDapperAdapter _dapperAdapter;
        private readonly IConfiguration _configuration;
        private OrderPreviewResponse _orderPreviewResponse; 
        public PreviewOrderTest()
        {
            _orderPreviewResponse = new OrderPreviewResponse() { Total = 0 };
            _configuration = Substitute.For<IConfiguration>();
            _configuration.GetConnectionString("DefaultConnection").Returns("Server=(localdb)\\mssqllocaldb;Database=ApiInicial;Trusted_Connection=True;MultipleActiveResultSets=true");
            _dapperAdapter = new DapperAdapter(_configuration);
        }

        [Fact(DisplayName = "Deve simular compra")]
        public async Task Simular_CompraAsync()
        {
            //Arrange
            int total = 6350;            
            IItemRepository itemRepository = new ItemRepositoryDatabase(_dapperAdapter);
            PreviewOrder previewOrder = new PreviewOrder(itemRepository);
            OrderPreviewSend orderPreviewSend = new OrderPreviewSend
            {
                Cpf = "886.634.854-68",
                OrderItens = new List<OrderItemSend>() {
                    new OrderItemSend { IdItem = 1, Quantity = 1 },
                    new OrderItemSend{ IdItem = 2, Quantity = 1 },
                    new OrderItemSend{ IdItem = 3, Quantity = 3 }
                }
            };
            //act
            _orderPreviewResponse = await previewOrder.Execute(orderPreviewSend);                        
            //Assert
            Assert.Equal(total, _orderPreviewResponse?.Total);
            //Fechando a conexão manualmente 
            await _dapperAdapter.CloseAsync();
        }
    }
}
