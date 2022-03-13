using DemoWebApiWithSwagger.Enumarations;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApiWithSwagger.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Age { get; set; }

        public Enums.Gender Gender { get; set; }

        public string Address { get; set; }

    }
}
