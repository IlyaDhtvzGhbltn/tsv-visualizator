using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSVValidation
{
    internal static class ContentFilter
    {
        public static List<string> NoCommentsContent(string[] content, char startComment = '#')
        {
            var noCommentsContent = new List<string>();
            content.ToList().ForEach(str =>
            {
                if (!string.IsNullOrWhiteSpace(str) && str[0] != startComment)
                {
                    noCommentsContent.Add(str);
                }
            });
            return noCommentsContent;
        }
    }
}
