using System.Text.Json;
using Newtonsoft.Json;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrderWorker.Business.Interfaces.Attributes;
using OrderWorker.Business.Interfaces.Handler;

namespace OrdersWorker.Business.Talabat.Handler;

[SystemType("talabat")]
public class TalabatHandler : AbstractHandler
{
    protected override bool Handle(string source, out string result)
    {
        var success = true;

        var dto = JsonConvert.DeserializeObject<OrderDto>(source);
        var products = new List<ProductDto>(dto.Products.Length);
        foreach (var dtoProduct in dto.Products)
        {
            decimal.Parse(dtoProduct.PaidPrice);
            var value = decimal.Parse(dtoProduct.PaidPrice);
            var prod = dtoProduct with
            {
                PaidPrice = $"{(value > 0? -value : value)}"
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