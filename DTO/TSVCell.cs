using System;

namespace DTO
{
    public class TSVCell : IComparable<TSVCell>
    {
        public string ColumnTitle { get; set; }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public string Value { get; set; }
        public Type Type { get; set; }

        public int CompareTo(TSVCell other)
        {
            DateTime currentDate = DateTime.Parse(this.Value);
            DateTime otherDate = DateTime.Parse(other.Value);
            return DateTime.Compare(currentDate, otherDate);
        }
    }
}
