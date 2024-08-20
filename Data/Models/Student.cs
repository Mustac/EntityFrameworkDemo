using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
