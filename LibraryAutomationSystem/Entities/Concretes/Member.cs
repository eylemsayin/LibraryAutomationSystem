using LibraryAutomationSystem.Entities.Abstracts;
using LibraryAutomationSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entities.Concretes;
public class Member : IMember
{
 public Guid Id { get; set; }
public string Name { get; set; }
public List<Book> BookList { get; set; }
public Member(List<Book> _BookList)
{
    BookList = _BookList;
}
public void BorrowBook(Book book)
{
    if (book.BookStatus == Status.Available)
    {
        BookList.Add(book);
        book.BookStatus = Status.OnLoan;
        Console.WriteLine($"{Name}, {book.Title} book borrowed");
    }
    else
    {
        Console.WriteLine($"{book.Title} cannot be borrowed");
    }
}

    public void ReturnBook(Book book)
    {

        if (BookList.Contains(book))
        {
            BookList.Remove(book);
            book.BookStatus = Status.Available;
            Console.WriteLine($"{Name}, {book.Title} the book was returned");
        }
        else
        {
            Console.WriteLine($"{Name}, {book.Title} book borrowed");
        }
    }

    public void BorrowedBookList()
    {
        Console.WriteLine($"{Name} borrowed books: ");
        foreach (var book
            in BookList)
        {
            Console.WriteLine($"{book.Title} ({book.BookStatus})");
        }
    }
}
