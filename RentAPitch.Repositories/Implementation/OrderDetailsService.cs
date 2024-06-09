using Microsoft.EntityFrameworkCore;
using RentAPitch.Data;
using RentAPitch.Data.Models;
using RentAPitch.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAPitch.Repositories.Implementation
{
    public class OrderDetailsService : IOrderDetailsService
    {

        private readonly RentAPitchDbContext _context;

        public OrderDetailsService(RentAPitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetOrderDetail(int orderHeaderId)
        {
            return _context.OrderDetails.Where(x => x.OrderHeaderId == orderHeaderId)
               .Include(y => y.Pitch).ToList();
        }

        public void Insert(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }
    }
}
