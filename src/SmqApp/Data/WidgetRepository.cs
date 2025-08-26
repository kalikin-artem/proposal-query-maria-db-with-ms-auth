using Dapper;
using MySqlConnector;
namespace SmqApp.Data;
public class WidgetRepository : IWidgetRepository
{
    private readonly string _cs;
    public WidgetRepository(IConfiguration cfg)
    {
        _cs = cfg.GetConnectionString("MariaDb") ?? throw new InvalidOperationException("MariaDb CS missing");
    }
    public async Task<IReadOnlyList<Widget>> GetWidgetsAsync(CancellationToken ct = default)
    {
        await using var conn = new MySqlConnection(_cs);
        await conn.OpenAsync(ct);
        var rows = await conn.QueryAsync<Widget>("SELECT id, name FROM widgets ORDER BY name;");
        return rows.AsList();
    }
}
