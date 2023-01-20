using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Inicial;

namespace TestInicial
{
    public class CpfTest
    {
        [Theory(DisplayName = "Deve validar um CPF inválido com todos os dígitos iguais")]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("333.333.333-33")]
        public void ValidaCpf_Invalido_TodosDigitosIguais(string cpf)
        {
            //Arrange
            string message = $"Cpf Inválido";
            //Action
            var myException = Assert.Throws<Exception>(() => new Cpf(cpf));

            //Assert
            Assert.Equal(message, myException.Message);
        }

    }
}
