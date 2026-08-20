using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    internal class User
    {
        private static readonly string myConn =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        private const string ValidateLoginQuery =
            "SELECT UserID FROM dbo.Users " +
            "WHERE Username = @Username AND Password = @Password";

        private const string UsernameExistsQuery =
            "SELECT COUNT(1) FROM dbo.Users WHERE Username = @Username";

        private const string RegisterUserQuery =
            "INSERT INTO dbo.Users (Username, Password) " +
            "OUTPUT INSERTED.UserID " +
            "VALUES (@Username, @Password)";

        public int ValidateLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(ValidateLoginQuery, con))
                {
                    com.Parameters.AddWithValue("@Username", username);
                    com.Parameters.AddWithValue(
                        "@Password",
                        PasswordHelper.ComputeSha256(password)
                    );

                    object userId = com.ExecuteScalar();
                    return userId == null ? 0 : Convert.ToInt32(userId);
                }
            }
        }

        public bool UsernameExists(string username)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UsernameExistsQuery, con))
                {
                    com.Parameters.AddWithValue("@Username", username);
                    int matches = Convert.ToInt32(com.ExecuteScalar());
                    return matches > 0;
                }
            }
        }

        public int RegisterUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(RegisterUserQuery, con))
                {
                    com.Parameters.AddWithValue("@Username", username);
                    com.Parameters.AddWithValue(
                        "@Password",
                        PasswordHelper.ComputeSha256(password)
                    );

                    return Convert.ToInt32(com.ExecuteScalar());
                }
            }
        }
    }
}
