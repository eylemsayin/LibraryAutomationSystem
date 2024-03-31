using LibraryAutomationSystem.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entities.Abstracts;

public interface IMember
{
    public Guid Id { get; set; }
    string Name { get; set; }
    List<Book> BookList { get; set; }

    void BorrowBook(Book book);
    void ReturnBook(Book book);
    void BorrowedBookList();
}
