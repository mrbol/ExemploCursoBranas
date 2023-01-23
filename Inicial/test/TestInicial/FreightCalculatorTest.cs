using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;

namespace TestInicial
{
    public class FreightCalculatorTest
    {

        [Fact(DisplayName = "Deve calcular o frete")]
        public void Frete_Calcular()
        {
            //Arrange
            Item item = new Item(1, "Guitarra",1000, new Dimension(100,30,10,3));

            //Act
            decimal freight = FreightCalculator.Calculate(item);

            //Assert
            Assert.Equal(30, freight);
        }

        [Fact(DisplayName = "Deve calcular o frete com preço minimo")]
        public void Frete_Calcular_ComPrecoMinimo()
        {
            //Arrange
            Item item = new Item(3, "Guitarra", 30, new Dimension(10, 10, 10, Convert.ToDecimal(0.9)));

            //Act
            decimal freight = FreightCalculator.Calculate(item);

            //Assert
            Assert.Equal(10, freight);
        }
    }
}
