using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryService.Models
{
    [Table("Copies", Schema = "dbo")]
    public class Copy
    {
        public int Id { get; set; }
        public int Reader { get; set; }
        public DateTime Borrowed { get; set; }
        [Required]
        public string Isbn { get; set; }
    }
}