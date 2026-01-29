using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Abstractions
{
    public interface IBaseException
    {
        public int StatusCode { get; set; }
    }
}
