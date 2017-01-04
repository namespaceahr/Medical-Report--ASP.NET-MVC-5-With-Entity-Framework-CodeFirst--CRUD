using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Report
    {
        [Key]
        public int reportId { get; set; }
        [Required]
        public string reportType { get; set; }
        [Required]
        public string reportDescription { get; set; }

        public int patientId { get; set; }

        [ForeignKey("patientId")]
        public Patient Patient { get; set; }

        public List<Patient> Patients { get; set; }

    }
}
