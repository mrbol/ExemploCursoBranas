using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Unit
{
    public class CouponTest
    {
        [Fact(DisplayName = "Deve criar um cupom de desconto")]
        public void CriarCoupon_Desconto()
        {
            //Arrange
            var coupon = new Coupon("VALE20", 20, DateTime.Parse("2022-03-01T10:00:00"));

            //Act
            decimal discount = coupon.GetDiscount(1000);

            //Assert
            Assert.Equal(200, discount);
        }

        [Fact(DisplayName = "Deve criar um cupom expirado")]
        public void CriarCoupon_Desconto_Expirado()
        {
            //Arrange
            var coupon = new Coupon("VALE20", 20, DateTime.Parse("2022-03-01T10:00:00"));

            //Act
            bool isExpired = coupon.IsExpired(DateTime.Parse("2022-03-10T10:00:00"));

            //Assert
            Assert.True(isExpired);
        }
    }
}
