using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: JOIN TABLE FOR ORDER AND PRODUCT
//Author: Team code

namespace BangazonAPI.Models
{
  public class BuyerProduct
  //BuyerProduct class is for returning products associated with each order. It is not a permanent table in the database, so ProductId is still the Primary key.
  {
    [Key]
    public int ProductId { get; set; }
    [Required]
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]

    //THIS IS REFERENCING THE PRIMARY KEY OF CUSTOMER (customerId) AND RENAMING IT BuyerId
    [ForeignKey("Customer")] 
    public int BuyerId { get; set; } // this is the same as CustomerId
    public Customer Customer { get; set; } // reference to customer to get CustomerId
  }
}