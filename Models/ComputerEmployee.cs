using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Join table for computer and employee
//Author: Team code

namespace BangazonAPI.Models
{
  public class ComputerEmployee
  // This class indicates when a computer is checked into the system, assigned to an employee, returned, and decomissioned. 
  //THE ? BY DateTime MEANS THAT THE VALUE CAN ALSO BE NULL
  {
    [Key]
    public int ComputerEmployeeId { get; set; }
    [DataType(DataType.Date)]
    public DateTime? OutDate { get; set; } 
    [DataType(DataType.Date)]
    public DateTime? InDate { get; set; }
    [Required]
    public int EmployeeId { get; set;  }
    public Employee Employee { get; set; }
    [Required]
    public int ComputerId { get; set; }
    public Computer Computer { get; set; }
  }
}