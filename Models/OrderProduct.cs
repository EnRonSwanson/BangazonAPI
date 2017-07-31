using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Join table for OrderId and ProducId
//Author: Team code
//Methods: This controller will join the Id of both tables together

namespace BangazonAPI.Models
{
  public class OrderProduct
  {
    [Key]
    public int OrderProductId { get; set; }
    [Required]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    [Required]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
  }
}