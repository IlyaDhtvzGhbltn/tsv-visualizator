using DTO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Parser
{
    public class TSVParser : ITSVParser
    {
        private readonly List<string> noParseData;
        public TSVParser(List<string> noParseData)
        {
            this.noParseData = noParseData;
        }

        public TSVData Parse()
        {
            TSVData data = FillValues();
            data = SetTypes(data);
            return data;
        }


        private TSVData FillValues()
        {
            string[] headers = noParseData[0].Split('\t');
            var tsv = new TSVData();
            tsv.Headers = headers.ToList();

            noParseData.Skip(1).ToList().ForEach((line) =>
            {
                string[] values = line.Split('\t');
                var row = new TSVRow();
                for (int i = 0; i < tsv.Headers.Count; i++)
                {
                    row.Cells.Add(new TSVCell()
                    {
                        Value = values[i],
                        ColumnTitle = tsv.Headers[i],
                        ColumnIndex = i,
                        RowIndex = noParseData.IndexOf(line)
                    });
                }
                tsv.Rows.Add(row);
            });

            return tsv;
        }

        private TSVData SetTypes(TSVData data)
        {
            data.Rows.ForEach((row) => 
            {
                row.Cells.ForEach((cell) =>
                {
                    cell.Type = GetType(cell.Value, cell.ColumnTitle);
                });
            });

            return data;
        }

        private Type GetType(string value, string header)
        {
            var info = new TypeInfo(value);
            if(info.IsDate(header))
                return typeof(DateTime);

            if (info.IsInt(header))
                return typeof(int);

            if (info.IsDecimal(header))
                return typeof(decimal);

            if (info.IsComplexity(header))
                return typeof(Complexity);

            return typeof(string);
        }
    }
}
