using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryService.Models
{
    [Table("Readers", Schema = "dbo")]
    public class Reader
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
    }
}