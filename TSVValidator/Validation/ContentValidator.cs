using System;
using System.Linq;
using ValidationInterfaces;
using System.Collections.Generic;


namespace TSVValidation.Implementation
{
    internal class ContentValidator : IContentValidation
    {
        public List<string> Content { get; private set; }
        public ContentValidator(string[] content)
        {
            this.Content = ContentFilter.NoCommentsContent(content);
            if (content.Length == 0)
                throw new Exception("File contains comments only.");
        }

        public bool IsTSVContentValid()
        {
            return IsTabCount();
        }

        private bool IsTabCount()
        {
            int tabCharInColumns = Content[0].Count(s => s == '\t');

            Content.Skip(1).ToList().ForEach((line) => 
            {
                int tabCharInRow = line.Count(s => s == '\t');
                if (tabCharInColumns != tabCharInRow)
                    throw new Exception("Invalid TSV format.");
            });
            return true;
        }
    }
}
