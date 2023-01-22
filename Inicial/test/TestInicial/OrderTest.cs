using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;
using System.ComponentModel.DataAnnotations;

namespace TestInicial
{
    
    public class OrderTest
    {
        [Fact(DisplayName ="Deve criar um pedido vazio")]
        public void CriarPedido_Vazio_TotalZerado() {

            //Arrange
            Order order = new Order("886.634.854-68");

            //Act
            decimal total = order.GetTotal();

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


        [Fact(DisplayName = "Deve Criar um Pedido com 3 itens")]
        public void CriarPedido_ComTresItens()
        {

            //Arrange
            Order order = new Order("886.634.854-68");
            order.AddItem(new Item(1, "Guitarra", 1000), 1);
            order.AddItem(new Item(2, "Amplificador", 5000), 1);
            order.AddItem(new Item(3, "Cabo", 30), 3);

            //Act
            decimal total = order.GetTotal();

            //Assert
            Assert.Equal(6090, total);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com 3 itens com cupom de desconto")]
        public void CriarPedido_ComTresItens_ComCupomDesconto()
        {

            //Arrange
            Order order = new Order("886.634.854-68");
            order.AddItem(new Item(1, "Guitarra", 1000), 1);
            order.AddItem(new Item(2, "Amplificador", 5000), 1);
            order.AddItem(new Item(3, "Cabo", 30), 3);
            order.AddCoupon(new Coupon("VALE20", 20));

            //Act
            decimal total = order.GetTotal();

            //Assert
            Assert.Equal(4872, total);
        }
    }
}
