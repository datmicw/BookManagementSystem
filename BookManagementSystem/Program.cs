using Microsoft.Data.SqlClient;
using BookManagementSystem.Database;
using BookManagementSystem.Data;
using BookManagementSystem.Models;

namespace BookManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Tạo đối tượng DatabaseContext
            DatabaseContext dbContext = new DatabaseContext();

            Console.WriteLine("Checking Database Connection");

            // Kiểm tra kết nối
            using (SqlConnection connection = dbContext.GetConnection())
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database connection successful!");
                }
                // Bắt lỗi
                catch (Exception ex)
                {
                    Console.WriteLine($"Database connection failed: {ex.Message}");
                }
            }
            // Thực thi truy vấn test
            try
            {
                string testQuery = "SELECT 1";
                dbContext.ExecuteQuery(testQuery);
            }
            // Bắt lỗi
            catch (Exception ex)
            {
                Console.WriteLine($"Query execution failed: {ex.Message}");
            }


            Console.WriteLine("1. Add Author");
            Console.WriteLine("2. Add Book");
            int type = Convert.ToInt32(Console.ReadLine());
            switch (type)
            {
                case 1:
                    Console.WriteLine("Adding a new Author to the database");
                    string? authorName = Console.ReadLine();
                    int birth = Convert.ToInt32(Console.ReadLine());

                    if (authorName == null)
                    {
                        Console.WriteLine("Author name cannot be null");
                        return;
                    }

                    AuthorData authorData = new AuthorData();
                    authorData.AddAuthor(new Author
                    {
                        full_name = authorName,
                        yearsOfBirth = birth.ToString(),
                    });
                    Console.WriteLine("Author added successfully!");

                    break;
                case 2:
                    Console.WriteLine("Adding a new book to the database");
                    string? bookName = Console.ReadLine();
                    int bookyears = Convert.ToInt32(Console.ReadLine());
                    int AuthorId = Convert.ToInt32(Console.ReadLine());

                    if (bookName == null)
                    {
                        Console.WriteLine("Book name cannot be null");
                        return;
                    }

                    BookData bookData = new BookData();
                    bookData.AddBook(new Book
                    {
                        BookName = bookName,
                        Years = bookyears,
                        AuthorId = AuthorId
                    });
                    Console.WriteLine("Book added successfully!");
                    break;
            }
            Console.ReadLine();
        }
    }
}
