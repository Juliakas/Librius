using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryService.Models
{
    [Table("Books", Schema = "dbo")]
    public class Book
    {
        [Key]
        public string Isbn { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; }



    }
}