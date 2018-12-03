using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class CepBankRequest
    {
        [XmlElement(ElementName = "GSMNumber")]
        public string GSMNumber { get; set; }
        [XmlElement(ElementName = "PaymentType")]
        public string PaymentType { get; set; }
    }
}
