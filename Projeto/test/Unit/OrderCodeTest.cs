using Domain.Entities;

namespace Unit
{
    public class OrderCodeTest
    {
        [Fact(DisplayName = "Deve gerar o codigo do pedido")]
        public void CriarCoupon_Desconto()
        {
            //Arrange
            DateTime date = DateTime.Parse("2022-03-01T10:00:00");
            int sequence = 1;
            //Act
            var orderCode = new OrderCode(date, sequence);
            var code = orderCode.Value;
            //Assert
            Assert.Equal("202200000001",code);
        }
    }
}
