using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace Unit
{
    public class DistanceCalculatorTest
    {
        [Fact(DisplayName = "Deve calcular a distancia entre duas cidades")]
        [Trait("Categoria", "Calcular - Frete")]
        public void Calcular_Distancia_EntreDuasCidades()
        {

            var from = new Coordinate(-22.9129, -43.2003);
            var to = new Coordinate(-27.5945, -48.5477);
            var distance = DistanceCalculator.Calculate(from, to);

            //assert
            Assert.Equal(748.2217780081631,distance);
        }
    }
}