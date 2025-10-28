

using ClosedXML.Excel;
using System;
using System.Reflection;

namespace API_Cursos_Test.Helpers
{
    public static class DataReadExtensions
    {
        public static List<T> ReadDataFromExcel<T>(this IFormFile file) where T : new()
        {
            List<T> dataList = new List<T>();
            using (var stream = new MemoryStream())
            {
                file.CopyToAsync(stream);
                //using (var package = new OfficeOpenXml.ExcelPackage(stream))
                using (var package = new XLWorkbook(stream))
                {
                    //var worksheet = package.Workbook.Worksheets[0];
                    var worksheet = package.Worksheet(1);
                    //int rowCount = worksheet.Dimension.Rows;
                    //int colCount = worksheet.Dimension.Columns;
                    var lastRowUsed = worksheet.LastRowUsed();
                    int rowCount = lastRowUsed != null ? lastRowUsed.RowNumber() : 1; // Si no hay filas usadas, solo la cabecera
                    int colCount = worksheet.Columns().Count();
                    // Get properties of T
                    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    for (int row = 2; row <= rowCount; row++) // Assuming first row is header
                    {
                        T dataItem = new T();
                        for (int col = 1; col <= colCount; col++)
                        {
                            var cellValue = worksheet.Cell(row, col).GetString();
                            //var property = properties.FirstOrDefault(p => p.Name.Equals(worksheet.Cell(1, col).GetText, StringComparison.OrdinalIgnoreCase));
                            var property = properties.FirstOrDefault(p => string.Equals(p.Name, worksheet.Cell(1, col).GetString(), StringComparison.OrdinalIgnoreCase));
                            if (property != null && !string.IsNullOrEmpty(cellValue))
                            {
                                var convertedValue = Convert.ChangeType(cellValue, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                                property.SetValue(dataItem, convertedValue);
                            }
                        }
                        dataList.Add(dataItem);
                    }
                }
            }
            return dataList;
        }
    }
}
