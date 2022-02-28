using System;
using System.Data.SqlClient;

namespace Messenger
{
    class SqlClass
    {
        static string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).FullName).FullName + "\\Database1.mdf";

        public static SqlConnection CreateConnection()
        {
            var connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={path};Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static void OpenConnection()
        {
            CreateConnection().Open();
        }

    }
}
