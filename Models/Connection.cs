using System;
using System.Data;
using System.Data.SqlClient;
namespace QuizGame.Models.Connection
{
    public class Connection : IDisposable
    {
        private readonly string connectionString = "Data Source=DESKTOP-S7JVOGK;Initial Catalog=QuizGame;Integrated Security=True;Encrypt=False;";
        private SqlConnection connection;
 
        public Connection()
        {
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    Console.WriteLine("Kết nối thành công");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể mở kết nối: " + ex.Message);
                throw;
            }
            return connection;
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Kết nối đã được đóng");
            }
        }

        public void ExecuteNonQuery(string query)
        {
            SqlConnection connection = OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }


        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand(query, OpenConnection()))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void ExecuteNonQueryWithParams(string query, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, OpenConnection()))
            {
                command.Parameters.AddRange(parameters);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi thực hiện truy vấn: {ex.Message}");
                    throw; // Ném lại ngoại lệ để xử lý bên ngoài
                }
                finally
                {
                    CloseConnection(); // Đảm bảo đóng kết nối sau khi thực hiện
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            using (SqlCommand command = new SqlCommand(query, OpenConnection()))
            {
                return command.ExecuteScalar();
            }
        }

        public object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, OpenConnection()))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            CloseConnection();
            connection?.Dispose();
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                return command.ExecuteNonQuery(); // Trả về số hàng bị ảnh hưởng
            }
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters)
        {
            SqlConnection connection = OpenConnection();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);
                // Trả về SqlDataReader mà không đóng kết nối
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand(query, OpenConnection()))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

    }
}
