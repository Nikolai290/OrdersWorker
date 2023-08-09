using System.Text.Json;
using FluentAssertions;
using OrdersWorker.Business.DataTransferObjects.OrderDtos;
using OrdersWorker.Core.DbEntities;
using OrderWorker.Business.Interfaces.Handler;
using xUnitHelpers;

namespace OrdersWorker.Business.Talabat.Handler.Tests;

public class TalabatHandleTests
{
    [Theory]
    // [TextFileData("testData.txt")]
    [JsonFileData("testData.json", typeof(Order), typeof(Order))]
    public void Test1(Order source, Order expected)
    {
        IOrderHandler handler = new TalabatHandler();
        handler.Run(source);
        source.ConvertedOrder.Should().BeEquivalentTo(expected.ConvertedOrder);
    }
}