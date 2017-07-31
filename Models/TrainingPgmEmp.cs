using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: This is a join table for training program and employee
  //Auther: Team code
  //Methods: 


namespace BangazonAPI.Models
{
  public class TrainingPgmEmp
  {
    [Key]
    public int TrainingPgmEmpId { get; set; } // this is the unique id for this relationship on the join table
    [Required]
    public int TrainingProgramId { get; set; } // this id is coming from TrainingProgram
    public TrainingProgram TrainingProgram { get; set; }//reference to the training program to get the TrainingProgramId
    [Required]
    public int EmployeeId { get; set; }// this id is coming from Employee
    public Employee Employee { get; set; }//reference to the employee to get the EmployeeId
  }
}