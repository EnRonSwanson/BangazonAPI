using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Display info for employee(s) 
//Author: Team code
//Methods: Employee constructor method to set default values to Supervisor (1 is true and 0 is false) and date account is created

namespace BangazonAPI.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int? DepartmentId { get; set; }
    public Department Department { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    public int? Supervisor { get; set; }
    public ICollection<ComputerEmployee> ComputerEmployees;
    public ICollection<TrainingPgmEmp> TrainingPgmEmps;

    public Employee() {
      Supervisor = 0;
      StartDate = DateTime.Now;
    }

  }
}