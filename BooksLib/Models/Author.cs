using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksLib.Models
{
    public sealed class Author : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Author Id", Prompt = "Prompt", ShortName = "Short name")]
        [Column("Id")]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Book2Author> AuthorBooks { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}