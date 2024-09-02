using MauiApp1.LR3.Entities;

namespace MauiApp1.LR3.Services
{
    public interface IDbService
    {
        IEnumerable<Author> GetAuthors();
        
        IEnumerable<Book> GetAuthorsBooks(string name);
        
        void Init();
    }
}
