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
            order.AddCoupon(new Coupon("VALE20", 20, DateTime.Parse("2023-03-01T10:00:00")));

            //Act
            decimal total = order.GetTotal();

            //Assert
            Assert.Equal(4872, total);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com 3 itens com cupom de desconto expirado")]
        public void CriarPedido_ComTresItens_ComCupomDesconto_Expirado()
        {
            //Arrange
            Order order = new Order("886.634.854-68", DateTime.Parse("2022-03-10T10:00:00"));
            order.AddItem(new Item(1, "Guitarra", 1000), 1);
            order.AddItem(new Item(2, "Amplificador", 5000), 1);
            order.AddItem(new Item(3, "Cabo", 30), 3);
            order.AddCoupon(new Coupon("VALE20", 20, DateTime.Parse("2022-03-01T10:00:00")));

            //Act
            decimal total = order.GetTotal();

            //Assert
            Assert.Equal(6090, total);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com quantidade de item negativa")]
        public void CriarPedido_ComQuantidadeNegativa()
        {

            //Arrange
            Order order = new Order("886.634.854-68");
            string message = "Invalid quantity";

            //Act
            var myException = Assert.Throws<Exception>(() => order.AddItem(new Item(1, "Guitarra", 1000), -1));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com item duplicado")]
        public void CriarPedido_ComItem_Duplicado()
        {

            //Arrange
            Order order = new Order("886.634.854-68");
            string message = "Duplicate item";

            //Act
            order.AddItem(new Item(1, "Guitarra", 1000),1);
            var myException = Assert.Throws<Exception>(() => order.AddItem(new Item(1, "Guitarra", 1000), -1));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Deve Criar um Pedido com 3 itens e calcular o frete")]
        public void CriarPedido_ComTresItens_CalcularFrete()
        {
            //Arrange
            Order order = new Order("886.634.854-68");
            order.AddItem(new Item(1, "Guitarra", 1000, new Dimension(100,30,10,3)), 1);
            order.AddItem(new Item(2, "Amplificador", 5000, new Dimension(50,50,50,20)), 1);
            order.AddItem(new Item(3, "Cabo", 30, new Dimension(10, 10, 10, 1)), 3);

            //Act
            decimal total = order.GetTotal();

            //Assert
            Assert.Equal(6350, total);
        }
    }   
}
