using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class Verification
    {
        [XmlElement("ExtreInfo")]
        public string ExtreInfo { get; set; }
        [XmlElement("Identity")]
        public string Identity { get; set; }
        [XmlElement("SMSPassword")]
        public string SMSPassword { get; set; }
        
    }
}
