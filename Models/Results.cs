using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Tables
{
    public class Results
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string EE3301 { get; set; }
        public string EE3302 { get; set; }
        public string EE3203 { get; set; }
        public string EE3305 { get; set; }
        public string EE3250 { get; set; }
        public string EE3151 { get; set; }
        public string IS3301 { get; set; }
        public string IS3302 { get; set; }
        public string IS3307 { get; set; }
        public double GPA { get; set; }


    }
}
