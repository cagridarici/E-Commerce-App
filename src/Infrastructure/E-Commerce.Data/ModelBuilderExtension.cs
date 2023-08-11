using E_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Data
{
    public static class ModelBuilderExtension
    {
        public static void InsertMockDatas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "cagri",
                    LastName = "darici",
                    EmailAddress = "cagridarici34@icloud.com",
                    Status = (short)Status.Active
                }
            );

            modelBuilder.Entity<CustomerAddress>().HasData(
                new CustomerAddress
                {
                    Id = 1,
                    CustomerId = 1,
                    AddressLine1 = "0975 Camron Turnpike / Haleighberg 52505",
                    PostalCode = "52505",
                    City = "Haleighberg",
                    Country = "Germany"
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory
                {
                    Id = 1,
                    Name = "Züccaciye",
                    Description = "Cam porselen ve benzeri maddelerden yapılmış olan eşya çeşitlerine Züccaciye denir."
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    CategoryId = 1,
                    ProductName = "Cam Sürahi",
                    UnitPrice = 155.55m,
                    CurrencyId = (short)Currency.TL
                },
                new Product
                {
                    Id = 2,
                    CategoryId = 1,
                    ProductName = "Sepet",
                    UnitPrice = 2m,
                    CurrencyId = (short)Currency.EUR
                },
                new Product
                {
                    Id = 3,
                    CategoryId = 1,
                    ProductName = "Bardak",
                    UnitPrice = 1m,
                    CurrencyId = (short)Currency.USD
                },
                new Product
                {
                    Id = 4,
                    CategoryId = 1,
                    ProductName = "Cam Şişe",
                    UnitPrice = 12m,
                    CurrencyId = (short)Currency.TL
                },
                new Product
                {
                    Id = 5,
                    CategoryId = 1,
                    ProductName = "Zigon Sehpa",
                    UnitPrice = 254.90m,
                    CurrencyId = (short)Currency.TL
                },
                new Product
                {
                    Id = 6,
                    CategoryId = 1,
                    ProductName = "Teflon Tava",
                    UnitPrice = 365.55m,
                    CurrencyId = (short)Currency.TL
                }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    CustomerId = 1,
                    Amount = 55,
                    ProductId = 1,
                    OrderStatus = (short)OrderStatus.Pending
                }
            );
        }
    }
}
