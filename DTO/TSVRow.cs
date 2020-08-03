using System.Collections.Generic;

namespace DTO
{
    public class TSVRow
    {
        public List<TSVCell> Cells { get; set; }
        public TSVRow()
        {
            Cells = new List<TSVCell>();
        }
    }
}