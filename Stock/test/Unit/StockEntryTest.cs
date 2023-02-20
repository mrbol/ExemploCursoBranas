using Domain.Entity;

namespace Unit
{
    public class StockEntryTest
    {
        [Fact(DisplayName = "Deve criar uma entrada no estoque")]
        public void Criar_Entrada_Estoque()
        {
            //Action
            var stockEntry = new StockEntry(1,"in",10);

            //Assert
            Assert.Equal(1, stockEntry.IdItem);
            Assert.Equal("in", stockEntry.Operation);
            Assert.Equal(10, stockEntry.Quantity);
        }
    }
}