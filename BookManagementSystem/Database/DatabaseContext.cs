using Microsoft.Data.SqlClient;


namespace BookManagementSystem.Database
{
    public class DatabaseContext
    {
        // Chuỗi kết nối
        private readonly string connectionString = "Data Source=LAPTOP-N25AN5LP;Initial Catalog=BOOK;Integrated Security=True;TrustServerCertificate=True;";

        // Lấy kết nối
        public SqlConnection GetConnection()
        {

            // Tạo kết nối
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        // Thực thi truy vấn
        public void ExecuteQuery(string query)
        {
            // Mở kết nối
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Successfully!");
                }
                // Bắt lỗi
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
