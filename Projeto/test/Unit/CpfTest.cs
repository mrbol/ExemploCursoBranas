using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Xml.Linq;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Unit
{
    public class CpfTest
    {
        [Fact(DisplayName = "Deve validar um CPF v�lido")]
        public void ValidaCpf_Valido()
        {
            //Arrange
            string valorCpf = "886.634.854-68";

            //Action
            Cpf objCpf = new Cpf(valorCpf);

            //Assert
            Assert.Equal(objCpf.GetValue(), valorCpf);
        }

        [Theory(DisplayName = "Deve validar um CPF inv�lido com todos os d�gitos iguais")]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("333.333.333-33")]
        public void ValidaCpf_Invalido_TodosDigitosIguais(string cpf)
        {
            //Arrange
            string message = $"Cpf Inv�lido";
            //Action
            var myException = Assert.Throws<AppException>(() => new Cpf(cpf));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Deve validar um CPF inv�lido com o tamanho maior")]
        public void ValidaCpf_Invalido_TamanhoMaior()
        {
            //Arrange
            string message = $"Cpf Inv�lido";
            string cpf = "111.111.111-1111";

            //Action
            var myException = Assert.Throws<AppException>(() => new Cpf(cpf));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Deve validar um CPF inv�lido com o tamanho menor")]
        public void ValidaCpf_Invalido_TamanhoMenor()
        {
            //Arrange
            string message = $"Cpf Inv�lido";
            string cpf = "111.111.111";

            //Action
            var myException = Assert.Throws<AppException>(() => new Cpf(cpf));

            //Assert
            Assert.Equal(message, myException.Message);
        }

        [Fact(DisplayName = "Deve validar um CPF vazio")]
        public void ValidaCpf_Invalido_Vazio()
        {
            //Arrange
            string message = $"Cpf Inv�lido";
            string cpf = "";

            //Action
            var myException = Assert.Throws<AppException>(() => new Cpf(cpf));

            //Assert
            Assert.Equal(message, myException.Message);
        }
    }
}
