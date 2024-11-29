using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Api.Data.Entities;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class OrderService(DataContext context)
    {
        private readonly DataContext _context = context;

        public async Task<ResultDto> PlaceOrderAsync(OrderPlaceDto dto, Guid customerId)
        {
            var customer = await _context.Users.FirstOrDefaultAsync(u => u.Id == customerId);

            if (customer is null) 
                return ResultDto.Failure("Customer does not exist");

            var orderItems = dto.Items.Select(i =>
            new OrderItem
            {                
                ItemId = i.ItemId,
                CategoryId = i.CategoryId,
                Name = i.Name,
                Price = i.Price,
                Quantity = i.Quantity,
                TotalPrice = i.TotalPrice,
            });

            var order = new Order
            {
                UserId = customerId,
                UserAddress = customer.Address,
                UserEmail = customer.Email,
                UserName = customer.Name,
                OrderAt = DateTime.Now,
                TotalPrice = orderItems.Sum(o => o.TotalPrice),
                OrderItems = orderItems.ToArray()
            };
            try
            {
                await _context.Order.AddAsync(order);
                await _context.SaveChangesAsync();
                return ResultDto.Success();
            }catch (Exception ex)
            {
                return ResultDto.Failure(ex.Message);
            }
        }

        public async Task<OrderDto[]> GetUserOrdersAsync(Guid userId)
        {
            return await _context.Order
                        .Where(o => o.UserId == userId)
                        .Select(o => new OrderDto(o.Id, o.OrderAt, o.TotalPrice, o.OrderItems.Sum(i => i.Quantity)))
                        .ToArrayAsync();
        }

        public async Task<OrderItemDto[]> GetUserOrderItemsAsync(long orderId, Guid userId)
        {
            return await _context.OrderItem
                        .Where(o => o.OrderId == orderId && o.Order.UserId == userId)
                        .Select(o => new OrderItemDto(o.Id, o.ItemId, o.CategoryId, o.Name, o.Quantity, o.Price))
                        .ToArrayAsync();
        }
    }    
}
