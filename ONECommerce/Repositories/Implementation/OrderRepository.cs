using Microsoft.EntityFrameworkCore;
using ONECommerce.Data;
using ONECommerce.Models;
using ONECommerce.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONECommerce.Repositories.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OneCommerceContext _dbContext;

        public OrderRepository(OneCommerceContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();

            return orderList;
        }

    }
}
