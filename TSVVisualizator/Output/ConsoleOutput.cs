using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace TSVReader.Output
{
    class ConsoleOutput : IOutput
    {
        public void Print(TSVData TSVData)
        {
            string headers = string.Join("\t|", TSVData.Headers);
            Console.WriteLine(headers);
            TSVData.Rows.ForEach((row) => 
            {
                List<string> values = row.Cells.Select((cel) =>  cel.Value ).ToList();
                string line = string.Join("\t", values);
                Console.WriteLine(line);
            });
        }
    }
}
