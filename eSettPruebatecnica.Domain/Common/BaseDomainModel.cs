using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSettPruebatecnica.Domain.Common
{
    public abstract class BaseDomainModel
    {
        [Key]
        public int id { get; set; }    
    }
}
