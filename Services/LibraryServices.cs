using MyLMS.Entities;
using MyLMS.Interfaces;
using MyLMS.Repositories;

namespace MyLMS.Services
{
  public class LibraryServices: ILibraryManagement
  {
      public static int MaxBooks=6;
      private IReaderService reader;
      private IBookService book;
      public LibraryServices(IReaderService r, IBookService b)
      {
          reader = r;
          book = b;
      }

      public bool BorrowBook(int bookId, int readerId)
      {
          var bookToBorrow = book.GetBookById(bookId);
          var readerWhoBorrows = reader.GetReaderById(readerId);
          if (bookToBorrow == null || readerWhoBorrows == null)
          {
              return false;
          }
          if (bookToBorrow.AvailableBook==false || readerWhoBorrows.BlockedReader() == true)
          {
              return false;
          }
          readerWhoBorrows.ReaderBorrowCounter();
          bookToBorrow.Borrowed();
          readerWhoBorrows.CheckNotifications();
          return true;
      }

      public double ReturnBook(int bookId, int readerId)
      {
          var bookToReturn = book.GetBookById(bookId);
          var readerReturning = reader.GetReaderById(readerId);

          if (bookToReturn == null || readerReturning == null) return -1;

         
          readerReturning.ReaderReturnCounter();

          double fine = 0;
          if (bookToReturn.BorrowedDate.HasValue)
          {
              int daysBorrowed = (DateTime.Now - bookToReturn.BorrowedDate.Value).Days;
              int daysLate = daysBorrowed - bookToReturn.AllowedDays;
              if (daysLate > 0)
              {
                  fine = daysLate * 2;
              }
          }

          bookToReturn.Available();
          readerReturning.CheckNotifications();
          return fine;
      }

      public int TotalBorrowedBooks()
      {
          return book.GetAllBooks().Count(b => b.AvailableBook == false);
      }

      public List<Reader> TopReaders(int topN)
      {
          return reader.GetAllReaders().OrderByDescending
              (r => r.CurrentBorrowedBooks()).Take(topN).ToList();                 
      }
  }

}