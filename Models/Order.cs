using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; } //Primary key for the Order
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreated { get; set; } //When an order is created it will get the current time and date
    [Required]
    public int CustomerId { get; set; }  //An order will require the customer Id to be associated with it 
    public Customer Customer { get; set; } //This is a link to Customer in order to get the nessecary data from customer
    public int? PaymentTypeId { get; set;} //An order will also need but not require a PaymentTypeId to complete its order
    public PaymentType PaymentType { get; set; } //This is a link to PaymentType in order to get the nessecary data from PaymentType
    public virtual ICollection<OrderProduct> OrderProducts {get; set;} // the many side to a 1 to many relationship

    public Order() {
      DateCreated = DateTime.Now; //In order to actually get the current timestamp (and have it work correctly) this is required
    }

  }
}