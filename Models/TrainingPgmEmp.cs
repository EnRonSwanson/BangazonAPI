using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class TrainingPgmEmp
  {
    [Key]
    public int TrainingPgmEmpId { get; set; } // this is the unique id for this relationship on the join table
    [Required]
    public int TrainingProgramId { get; set; } // this id is coming from TrainingProgram
    public TrainingProgram TrainingProgram { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
  }
}