using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Patient
    {
        [Key]
        public int patientId { get; set; }
        [Required, MaxLength(50), MinLength(10)]
        public string patientName { get; set; }
        [Required, MaxLength(50), MinLength(15)]
        public string patientAddress { get; set; }
    }
}
