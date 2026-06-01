using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace VEGG.TABLE.API.HealthChecks;

public class UserTableHealthCheck : IHealthCheck
{
    private readonly DBContext _db;

    public UserTableHealthCheck(DBContext db)
    {
        _db = db;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            _ = await _db.UserTable.AnyAsync(cancellationToken);
            return HealthCheckResult.Healthy("UserTable is queryable.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("UserTable query failed.", ex);
        }
    }
}
