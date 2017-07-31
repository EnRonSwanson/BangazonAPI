using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Dispaly info for Order with a collection of OrderProducts
//Author: Team code
//Methods: The order method auto generates a current timestamp when an order is created
//When an order is created it will get the current time and date using DateTime.Now
//An order will require the customer Id to be associated with it
//An order will also need but not require a PaymentTypeId to complete its order

namespace BangazonAPI.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; } 
    [Required]
    public int CustomerId { get; set; }  
    public Customer Customer { get; set; }
    public int? PaymentTypeId { get; set;}
    public PaymentType PaymentType { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts {get; set;}

    //In order to actually get the current timestamp (and have it work correctly) this is required
    public Order() {
      DateCreated = DateTime.Now;
    }

  }
}