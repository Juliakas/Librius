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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [ForeignKey("_reader")]
        public int Reader { get; set; }
        [Required]
        [ForeignKey("Book")]
        public string Isbn { get; set; }
        public DateTime Borrowed { get; set; }

        public Book Book { get; set; }
        public Reader _reader { get; set; }
    }
}