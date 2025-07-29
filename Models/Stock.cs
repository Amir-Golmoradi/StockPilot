using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockMarket.Api.Models;

namespace StockMarket.Models;

[Table("Stocks")]
public class Stock
{
    public int Id { get; set; }

    [MaxLength(10)] 
    public string Symbol { get; set; } = string.Empty;
    [MaxLength(100)]
    public string CompanyName { get; set;} = string.Empty;
    [MaxLength(100)]
    public string Industry { get; set;} = string.Empty;
    
    public long MarketCap { get; set; }

    [Column(TypeName = "decimal(18,2)")] 
    public decimal Purchase { get; set; }

    [Column(TypeName = "decimal(18,2)")] 
    public decimal LastDiv { get; set; }

    // 1 To Many Relationship with Comments Entity
    // Each Stock Can have Multiple Comments
    public List<Comment> Comment { get; set; } = [];
}