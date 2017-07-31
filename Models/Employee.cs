using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

  //Purpose: Display info for employee(s) 
  //Auther: Team code
  //Methods: Employee constructor method to set default values to Supervisor (1 is true and 0 is false) and date account is created

namespace BangazonAPI.Models
{
  public class Employee
  {
    [Key]
    public int EmployeeId { get; set; }//primary key
    public string Name { get; set; }
    public int? DepartmentId { get; set; }//foreign key
    public Department Department { get; set; }//reference to Department to get DepartmentId
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