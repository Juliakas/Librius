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
        [Required]
        [ForeignKey("Book")]
        public string Isbn;
        [ForeignKey("Reader")]
        public int ReaderId { get; set; }
        public DateTime Borrowed { get; set; }

        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}