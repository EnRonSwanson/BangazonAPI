using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  //Purpose: Contain customer info, including potential products to sell and customer's orders
  //Auther: Team code
  //Methods: Customer constructor method to set default values (1 is true and 0 is false) and date account is created
  public class Customer
  {
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime AccountCreationDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastActiveDate { get; set; } // on every login we need to reset the counter
    public int Active { get; set; }
    public ICollection<Product> ProductsToSell; // to be sold
    public ICollection<Order> Orders; // to buy or have bought

    public Customer() {
      Active = 1;
      AccountCreationDate = DateTime.Now;
    }

  }
}