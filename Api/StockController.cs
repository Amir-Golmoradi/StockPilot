using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Dto.Stock;
using StockMarket.Interface;
using StockMarket.Mappers;

namespace StockMarket.Api;

[ApiController]
[Route("api/stock")]
public class StockController(AppDBContext appDbContext, IStockRepository stockRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = await stockRepo.GetAllAsync();
        var stockDto = stocks.Select(s => s.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await appDbContext.Stocks.FindAsync(id);

        if (stock == null) return NotFound();

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        // Create our stock model
        var stockModel = stockDto.ToStockFromCreateDto();
        // Check if Stock is Available
        if (stockModel.Equals(null)) return BadRequest();
        await appDbContext.Stocks.AddAsync(stockModel);
        await appDbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
    }

    [HttpPut()]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = await stockRepo.UpdateAsync(id, updateDto);
        if (stockModel == null) return NotFound();
        return Ok(stockModel);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // 1. Find Existing Stocks
        var stockModel = await appDbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null) return NotFound();

        // 2. Delete the Stocks that we want
        appDbContext.Stocks.Remove(stockModel);

        // 3. Save all the changes.
        await appDbContext.SaveChangesAsync();

        return Ok(stockModel.ToStockDto());
    }
}