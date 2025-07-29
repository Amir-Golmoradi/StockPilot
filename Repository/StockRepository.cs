using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Dto.Stock;
using StockMarket.Interface;
using StockMarket.Models;

namespace StockMarket.Repository;

public class StockRepository(AppDBContext appDbContext) : IStockRepository
{
    public async Task<List<Stock>> GetAllAsync()
    {
        return await appDbContext.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await appDbContext.Stocks.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await appDbContext.Stocks.AddAsync(stockModel);
        await appDbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
        var stockModel = await appDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null) return null;
        stockModel.Symbol = stockDto.Symbol;
        stockModel.CompanyName = stockDto.CompanyName;
        stockModel.Industry = stockDto.Industry;
        stockModel.Purchase = stockDto.Purchase;
        stockModel.LastDiv = stockDto.LastDiv;
        await appDbContext.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await appDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null) return null;
        appDbContext.Stocks.Remove(stockModel);
        await appDbContext.SaveChangesAsync();
        return stockModel;
    }
}