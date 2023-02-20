using Domain.Entity;
namespace Unit
{
    public class StockCalculatorTest
    {
        [Fact(DisplayName = "Deve calcular o estoque de um item")]
        public void Calcular_()
        {
            //arrange
            var stockEntrys = new List<StockEntry>() {
                new StockEntry(1,"in",10),
                new StockEntry(1,"out",5),
                new StockEntry(1,"in",2)
            };

            //Action
            var total = StockCalculator.Calculate(stockEntrys);

            //Assert
            Assert.Equal(7, total);
            
        }
    }
}
