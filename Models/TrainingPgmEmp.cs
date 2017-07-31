using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: This is a join table for training program and employee
//Author: Team code

namespace BangazonAPI.Models
{
  public class TrainingPgmEmp
  //TrainingPgmEmp class is for the join table between TraininProgram and Employee. Unique IDs are indicated by Id, with TrainingPrmEmpId being the primary key
  {
    [Key]
    public int TrainingPgmEmpId { get; set; }
    [Required]
    public int TrainingProgramId { get; set; }

    public TrainingProgram TrainingProgram { get; set; }
    [Required]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
  }
}