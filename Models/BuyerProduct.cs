using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


  //Purpose: JOIN TABLE FOR ORDER AND PRODUCT
  //Auther: Team code
  //Methods: TO CREATE A CUSTOM CLASS TO DIFFERENTIATE BETWEEN A PRODUCT WITH A BUYERID AND A SELLERID



namespace BangazonAPI.Models
{
  public class BuyerProduct
  {
    [Key]
    public int ProductId { get; set; }//primary key
    [Required]
    public int ProductTypeId { get; set; }//foreign key
    public ProductType ProductType { get; set; }//reference key 
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
    public Customer Customer { get; set; }//reference to customer to get CustomerId
  }
}