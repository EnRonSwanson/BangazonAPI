using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
  public class Department
  {
    [Key]
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public float Budget { get; set; }
    public ICollection<Employee> Employees;
  }
}