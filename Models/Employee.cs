using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    public string Name { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime StartDate { get; set; }
    public bool Supervisor { get; set; }

    public ICollection<ComputerEmployee> ComputerEmployees;

    public ICollection<TrainingPgmEmp> TrainingPgmEmps;

  }
}