using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    internal class TypeInfo
    {
        private readonly string value;
        public TypeInfo(string value)
        {
            this.value = value;
        }

        public bool IsInt(string header)
        {
            if (header == Headers.ProjectId)
            {
                int ex;
                return int.TryParse(this.value, out ex);
            }
            return false;
        }
        public bool IsDate(string header)
        {
            if (header == Headers.StartDate)
            {
                DateTime date;
                return DateTime.TryParse(this.value, out date);
            }
            return false;
        }
        public bool IsDecimal(string header)
        {
            if (header == Headers.SavingsAmount)
            {
                var culture = new CultureInfo(CultureInfo.CurrentCulture.Name)
                {
                    NumberFormat = new NumberFormatInfo()
                    {
                        NumberDecimalSeparator = ","
                    }
                };
                try
                {
                    decimal val = decimal.Parse(this.value.Replace(".", ","), culture);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        public bool IsComplexity(string header)
        {
            if (header == Headers.Complexity)
            {
                try
                {
                    Enum.Parse(typeof(Complexity), this.value);
                    return true;
                }
                catch (Exception)
                {
                    string exMessage = string.Format("Unknown Complexity value - {0}.", this.value);
                    throw new Exception(exMessage);
                }
            }
            return false;
        }
    }
}
