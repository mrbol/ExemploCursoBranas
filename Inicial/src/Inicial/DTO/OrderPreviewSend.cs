namespace Inicial.DTO
{
    public class OrderPreviewSend
    {
        public OrderPreviewSend()
        {
            Cpf = string.Empty;
            OrderItens = new List<OrderItemSend>();
        }
        public string Cpf { get; set; }
        public List<OrderItemSend> OrderItens { get; set; }
    }
}
