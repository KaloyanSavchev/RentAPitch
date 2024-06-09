using RentAPitch.Data.Models;

namespace RentAPitch.Models.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
