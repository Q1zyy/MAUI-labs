
using SQLite;

namespace MauiApp1.LR3.Entities
{
    [Table("Books")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public int Year { get; set; }

        [Indexed]
        public int AuthorID { get; set; }


    }
}
