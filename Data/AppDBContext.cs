using System;
using Microsoft.EntityFrameworkCore;
using StockMarket.Api.Models;
using StockMarket.Models;

namespace StockMarket.Data
{
  // AppDBContext class inherits from DbContext to manage database operations
  public class AppDBContext : DbContext
  {
    // Constructor that accepts DbContextOptions to configure the context
    public AppDBContext(DbContextOptions contextOptions) : base(contextOptions) { }

    // DbSet property representing the Stocks table in the database
    public DbSet<Stock> Stocks { get; set; }

    // DbSet property representing the Comments table in the database
    public DbSet<Comment> Comments { get; set; }
    
  }
}
