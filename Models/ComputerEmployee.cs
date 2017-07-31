using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Join table for computer and employee
  //Auther: Team code
  //Methods: TO CREATE A CUSTOM CLASS TO FIND WHEN A COMPUTER IS ASSIGNED TO AN EMPLOYEE AND WHEN IT IS RETURNED

namespace BangazonAPI.Models
{
  public class ComputerEmployee
  {
    [Key]
    public int ComputerEmployeeId { get; set; }//primary Key
    [DataType(DataType.Date)]
    public DateTime? OutDate { get; set; }//THE ? BY DateTime MEANS THAT THE VALUE CAN ALSO BE NULL
    [DataType(DataType.Date)]
    public DateTime? InDate { get; set; }//THE ? BY DateTime MEANS THAT THE VALUE CAN ALSO BE NULL
    [Required]
    public int EmployeeId { get; set; }//foreign key
    public Employee Employee { get; set; }//reference to Employee to get EmployeeId
    [Required]
    public int ComputerId { get; set; }//foreign key
    public Computer Computer { get; set; }//reference to Computer to get ComputerId
  }
}