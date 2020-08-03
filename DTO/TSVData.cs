using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TSVData
    {
        public IList<string> Headers { get; set; }
        public List<TSVRow> Rows { get; set; }
        public TSVData()
        {
            Headers = new List<string>();
            Rows = new List<TSVRow>();
        }
    }
}
