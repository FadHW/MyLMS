using MyLMS.Entities;
using MyLMS.Repositories;
using MyLMS.Services;
using MyLMS.Interfaces;

namespace MyLMS
{

static void Main(string[] args)
{
    var bookRepo = new BookRepo();
    var readerRepo = new ReaderRepo();
    var empRepo = new EmpRepo();
    var library = new LibraryServices(readerRepo, bookRepo);

    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("\n===== Library Management System =====");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Add Reader");
        Console.WriteLine("3. Add Employee");
        Console.WriteLine("4. Borrow Book");
        Console.WriteLine("5. Return Book");
        Console.WriteLine("6. Renew Membership");
        Console.WriteLine("7. Show Top Readers");
        Console.WriteLine("8. Show Total Borrowed Books");
        Console.WriteLine("9. Check Notifications");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                try
                {
                    Console.Write("Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Author: ");
                    string author = Console.ReadLine();

                    Console.Write("Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Book Health: ");
                    string health = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Error: Title and Author cannot be empty.");
                        break;
                    }

                    bookRepo.AddBook(new Book(title, author, category, health));
                    Console.WriteLine("Book added successfully!");
                }
                catch
                {
                    Console.WriteLine("Invalid book data.");
                }
                break;

            case "2":
                try
                {
                    Console.Write("Reader ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int rId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("Name: ");
                    string rName = Console.ReadLine();

                    Console.Write("Email: ");
                    string rEmail = Console.ReadLine();

                    Console.Write("Membership Expiry (yyyy-MM-dd): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime expiry))
                    {
                        Console.WriteLine("Invalid date format!");
                        break;
                    }

                    readerRepo.AddReader(new Reader(rId, rName, rEmail, expiry));
                    Console.WriteLine("Reader added successfully!");
                }
                catch
                {
                    Console.WriteLine("Error adding reader.");
                }
                break;

            case "3":
                try
                {
                    Console.Write("Employee ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int eId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("Name: ");
                    string eName = Console.ReadLine();

                    Console.Write("Email: ");
                    string eEmail = Console.ReadLine();

                    Console.Write("Salary: ");
                    if (!double.TryParse(Console.ReadLine(), out double salary))
                    {
                        Console.WriteLine("Invalid salary.");
                        break;
                    }

                    Console.Write("Years Worked: ");
                    if (!float.TryParse(Console.ReadLine(), out float years))
                    {
                        Console.WriteLine("Invalid number.");
                        break;
                    }

                    empRepo.AddEmployee(new Employee(salary, eId, eName, eEmail, years));
                    Console.WriteLine("Employee added successfully!");
                }
                catch
                {
                    Console.WriteLine("Error adding employee.");
                }
                break;

            case "4":
                try
                {
                    Console.Write("Book ID to borrow: ");
                    if (!int.TryParse(Console.ReadLine(), out int borrowBookId))
                    {
                        Console.WriteLine("Invalid book ID.");
                        break;
                    }

                    Console.Write("Reader ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int borrowReaderId))
                    {
                        Console.WriteLine("Invalid reader ID.");
                        break;
                    }

                    bool borrowed = library.BorrowBook(borrowBookId, borrowReaderId);
                    Console.WriteLine(borrowed ? "Book borrowed successfully!" : "Cannot borrow book.");
                }
                catch
                {
                    Console.WriteLine("Error borrowing book.");
                }
                break;

            case "5":
                try
                {
                    Console.Write("Book ID to return: ");
                    if (!int.TryParse(Console.ReadLine(), out int returnBookId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    Console.Write("Reader ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int returnReaderId))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    double fine = library.ReturnBook(returnBookId, returnReaderId);
                    Console.WriteLine(fine < 0 ? "Invalid book or reader ID." : $"Book returned. Fine: ${fine}");
                }
                catch
                {
                    Console.WriteLine("Error returning book.");
                }
                break;

            case "6":
                Console.Write("Reader ID: ");
                if (!int.TryParse(Console.ReadLine(), out int renewId))
                {
                    Console.WriteLine("Invalid ID.");
                    break;
                }

                var reader = readerRepo.GetReaderById(renewId);
                if (reader != null)
                {
                    Console.Write("Has paid? (y/n): ");
                    string paid = Console.ReadLine().ToLower();
                    reader.RenewMembership(paid == "y");
                    Console.WriteLine("Membership renewed.");
                }
                else
                {
                    Console.WriteLine("Reader not found.");
                }
                break;

            case "7":
                Console.Write("Top N readers: ");
                if (!int.TryParse(Console.ReadLine(), out int topN))
                {
                    Console.WriteLine("Invalid number.");
                    break;
                }

                var topReaders = library.TopReaders(topN);
                Console.WriteLine("Top Readers:");
                foreach (var r in topReaders)
                    Console.WriteLine($"{r.Name} - Borrowed Books: {r.CurrentBorrowedBooks()}");
                break;

            case "8":
                Console.WriteLine($"Total borrowed books: {library.TotalBorrowedBooks()}");
                break;

            case "9":
                Console.WriteLine("Notifications:");
                foreach (var r in readerRepo.GetAllReaders())
                    r.CheckNotifications();
                break;

            case "0":
                exit = true;
                Console.WriteLine("Exiting...");
                break;

            default:
                Console.WriteLine("Invalid choice! Try again.");
                break;
        }
    }
}

}