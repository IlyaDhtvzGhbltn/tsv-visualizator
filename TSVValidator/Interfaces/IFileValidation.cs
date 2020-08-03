using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationInterfaces
{
    interface IFileValidation
    {
        bool IsFileExist();
        bool IsFileNotEmpty();
        bool IsFileValid();
    }
}
