using RentAPitch.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Infrastructure
{
    public interface IOrderDetailsService
    {
        void Insert(OrderDetail orderDetail);
        IEnumerable<OrderDetail> GetOrderDetail(int orderHeaderId);
    }
}
