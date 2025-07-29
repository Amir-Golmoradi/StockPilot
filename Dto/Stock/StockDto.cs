namespace StockMarket.Dto.Stock;

public record StockDto
{
    public int Id { get; init; }
    public string Symbol { get; init; } = string.Empty;
    public string CompanyName { get; init; } = string.Empty;
    public string Industry { get; init; } = string.Empty;
}