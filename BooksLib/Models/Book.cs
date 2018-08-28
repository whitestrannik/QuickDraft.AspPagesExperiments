using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksLib.Models
{
    public sealed class Book : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Book Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Text for book's too long")]
        [Display(Name = "Book Title")]
        [Column("Title")]
        public string Title { get; set; }

        [StringLength(500)]
        [Display(Name = "Book Description")]
        [Column("Description")]
        public string Description { get; set; }

        public ICollection<Book2Author> BookAuthors { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publishing Date")]
        [Column("PublishDateTime")]
        public DateTime PublishDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
