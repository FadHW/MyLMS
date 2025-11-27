using MyLMS.Entities;

namespace MyLMS.Interfaces{

 public interface IBookService
{
    void AddBook(Book book);
    List<Book> GetAllBooks();
    Book GetBookById(int id);
}
}