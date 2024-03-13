using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PubDomain;
using PublisherData;

using(PublishContext context =  new PublishContext())
{
    context.Database.EnsureCreated();
}
//GetAuthors();
//AddAuthor();
//GetAuthors();
AddAuthorWithBooks();
GetAuthorWithBooks();
void GetAuthors()
{
    using var context = new PublishContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
void AddAuthor()
{
    var author = new Author() { FirstName = "Assem", LastName = "Aly" };
    using var context = new PublishContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
void AddAuthorWithBooks() {
    var author = new Author()
    {
        FirstName = "Mohamed",
        LastName = "Ahmed",
        Books = new List<Book>() {
        new Book(){ Title = "Entity FW Core 8",
            PublishDate = new DateOnly(2024, 1, 1)},
        new Book(){Title = "C# Head First", PublishDate = new DateOnly(2020, 1, 1)}
    }
    };
    using var context = new PublishContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorWithBooks()
{
    using var context = new PublishContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine(book.Title);
        }
    }
}