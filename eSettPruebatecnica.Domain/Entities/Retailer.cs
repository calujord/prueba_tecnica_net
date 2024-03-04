using eSettPruebatecnica.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Domain.Entities
{
    public class Retailer : BaseDomainModel
    {    
        public string reName { get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;
        public string codingScheme { get; set; } = String.Empty;
        public string reCode { get; set; } = String.Empty;
    }
}
