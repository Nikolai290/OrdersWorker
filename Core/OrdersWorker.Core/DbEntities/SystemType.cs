namespace OrdersWorker.Core.DbEntities;

public record SystemType(Guid Id,string Name) : BaseDbEntity(Id);