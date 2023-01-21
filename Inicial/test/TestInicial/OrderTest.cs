using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;

namespace TestInicial
{
    
    public class OrderTest
    {
        [Fact(DisplayName ="Deve Criar um Pedido")]
        public void CriarPedido_TotalZerado() {

            //Arrange
            Order order = new Order("886.634.854-68");

            //Act
            int total = order.GetTotal();

            //Assert
            Assert.Equal(0, total);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com CPF invalido")]
        public void CriarPedido_CpfInvalido() {
            //Arrange
            string message = $"Cpf Inválido";

            //Act
            var myException = Assert.Throws<Exception>(() => new Order("111.111.111-11"));

            //Assert
            Assert.Equal(message, myException.Message);
        }

    }
}
