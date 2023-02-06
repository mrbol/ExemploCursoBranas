namespace Domain.DTO
{
    public class OrderSend
    {
        public OrderSend()
        {
            Cpf = string.Empty;
            OrderItens = new List<OrderItemSend>();
        }
        public string Cpf { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItemSend> OrderItens { get; set; }
    }
}
