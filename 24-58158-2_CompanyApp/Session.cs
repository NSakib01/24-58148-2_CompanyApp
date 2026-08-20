namespace EmployeeDetails
{
    internal static class Session
    {
        public static int UserID { get; set; }

        public static string Username { get; set; }

        public static void Clear()
        {
            UserID = 0;
            Username = string.Empty;
        }
    }
}
