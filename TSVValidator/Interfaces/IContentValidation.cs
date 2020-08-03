using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationInterfaces
{
    interface IContentValidation
    {
        List<string> Content { get; }
        bool IsTSVContentValid();
    }
}
