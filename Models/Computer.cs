using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class Computer
  {
    [Key]
    public int ComputerId { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime PurchaseDate { get; set; }
    public DateTime DecomissionDate { get; set; }
    public ICollection<ComputerEmployee> ComputerEmployees;

    public Computer() {
      PurchaseDate = DateTime.Now;
    }

  }
}