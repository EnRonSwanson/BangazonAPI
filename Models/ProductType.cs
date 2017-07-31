using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Display the productType info with a collection of Products
  //Auther: Team code
  //Methods: 

namespace BangazonAPI.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId { get; set; }//primary key
    [Required]
    public string Type { get; set; }
    public ICollection<Product> Products;
  }  
}