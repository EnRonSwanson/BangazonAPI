using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Display paymentType info for each customer, and a collection of Orders
//Author: Team code
//AccountNumber is the number for a customers paymentType, regardless of type
//Types can be //visa, mastercard, americanExpress, and so on


namespace BangazonAPI.Models
{
  public class PaymentType
  {
    [Key]
    public int PaymentTypeId { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public string AccountNumber { get; set; }
    [Required]
    public string Type { get; set; }
    public ICollection<Order> Orders;

  }
}