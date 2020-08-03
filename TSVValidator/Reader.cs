using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace TSVValidation
{
    class Reader
    {
        private readonly string path;
        public Reader(string path)
        {
            this.path = path;
        }

        internal string[] GetContent()
        {
            string[] content = File.ReadAllLines(path);
            return content;
        }

        internal List<string> GetNoCommentsContent()
        {
            string[] content = File.ReadAllLines(path);
            List<string> pureData = ContentFilter.NoCommentsContent(content);
            return pureData;
        }
    }
}
