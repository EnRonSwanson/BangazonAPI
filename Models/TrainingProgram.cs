using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Display info for TrainingProgram
//Author: Team code

namespace BangazonAPI.Models
{
  public class TrainingProgram
  {
    [Key]
    public int TrainingProgramId { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public int MaxAttendees { get; set; }
    public ICollection<TrainingPgmEmp> TrainingPgmEmps;
  }
}