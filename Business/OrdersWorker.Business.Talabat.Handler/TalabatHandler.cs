using System.Text.Json;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Talabat.Handler;

[SystemType("talabat")]
public class TalabatHandler : IOrderHandler
{
    public void Run(Order order)
    {
        order.Handle(Handle);
    }

    private bool Handle(string source, out string result)
    {
        var success = true;
        result = "";
        var options = new JsonSerializerOptions()
        {
             
        }

        var dto = JsonSerializer.Deserialize<OrderDto>(source);
        // var products = new List<ProductDto>(dto.Products.Length);
        // foreach (var dtoProduct in dto.Products)
        // {
        //     decimal.Parse(dtoProduct.PaidPrice);
        //     var value = decimal.Parse(dtoProduct.PaidPrice);
        //     var prod = dtoProduct with
        //     {
        //         PaidPrice = $"{(value > 0? -value : value)}"
        //     };
        //     products.Add(prod);
        // }

        // var resultDto = dto with
        // {
        //     Products = products.ToArray()
        // };

        // result = JsonSerializer.Serialize(resultDto);
        return success;

    }
}