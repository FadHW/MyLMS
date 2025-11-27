using MyLMS.Entities;
using MyLMS.Interfaces;

namespace MyLMS.Repositories
{

 public class BookRepo: IBookService
 {
     private List<Book> BookStock = new List<Book>();
     public void AddBook(Book bk)
     {
         BookStock.Add(bk);
     }
     public List<Book> GetAllBooks()
     {
         return BookStock;
     }
     public Book GetBookById(int id)
     {
         return BookStock.FirstOrDefault(b => b.Id == id);
     }
 }

}