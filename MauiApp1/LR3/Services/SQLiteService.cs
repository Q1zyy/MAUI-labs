
using MauiApp1.LR3.Entities;
using Microsoft.Extensions.Options;
using SQLite;
using System.Diagnostics;

namespace MauiApp1.LR3.Services
{
    public class SQLiteService : IDbService
    {
        public IEnumerable<Author> GetAuthors()
        {
            var connection = new SQLiteConnection("D:\\proj\\MauiApp1\\MauiApp1\\authors.db");
            return connection.Table<Author>();
        }

        public IEnumerable<Book> GetAuthorsBooks(string name)
        {
            var connection = new SQLiteConnection("D:\\proj\\MauiApp1\\MauiApp1\\authors.db");
            var auth = from a in connection.Table<Author>()
                       where a.Name == name
                       select a;
            int index = auth.First().ID;
            var db = new SQLiteConnection("D:\\proj\\MauiApp1\\MauiApp1\\books.db");
            return from book in db.Table<Book>()
                   where book.AuthorID == index
                   select book;
        }


        public void Init()
        {
            using (var connection = new SQLiteConnection("D:\\proj\\MauiApp1\\MauiApp1\\authors.db"))
            {
                
                try
                {
                    connection.CreateTable<Author>();
                    connection.Insert(new Author { Age = 34, Name = "Alexander Krutoy" });
                    connection.Insert(new Author { Age = 44, Name = "Yuriy Zheltiy" });
                    connection.Insert(new Author { Age = 19, Name = "Kirill Piligrim" });
                    connection.Insert(new Author { Age = 25, Name = "Stanislav Sergeev" });
                }
                catch (Exception e) { };
            }
            using (var connection = new SQLiteConnection("D:\\proj\\MauiApp1\\MauiApp1\\books.db"))
            {

                SQLiteCommand command = new SQLiteCommand(connection);
                try
                {
                    connection.CreateTable<Book>();
                    connection.Insert(new Book {AuthorID=1, Title="Adventures", Year=2022});
                    connection.Insert(new Book {AuthorID=1, Title="Abobas Fridge", Year=2018});
                    connection.Insert(new Book {AuthorID=1, Title="Parkour Masters", Year=1999});
                    connection.Insert(new Book {AuthorID=2, Title="C# for noobs", Year=1972});
                    connection.Insert(new Book {AuthorID=2, Title="Blazor C#", Year=2004});
                    connection.Insert(new Book {AuthorID=2, Title="WiFi", Year=2007});
                    connection.Insert(new Book {AuthorID=2, Title="11.12", Year=1999});
                    connection.Insert(new Book {AuthorID=3, Title="1944", Year=1989});
                    connection.Insert(new Book {AuthorID=3, Title="Chinese", Year=2000});
                    connection.Insert(new Book {AuthorID=3, Title="English", Year=2021});
                    connection.Insert(new Book {AuthorID=3, Title="ghouls", Year=2023});
                    connection.Insert(new Book {AuthorID=3, Title="QWERTY", Year=2024});
                    connection.Insert(new Book {AuthorID=3, Title="Eskertit", Year=2009});
                    connection.Insert(new Book {AuthorID=4, Title="PC production", Year=2013});
                    connection.Insert(new Book {AuthorID=4, Title="Phones", Year=2012});

                } catch (Exception e)
                {
                }
            }
        }
    }
}
