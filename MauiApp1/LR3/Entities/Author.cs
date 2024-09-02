
using SQLite;

namespace MauiApp1.LR3.Entities
{

    [Table("Authors")]
    public class Author
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ID { get; set; }

        [NotNull]
        public string Name { get; set; }
        
        public int Age { get; set; }
    
    }
}
