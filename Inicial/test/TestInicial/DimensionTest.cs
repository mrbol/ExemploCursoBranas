using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;

namespace TestInicial
{
    public class DimensionTest
    {
        [Fact(DisplayName = "Não dever ter largura negativas")]
        public void Dimensoes_largura_Negativas()
        {
            //Arrange
            string message = "Invalid dimensions";

            //Act
            var myException = Assert.Throws<Exception>(() => new Dimension(-1,0,0,0));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Não dever ter Altura negativas")]
        public void Dimensoes_Altura_Negativas()
        {
            //Arrange
            string message = "Invalid dimensions";

            //Act
            var myException = Assert.Throws<Exception>(() => new Dimension(0, -1, 0, 0));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Não dever ter Profundidade negativas")]
        public void Dimensoes_Profundidade_Negativas()
        {
            //Arrange
            string message = "Invalid dimensions";

            //Act
            var myException = Assert.Throws<Exception>(() => new Dimension(0, 0, -1, 0));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Não dever ter Peso negativas")]
        public void Dimensoes_peso_Negativas()
        {
            //Arrange
            string message = "Invalid dimensions";

            //Act
            var myException = Assert.Throws<Exception>(() => new Dimension(0, 0, 0, -1));

            //Assert
            Assert.Equal(message, myException.Message);
        }
    }
}
