using System;
using System.Collections.Generic;
using System.Linq;
using BooksLib.Models;

namespace BooksLib.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BooksLibContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any() && context.Authors.Any())
            {
                return;
            }

            var books = new []
            {
                new Book {Title = "Book1", Description = "First book desc", PublishDate = DateTime.Now.AddDays(-20)},
                new Book {Title = "Book2", Description = "First book desc", PublishDate = DateTime.Now.AddDays(-19)},
                new Book {Title = "Book3", Description = "First book desc", PublishDate = DateTime.Now.AddDays(-18)},
                new Book {Title = "Book4", Description = "First book desc", PublishDate = DateTime.Now.AddDays(-17)},
                new Book {Title = "Book5", Description = "First book desc", PublishDate = DateTime.Now.AddDays(-16)},
            };

            var authors = new []
            {
                new Author {FirstName = "First name1", SecondName = "Second name1", Description = "Desc1", },
                new Author {FirstName = "First name2", SecondName = "Second name2", Description = "Desc2" },
                new Author {FirstName = "First name3", SecondName = "Second name3", Description = "Desc3" }
            };

            context.Authors.AddRange(authors);
            context.Books.AddRange(books);
            context.SaveChanges();            

            authors[0].AuthorBooks = new List<Book2Author>()
            {
                new Book2Author {AuthorId = authors[0].Id, BookId = books[0].Id}
            };

            authors[1].AuthorBooks = new List<Book2Author>()
            {
                new Book2Author {AuthorId = authors[1].Id, BookId = books[0].Id},
                new Book2Author {AuthorId = authors[1].Id, BookId = books[1].Id}
            };

            authors[2].AuthorBooks = new List<Book2Author>()
            {
                new Book2Author {AuthorId = authors[2].Id, BookId = books[0].Id},
                new Book2Author {AuthorId = authors[2].Id, BookId = books[1].Id},
                new Book2Author {AuthorId = authors[2].Id, BookId = books[2].Id}
            };

            context.Authors.UpdateRange(authors);            
            context.SaveChanges();
        }
    }
}
