using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Display info for Products, with a collection of OrderProducts
  //Auther: Team code
  //Methods: This controllers is one part that will go on the join table 


namespace BangazonAPI.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }//primary key
    [Required]
    public int ProductTypeId { get; set; }//foreign key
    public ProductType ProductType { get; set; }//reference to the productType to get the ProductTypeId
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]

    //THIS IS REFERENCING THE PRIMARY KEY OF CUSTOMER (customerId) AND RENAMING IT SellerId
    [ForeignKey("Customer")] 
    public int SellerId { get; set; } // this is the same as CustomerId
    public Customer Customer { get; set; }//reference to  customer to get the CustomerId
    public virtual ICollection<OrderProduct> OrderProducts {get; set;}//collection from the joined table
  }
}