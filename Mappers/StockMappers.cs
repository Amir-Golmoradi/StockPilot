using StockMarket.Dto.Stock;
using StockMarket.Models;

namespace StockMarket.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel) =>
        new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Industry = stockModel.Industry,
        };


    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto) =>
        new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            LastDiv = stockDto.LastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
}