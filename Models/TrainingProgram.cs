using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Display info for TrainingProgram
  //Auther: Team code
  //Methods: 


namespace BangazonAPI.Models
{
  public class TrainingProgram
  {
    [Key]
    public int TrainingProgramId { get; set; }//Primary Key
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public int MaxAttendees { get; set; }
    public ICollection<TrainingPgmEmp> TrainingPgmEmps;
  }
}