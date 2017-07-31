using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Join table for OrderId and ProducId
  //Auther: Team code
  //Methods: This controller will join the Id of both tables together


namespace BangazonAPI.Models
{
  public class OrderProduct
  {
    [Key]
    public int OrderProductId { get; set; }//primary key
    [Required]
    public int OrderId { get; set; }//foreign key
    public virtual Order Order { get; set; }//reference to order to get OrderId
    [Required]
    public int ProductId { get; set; }//foreign Key
    public virtual Product Product { get; set; }//reference to Product to get ProductId
  }
}