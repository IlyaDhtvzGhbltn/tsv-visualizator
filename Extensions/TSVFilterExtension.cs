using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class TSVFilterExtension
    {
        public static TSVData OrderByDate(this TSVData data)
        {
            data.Rows = data.Rows
                .OrderBy((row) => row.Cells.First((c) => c.Type.FullName == DateTime.Now.GetType().FullName)).ToList();
            return data;
        }

        public static TSVData FilterProject(this TSVData data, int id, string header = "Project")
        {
            data.Rows.RemoveAll(
                (row) =>
                    row.Cells.First((cel) => cel.ColumnTitle == header).Value != id.ToString()
                );
            return data;
        }

        public static TSVData ClearNULLs(this TSVData data, string[] headers, string oldValue= "NULL", string replValue = "")
        {
            data.Rows.ForEach((line) =>
            {
                var cells = line.Cells.Where((c) => headers.Contains(c.ColumnTitle)).ToList();
                cells.ForEach((cell) =>
                {
                    if (cell.Value == oldValue)
                        cell.Value = replValue;
                });
            });
            return data;
        }
    }
}
