using MyLMS.Entities;
using MyLMS.Interfaces;

namespace MyLMS.Repositories
{

       public class ReaderRepo: IReaderService
        {
            private List<Reader> ReadersStock = new List<Reader>();
            public void AddReader(Reader reader)
            {
                ReadersStock.Add(reader);
            }
            public List<Reader> GetAllReaders()
            {
                return ReadersStock;
            }
            public Reader GetReaderById(int id)
            {
               return ReadersStock.FirstOrDefault(r => r.Id == id);
            }
        }

}