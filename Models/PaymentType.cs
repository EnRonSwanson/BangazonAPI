using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Display paymentType info for each customer, and a collection of Orders
  //Auther: Team code
  //Methods: 


namespace BangazonAPI.Models
{
  public class PaymentType
  {
    [Key]
    public int PaymentTypeId { get; set; } //primary key 
    [Required]
    public int CustomerId { get; set; }//foreign key
    public Customer Customer { get; set; }//reference back to the customer controller
    [Required]
    public string AccountNumber { get; set; }//number for a customers paymentType
    [Required]
    public string Type { get; set; }//visa, mastercard, americanExpress, so on
    public ICollection<Order> Orders;

  }
}