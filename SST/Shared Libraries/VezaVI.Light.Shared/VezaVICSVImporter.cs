using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace VezaVI.Light.Shared
{
    public class VezaVICSVImporter
    {
        public static DataTable ReadCSVFile(MemoryStream stream)
        {
            DataTable csvData = new DataTable();
            try
            {
                using TextFieldParser csvReader = new TextFieldParser(stream);
                csvReader.SetDelimiters(new string[] { ";" });
                csvReader.HasFieldsEnclosedInQuotes = false;
                string[] colFields = null;
                bool tableCreated = false;
                while (tableCreated == false)
                {
                    colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column)
                        {
                            AllowDBNull = true
                        };
                        csvData.Columns.Add(datecolumn);
                    }
                    tableCreated = true;
                }
                while (!csvReader.EndOfData)
                {
                    string[] line = csvReader.ReadFields();
                    if (line.Length != colFields.Length)
                        break;
                    csvData.Rows.Add(line);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex.InnerException);
            }
            //if everything goes well, serialize csv to json 
            return csvData;
            //jsonString = JsonSerializer.Serialize(csvData);
            //return jsonString;
        }
    }
}
