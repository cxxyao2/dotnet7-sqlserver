using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet7_sqlserver.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Column("sName")]
        public string Name { get; set; } = "John Doe";

        public int Age { get; set; } = 18;
    }
}