namespace StockMarket.Dto.Stock;

public record UpdateStockRequestDto(
    string Symbol,
    string CompanyName,
    string Industry,
    decimal Purchase,
    decimal LastDiv
);