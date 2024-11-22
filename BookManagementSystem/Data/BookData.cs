using System.Data.SqlClient;
using BookManagementSystem.Database;
using BookManagementSystem.Models;


namespace BookManagementSystem.Data
{
    
    public class BookData
    {
        private readonly DatabaseContext dbContext;
        public BookData()
        {
            dbContext = new DatabaseContext();
        }
        public void AddBook(Book book)
        {
            string query = $"INSERT INTO BOOKS (book_name, years, author_id) VALUES ('{book.BookName}', {book.Years}, {book.AuthorId})";
            dbContext.ExecuteQuery(query);
        }
    }
}
