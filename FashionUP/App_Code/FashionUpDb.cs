using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FashionUP
{
    public static class FashionUpDb
    {
        private static string ConnectionString
        {
            get
            {
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["FashionUp"];
                if (settings == null || String.IsNullOrWhiteSpace(settings.ConnectionString))
                    throw new ConfigurationErrorsException("La connection string FashionUp manca in Web.config.");
                return settings.ConnectionString;
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddRange(parameters);
                DataTable result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int ExecuteProcedure(string procedure, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(procedure, connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(parameters);
                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static SqlParameter Parameter(string name, SqlDbType type, object value, int size)
        {
            SqlParameter parameter = size > 0
                ? new SqlParameter(name, type, size)
                : new SqlParameter(name, type);
            parameter.Value = value ?? DBNull.Value;
            return parameter;
        }

        public static SqlParameter Decimal(string name, decimal value, byte scale)
        {
            return new SqlParameter(name, SqlDbType.Decimal)
            {
                Precision = 18,
                Scale = scale,
                Value = value
            };
        }
    }
}
