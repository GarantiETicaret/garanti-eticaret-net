using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    [XmlRoot(ElementName = "Payment")]
    public class PaymentRequest
    {
        [XmlElement(ElementName = "Number")]
        public int Number { get; set; }
        [XmlElement(ElementName = "DueDate")] //yyyymmgg şeklinde gönderilecektir.
        public string DueDate { get; set; }
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
    }
}
