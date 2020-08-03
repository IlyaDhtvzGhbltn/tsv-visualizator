using System.Collections.Generic;
using TSVValidation.Implementation;
using ValidationInterfaces;

namespace TSVValidation
{
    public class TSVValidator
    {
        private readonly string path;
        public List<string> TSVContent { get; private set; }

        public TSVValidator(string path)
        {
            this.path = path;
        }

        public bool IsValid()
        {
            IFileValidation fileValidator = new FileValidation(this.path);
            bool fileValid = fileValidator.IsFileValid();
            if (fileValid)
            {
                var reader = new Reader(this.path);
                string[] content = reader.GetContent();
                IContentValidation contentValidator = new ContentValidator(content);
                bool contentValid = contentValidator.IsTSVContentValid();
                if (contentValid)
                {
                    this.TSVContent = contentValidator.Content;
                    return true;
                }
            }
            return false;
        }
    }
}
