using Microsoft.Data.SqlClient;
using BookManagementSystem.Database;

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
            using ( SqlConnection connection = dbContext.GetConnection())
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

            Console.ReadLine();
        }
    }
}
