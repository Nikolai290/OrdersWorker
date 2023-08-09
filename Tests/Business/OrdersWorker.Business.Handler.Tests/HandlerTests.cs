using FluentAssertions;
using Newtonsoft.Json;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrdersWorker.Business.Zomato.Handler;
using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Handler;
using xUnitHelpers;

namespace OrdersWorker.Business.Talabat.Handler.Tests;

public class HandlerTests
{
    [Theory]
    [JsonFileData("testData.json", "TalabatTestData", typeof(Order), typeof(Order))]
    public void TalabatHandlerTest(Order source, Order expected)
    {
        IOrderHandler handler = new TalabatHandler();
        handler.Run(source);
        var actualDto = JsonConvert.DeserializeObject<OrderDto>(source.ConvertedOrder);
        var expectedDto = JsonConvert.DeserializeObject<OrderDto>(expected.ConvertedOrder);
        actualDto.Should().BeEquivalentTo(expectedDto);
    }
    
    [Theory]
    [JsonFileData("testData.json", "ZomatoTestData", typeof(Order), typeof(Order))]
    public void ZomatoHandlerTest(Order source, Order expected)
    {
        IOrderHandler handler = new ZomatoHandler();
        handler.Run(source);
        var actualDto = JsonConvert.DeserializeObject<OrderDto>(source.ConvertedOrder);
        var expectedDto = JsonConvert.DeserializeObject<OrderDto>(expected.ConvertedOrder);
        actualDto.Should().BeEquivalentTo(expectedDto);
    }
}