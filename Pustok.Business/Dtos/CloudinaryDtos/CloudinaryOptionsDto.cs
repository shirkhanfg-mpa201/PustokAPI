using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Dtos.CloudinaryDtos
{
    public class CloudinaryOptionsDto
    {
        public string ApiKey { get; set; } = string.Empty;
        public string ApiSecret { get; set; }= string.Empty;
        public string CloudName { get; set; }= string.Empty;
    }
}
