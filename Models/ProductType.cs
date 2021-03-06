using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Display the productType info with a collection of Products
//Author: Team code

namespace BangazonAPI.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId { get; set; }
    [Required]
    public string Type { get; set; }
    public ICollection<Product> Products;
  }  
}