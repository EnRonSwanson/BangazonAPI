using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }
    [Required]

    public ProductType ProductType { get; set; } // need constructor
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public int SellerId { get; set; } // this is the same as CustomerId
    [Required]
    public Customer Customer { get; set; } // need both to set up FK relationship

    public ICollection<OrderProduct> OrderProducts;

  }
}