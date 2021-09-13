using ONECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ONECommerce.Repositories.Interface
{
    public interface IOrderRepository
    {
        Task<Order> CheckOut(Order order);
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
