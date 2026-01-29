using Pustok.Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Exceptions
{
    public class NotFoundException(string message="Object is not found") :Exception(message), IBaseException
    {

        public int StatusCode { get; set; } = 404;

    }
}
