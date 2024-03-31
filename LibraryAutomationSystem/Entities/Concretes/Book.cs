using LibraryAutomationSystem.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomationSystem.Entities.Concretes;

public abstract class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Writer { get; set; }
    public DateTime PublicationYear { get; set; }
    public Status BookStatus { get; set; }
}