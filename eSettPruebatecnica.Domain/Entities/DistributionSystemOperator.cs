using eSettPruebatecnica.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Domain.Entities
{
    public class DistributionSystemOperator : BaseDomainModel
    {
        public string dsoName { get; set; } = String.Empty;
        public string dsoCode { get; set; } = String.Empty;
        public string codingScheme { get; set; } = String.Empty;
        public string country { get; set; } = String.Empty;      
    }
}
