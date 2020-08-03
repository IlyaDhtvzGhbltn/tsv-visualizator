using System;

namespace Extensions
{
    public static class intExtensions
    {
        public static int? TryParseNullable(this int? i, string val)
        {
            int outValue;
            return int.TryParse(val, out outValue) ? (int?)outValue : null;
        }
    }
}
