using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace Repository_Domain
{
    [Serializable]
    [Table("Course")]
    public class Course : IEntity<int>
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        public string CourseType { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Fee { get; set; }

        
    }
}
