using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class VPOSResponse
    {
        public string Mode { get; set; }
        public Terminal Terminal { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        
    }
}
