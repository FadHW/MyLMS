

using MyLMS.Entities;

namespace MyLMS.Interfaces
{
 public interface ILibraryManagement
 {
     bool BorrowBook(int bookId, int readerId);
     double ReturnBook(int bookId, int readerId);
 }
}