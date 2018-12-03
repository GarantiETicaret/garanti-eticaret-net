using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Codevist.Garanti.DeveloperPortal.Core.BaseEntity
{
    public class UtilityPaymentListRequest
    {
        [XmlElement("InstitutionCode")]
        public string InstitutionCode { get; set; }
        [XmlElement("SubscriberCode")]
        public string SubscriberCode { get; set; }
        [XmlElement("InvoiceID")]
        public string InvoiceID { get; set; }
        [XmlElement("Amount")]
        public string Amount { get; set; }
    }
}
