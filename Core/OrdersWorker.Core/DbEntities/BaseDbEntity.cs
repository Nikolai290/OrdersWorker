namespace OrdersWorker.Core.DbEntities;

public record BaseDbEntity(Guid Id) : BaseDbEntity<Guid>(Id); 

public record BaseDbEntity<TId>(TId Id);