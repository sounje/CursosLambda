using System.Data;
using System.Reflection;

namespace API_Cursos_Test.Helpers
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all public properties of the type T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns in the DataTable based on the properties
            foreach (PropertyInfo prop in properties)
            {
                // Handle Nullable types by getting the underlying type
                Type colType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, colType);
            }

            // Populate the DataTable with data from the IEnumerable<T>
            foreach (T item in data)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value; // Handle null values
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
