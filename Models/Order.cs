using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public ICollection<OrderProduct> OrderProducts; // the many side to a 1 to many relationship

    public Order() {
      DateCreated = DateTime.Now;
    }

  }
}