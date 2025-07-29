using System;
using System.ComponentModel.DataAnnotations;
using StockMarket.Models;

namespace StockMarket.Api.Models;

public class Comment
{
  public int Id { get; set; }
  // Who Published the Comment ? Who is he/she ?
  public string Title { get; set; } = string.Empty;
  // What is the Content of that Comment ?
  public string Content { get; set; } = string.Empty;
  // When that Comment, were published ?
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  // Foreign Key From Stock Entity.
  // Two Entities Are connected to each other with this Foreign Key
  public int? StockId { get; set; }
  public Stock? Stock { get; set; }
}
