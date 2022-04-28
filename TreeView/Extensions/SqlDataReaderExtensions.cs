using System.Data.SqlClient;

namespace TreeView.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static string GetValueAsString( this SqlDataReader sqlDataReader, string columnName, string defaultValue = "") =>
            sqlDataReader[columnName] != null ? sqlDataReader[columnName].ToString() : defaultValue;

        public static int GetValueAsInt(this SqlDataReader sqlDataReader, string columnName, int defaultValue = 0) => 
            int.TryParse(GetValueAsString(sqlDataReader, columnName, null), out int result) ? result : defaultValue;
    }
}
