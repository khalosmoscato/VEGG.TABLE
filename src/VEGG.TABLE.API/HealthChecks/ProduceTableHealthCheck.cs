using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace VEGG.TABLE.API.HealthChecks;

public class ProduceTableHealthCheck : IHealthCheck
{
    private readonly DBContext _db;

    public ProduceTableHealthCheck(DBContext db)
    {
        _db = db;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _ = await _db.ProduceTable.AnyAsync(cancellationToken);
            return HealthCheckResult.Healthy("ProduceTable is queryable.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("ProduceTable query failed.", ex);
        }
    }
}
