namespace SmqApp.Data;
public interface IWidgetRepository
{
    Task<IReadOnlyList<Widget>> GetWidgetsAsync(CancellationToken ct = default);
}
