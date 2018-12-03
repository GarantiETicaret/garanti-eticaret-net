using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class VPOSRequest
    {
        public string Mode { get; set; }
        public string Version { get; set; }
        public Terminal Terminal { get; set; }
        public Customer Customer { get; set; }
        public Card Card { get; set; }
        public Order Order { get; set; }
        public Transaction Transaction { get; set; }
    }
}
