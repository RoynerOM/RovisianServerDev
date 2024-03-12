using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovisianServerDev.Domain.Error
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {

        }
    }

    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }

    }
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message)
        {

        }
    }

    public class DataDuplicateException : Exception
    {
        public DataDuplicateException(string message) : base(message)
        {

        }
    }


}
