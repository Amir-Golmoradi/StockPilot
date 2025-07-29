namespace StockMarket.Dto.Stock;

public record CreateStockRequestDto(
    string Symbol,
    string CompanyName,
    string Industry,
    long MarketCap,
    decimal Purchase,
    decimal LastDiv
);