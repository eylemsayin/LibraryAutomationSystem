using LibraryAutomationSystem.Entities.Abstracts;
using LibraryAutomationSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entities.Concretes;

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<IMember> Members { get; set; } = new List<IMember>();

    private Dictionary<Type, List<Book>> bookTypes = new Dictionary<Type, List<Book>>();

    public Library()
    {
        bookTypes[typeof(BookScience)] = new List<Book>();
        bookTypes[typeof(BookHistory)] = new List<Book>();
        bookTypes[typeof(BookNovel)] = new List<Book>();
    }
    public void BookAdd(Book book)
    {
        Books.Add(book);
        Type bookType = book.GetType();
        if (bookTypes.ContainsKey(bookType))
        {
            bookTypes[bookType].Add(book);
        }
        else
        {
            Console.WriteLine("Please enter the correct book type...");
        }
        Console.WriteLine($"{book.Title} book added...");
    }

    public void BookRemove(Book book)
    {
        if (Books.Contains(book))
        {
            Books.Remove(book);
            Console.WriteLine($"{book.Title} book removed...");
        }
        else
        {
            Console.WriteLine($"{book.Title} book not found");
        }
    }
    public void LendBook(IMember member, Book book)
    {
        if (Books.Contains(book) && book.BookStatus == Status.Available)
        {
            member.BorrowBook(book);
            book.BookStatus = Status.OnLoan;
        }
        else
        {
            Console.WriteLine($"The book to be lent is not available or cannot be borrowed.");
        }
    }
    public void KitapIadeAl(IMember member, Book book)
    {
        if (member.BookList.Contains(book))
        {
            member.ReturnBook(book);
            book.BookStatus = Status.Available;
        }
        else
        {
            Console.WriteLine($"The book to be returned was not found among the books the member borrowed.");
        }
    }

    public void ListBorrowedBooks()
    {
        Console.WriteLine("Borrowed Books:");
        foreach (var book in Books)
        {
            if (book.BookStatus == Status.OnLoan)
            {
                foreach (var member in Members)
                {
                    if (member.BookList.Contains(book))
                    {
                        Console.WriteLine($"Book: {book.Title}, Member: {member.Name}");
                        break;
                    }
                }
            }
        }
    }

    public void ViewMemberList()
    {
        Console.WriteLine("Library Members:");
        foreach (var member in Members)
        {
            Console.WriteLine($"Name: {member.Name}");
        }
    }

    public void ViewAvailableBooks()
    {
        Console.WriteLine("Available Books:");
        foreach (var book in Books)
        {
            if (book.BookStatus == Status.Available)
            {
                Console.WriteLine($"{book.Title}");
            }
        }
    }
}


