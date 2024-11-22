using BookManagementSystem.Models;
using BookManagementSystem.Database;

namespace BookManagementSystem.Data
{
    public class AuthorData
    {
        private readonly DatabaseContext dbContext;
        public AuthorData()
        {
            dbContext = new DatabaseContext();
        }
        public void AddAuthor(Author author)
        {
            string query = $"INSERT INTO AUTHORS (full_name, yearsOfBirth) VALUES ('{author.full_name}', '{author.yearsOfBirth}')";
            dbContext.ExecuteQuery(query);
        }
    }
}
