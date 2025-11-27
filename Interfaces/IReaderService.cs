using MyLMS.Entities;

namespace MyLMS.Interfaces
{
  public interface IReaderService
   {
       void AddReader(Reader reader);
       List<Reader> GetAllReaders();
       Reader GetReaderById(int id);
   }
}