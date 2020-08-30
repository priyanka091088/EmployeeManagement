using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Depart
    {
        public int DepartId { get; set; }
        [Required]
        public string DepartName { get; set; }
    }
}