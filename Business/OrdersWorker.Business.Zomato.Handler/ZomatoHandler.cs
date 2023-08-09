using System.Text.Json;
using Newtonsoft.Json;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Zomato.Handler;

[SystemType("zomato")]
public class ZomatoHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    private bool Handle(string source, out string result)
    {
        var success = true;

        var dto = JsonConvert.DeserializeObject<OrderDto>(source);
        var products = new List<ProductDto>(dto.Products.Length);
        foreach (var dtoProduct in dto.Products)
        {
            decimal.Parse(dtoProduct.PaidPrice);
            var paidPrice = decimal.Parse(dtoProduct.PaidPrice);
            var quantity = int.Parse(dtoProduct.Quantity);
            var prod = dtoProduct with
            {
                UnitPrice = $"{(paidPrice /quantity)}"
            };
            products.Add(prod);
        }

        var resultDto = dto with
        {
            Products = products.ToArray()
        };
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        result = System.Text.Json.JsonSerializer.Serialize(resultDto, options);
        return success;
    }
}