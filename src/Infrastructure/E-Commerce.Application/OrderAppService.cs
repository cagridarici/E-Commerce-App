using E_Commerce.Domain.Abstract.Repositories;
using E_Commerce.Domain;
using E_Commerce.Domain.Entities;
using E_Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    public class OrderAppService : CrudAppServiceBase<Order>
    {
        private ApplicationRepository<Order> _OrderRepository;
        private ApplicationRepository<Customer> _CustomerRepository;
        private ApplicationRepository<Product> _ProdudctRepository;

        public OrderAppService(
            ApplicationRepository<Order> orderRepository,
            ApplicationRepository<Customer> customerRepository,
            ApplicationRepository<Product> productRepository
            ) : base(orderRepository)
        {
            _OrderRepository = orderRepository;
            _CustomerRepository = customerRepository;
            _ProdudctRepository = productRepository;
        }

        // Custom Service Operations Here...
        public async Task<Customer> GetCustomer(int customerId)
        {
            return await _CustomerRepository.GetItemAsync(customerId);
        }

        public async Task<OperationResult<Order>> GetOrderWithIncludes(int orderId)
        {
            OperationResult<Order> result = new OperationResult<Order>();
            try
            {
                result.SetValue(await _CustomerRepository.DbContext.Orders
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(x => x.Id == orderId));
            }
            catch (Exception ex)
            {
                result.SetError(ex);
            }
            return result;
        }
    }
}
